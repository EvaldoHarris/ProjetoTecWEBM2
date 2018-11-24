using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationAndLogin.Models;

namespace RegistrationAndLogin.Controllers
{
    public class VooController : Controller
    {
        // GET: Voo
        public ActionResult Index()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                return View(dc.Voos.ToList());
            }
        }

        //Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Voo voo)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                dc.Voos.Add(voo);
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
                var voo = dc.Voos.FirstOrDefault(v => v.Id == id);

                if (voo == null)
                    return HttpNotFound();

                return View(voo);
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
                var voo = dc.Voos.Find(id);

                if (voo == null)
                    return HttpNotFound();

                return View(voo);
            }
        }

        [HttpPost]
        public ActionResult Edit(Voo voo)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                dc.Voos.Find(voo.Id).Empresa = voo.Empresa;
                dc.Voos.Find(voo.Id).Origem = voo.Origem;
                dc.Voos.Find(voo.Id).Destino = voo.Destino;
                dc.Voos.Find(voo.Id).qtdPassageiros = voo.qtdPassageiros;
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
                var voo = dc.Voos.FirstOrDefault(h => h.Id == id);

                if (voo == null)
                    return HttpNotFound();

                return View(voo);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var voo = dc.Voos.Find(id);
                dc.Voos.Remove(voo);
                dc.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}