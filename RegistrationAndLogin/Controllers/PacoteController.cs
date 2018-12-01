using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationAndLogin.Models;

namespace RegistrationAndLogin.Controllers
{
    public class PacoteController : Controller
    {
        // GET: Pacote
        public ActionResult Index()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            { 
                return View(dc.Pacotes.ToList());
            }
        }

        //Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pacote pacote)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                dc.Pacotes.Add(pacote);
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
                var pacote = dc.Pacotes.FirstOrDefault(p => p.Id == id);

                if (pacote == null)
                    return HttpNotFound();

                return View(pacote);
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
                var pacote = dc.Pacotes.Find(id);

                if (pacote == null)
                    return HttpNotFound();

                return View(pacote);
            }
        }

        [HttpPost]
        public ActionResult Edit(Pacote pacote)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                dc.Pacotes.Find(pacote.Id).Local = pacote.Local;
                dc.Pacotes.Find(pacote.Id).Preco = pacote.Preco;
                dc.Pacotes.Find(pacote.Id).Descricao = pacote.Descricao;
                dc.Pacotes.Find(pacote.Id).Imagem = pacote.Imagem;
                dc.Pacotes.Find(pacote.Id).Promocao = pacote.Promocao;
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
                var pacote = dc.Pacotes.FirstOrDefault(h => h.Id == id);

                if (pacote == null)
                    return HttpNotFound();

                return View(pacote);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var pacote = dc.Pacotes.Find(id);
                dc.Pacotes.Remove(pacote);
                dc.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult AddCarrinho(int? id)
        {
            if (id == null)
                return HttpNotFound();

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var pacote = dc.Pacotes.FirstOrDefault(h => h.Id == id);

                if (dc.Carrinhoes.ToList().Count > 0)
                    return HttpNotFound(); //colocar página de erro pois só pode adicionar 1

                Carrinho c = new Carrinho();
                c.PacoteID = pacote.Id;
                c.Pacote = pacote;
                c.Local = pacote.Local;
                c.CompraID = dc.Compras.ToList()[0].Id;
                c.Compra = dc.Compras.ToList()[0];
                dc.Carrinhoes.Add(c);
                dc.SaveChanges();

                //return View(dc.Carrinhoes.ToList());
                return RedirectToAction(nameof(Index));
            }
        }
    }
}