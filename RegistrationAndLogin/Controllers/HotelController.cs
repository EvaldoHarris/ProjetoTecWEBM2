using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationAndLogin.Models;

namespace RegistrationAndLogin.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                return View(dc.Hotels.ToList());
            }
        }

        //Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Hotel hotel)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                dc.Hotels.Add(hotel);
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
                var hotel = dc.Hotels.FirstOrDefault(h => h.Id == id);

                if(hotel == null)
                    return HttpNotFound();

                return View(hotel);
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
                var hotel = dc.Hotels.Find(id);

                if (hotel == null)
                    return HttpNotFound();

                return View(hotel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Hotel hotel)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                dc.Hotels.Find(hotel.Id).Nome = hotel.Nome;
                dc.Hotels.Find(hotel.Id).Local = hotel.Local;
                dc.Hotels.Find(hotel.Id).Descricao = hotel.Descricao;
                dc.Hotels.Find(hotel.Id).Diaria = hotel.Diaria;
                dc.Hotels.Find(hotel.Id).Imagem = hotel.Imagem;
                dc.Hotels.Find(hotel.Id).Estrelas = hotel.Estrelas;
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
                var hotel = dc.Hotels.FirstOrDefault(h => h.Id == id);

                if (hotel == null)
                    return HttpNotFound();

                return View(hotel);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var hotel = dc.Hotels.Find(id);
                dc.Hotels.Remove(hotel);
                dc.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}