using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationAndLogin.Models;
using System.Net.Mail;
using System.Net;
using System.Web.Security;
using System.Data.Entity.Validation;

namespace RegistrationAndLogin.Controllers
{
    public class UserController : Controller
    {
        Compra c;

        //Registration Action
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        //Registration POST action 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")] User user)
        {
            bool Status = false;
            string message = "";
            //
            // Model Validation 
            if (ModelState.IsValid)
            {

                #region //Email is already Exist 
                var isExist = IsEmailExist(user.EmailID);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email já existe");
                    return View(user);
                }
                #endregion

                #region Generate Activation Code 
                user.ActivationCode = Guid.NewGuid();
                #endregion

                #region  Password Hashing 
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword); //
                #endregion
                user.IsEmailVerified = false;

                #region Save to Database
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    dc.Users.Add(user);
                    dc.SaveChanges();

                    //Send Email to User
                    SendVerificationLinkEmail(user.EmailID, user.ActivationCode.ToString());
                    message = "Registrado com sucesso. Link de ativação de conta " +
                        " foi enviado para o seu email (Se não receber, conferir o Lixo / Spam):" + user.EmailID;
                    Status = true;
                }
                #endregion
            }
            else
            {
                message = "Pedido inválido";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }
        //Verify Account  
        
        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                dc.Configuration.ValidateOnSaveEnabled = false; 
                var v = dc.Users.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                if (v != null)
                {
                    v.IsEmailVerified = true;
                    dc.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Pedido inválido";
                }
            }
            ViewBag.Status = Status;
            return View();
        }

        //Login 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, string ReturnUrl="")
        {
            string message = "";
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                User v = NewMethod(login, dc);
                if (v != null)
                {
                    if (!v.IsEmailVerified)
                    {
                        ViewBag.Message = "Por favor, verifique seu e-mail primeiro";
                        return View();
                    }

                    if (string.Compare(Crypto.Hash(login.Password), v.Password) == 0)
                    {
                        c = new Compra();
                        c.UserID = v.UserID;
                        c.User = v;
                        v.Compras.Add(c);
                        dc.Compras.Add(c);
                        dc.SaveChanges();

                        int timeout = login.RememberMe ? 525600 : 20;
                        var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Senha incorreta";
                    }
                }
                else
                {
                    message = "Email não cadastrado";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        private static User NewMethod(UserLogin login, MyDatabaseEntities dc)
        {
            return NewMethod1(login, dc);
        }

        private static User NewMethod1(UserLogin login, MyDatabaseEntities dc)
        {
            return NewMethod2(login, dc);
        }

        private static User NewMethod2(UserLogin login, MyDatabaseEntities dc) => dc.Users.Where(a => a.EmailID == login.EmailID).FirstOrDefault();

        //Logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                for (int i = 0; i < dc.Carrinhoes.ToList().Count; i++)
                    dc.Carrinhoes.Remove(dc.Carrinhoes.ToList()[i]);

                for(int j = 0; j < dc.Compras.ToList().Count; j++)
                    dc.Compras.Remove(dc.Compras.ToList()[j]);
                dc.SaveChanges();
            }
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }


        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Users.Where(a => a.EmailID == emailID).FirstOrDefault();
                return v != null;
            }
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode)
        {
            var verifyUrl = "/User/VerifyAccount/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("evaldo.joaoj@gmail.com", "Projeto M2");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "junior@junior2"; 
            string subject = "Sua conta foi criada com sucesso!";

            string body = "<br/><br/>Sua conta foi criada com sucesso. Por favor, clique no link abaixo para verificar sua conta" + 
                " <br/><br/><a href='"+link+"'>"+link+"</a> ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            smtp.Send(message);
        }



    }
}