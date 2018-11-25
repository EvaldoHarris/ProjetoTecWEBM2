using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationAndLogin.Models;

namespace RegistrationAndLogin.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            { 
                return View(dc.Compras.ToList());
            }
        }

        //Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Compra compra)
        {   
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                //compra.UserID = dc.Users.Where(a => a.EmailID == compra.EmailConfirmar).FirstOrDefault().UserID;
                dc.Compras.Add(compra);
                dc.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}