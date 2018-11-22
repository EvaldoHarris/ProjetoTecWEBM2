using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationAndLogin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Contato()
        {
            return View();
        }
        [Authorize]
        public ActionResult Florianopolis()
        {
            return View();
        }
        [Authorize]
        public ActionResult RiodeJaneiro()
        {
            return View();
        }
        [Authorize]
        public ActionResult Carrinho()
        {
            return View();
        }
        [Authorize]
        public ActionResult Voo()
        {
            return View();
        }
        [Authorize]
        public ActionResult Pagamento()
        {
            return View();
        }
        [Authorize]
        public ActionResult Compra()
        {
            return View();
        }
        [Authorize]
        public ActionResult Hotel()
        {
            return View();
        }
        [Authorize]
        public ActionResult Santiago()
        {
            return View();
        }
        [Authorize]
        public ActionResult BuenosAires()
        {
            return View();
        }
        [Authorize]
        public ActionResult RevBuenosAires()
        {
            return View();
        }
    }
}