using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationAndLogin.Models;

namespace RegistrationAndLogin.Controllers
{
    public class PagamentoController : Controller
    {
        // GET: Pagamento
        public ActionResult Index()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            { 
                return View(dc.Pagamentoes.ToList());
            }
        }

        //Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pagamento pagamento)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                dc.Pagamentoes.Add(pagamento);
                dc.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        //Details
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var pagamento = dc.Pagamentoes.FirstOrDefault(p => p.Id == id);

                if (pagamento == null)
                    return HttpNotFound();

                return View(pagamento);
            }
        }

        //Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var pagamento = dc.Pagamentoes.Find(id);

                if (pagamento == null)
                    return HttpNotFound();

                return View(pagamento);
            }
        }

        [HttpPost]
        public ActionResult Edit(Pagamento pagamento)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                dc.Pagamentoes.Find(pagamento.Id).Tipo = pagamento.Tipo;
                dc.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        //Delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var pagamento = dc.Pagamentoes.FirstOrDefault(h => h.Id == id);

                if (pagamento == null)
                    return HttpNotFound();

                return View(pagamento);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var pagamento = dc.Pagamentoes.Find(id);
                dc.Pagamentoes.Remove(pagamento);
                dc.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}