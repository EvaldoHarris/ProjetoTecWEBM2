using RegistrationAndLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationAndLogin.Controllers
{
    public class CarrinhoController : Controller
    {
        // GET: Carrinho
        public ActionResult Index()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            { 
                return View(dc.Carrinhoes.ToList());
            }
        }

        public ActionResult AddHotel(int? idCompra, int? idPacote)
        {
            if (idCompra == null)
                return HttpNotFound();

            if (idPacote == null)
                return HttpNotFound();

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var carrinho = dc.Carrinhoes.FirstOrDefault(c => c.CompraID == idCompra && c.PacoteID == idPacote);
                
                if (carrinho == null)
                    return RedirectToAction(nameof(Index));

                List<Hotel> hoteisPacote = dc.Hotels.Where(h => h.Local == carrinho.Local).ToList();

                return View(hoteisPacote);
            }
        }

        public ActionResult ConfirmAddHotel(int? id)
        {
            if (id == null)
                return HttpNotFound();

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var hotel = dc.Hotels.FirstOrDefault(h => h.Id == id);

                if (hotel == null)
                    return RedirectToAction(nameof(Index));

                dc.Carrinhoes.ToList()[0].HotelID = hotel.Id;
                dc.Carrinhoes.ToList()[0].HotelNome = hotel.Nome;
                dc.Carrinhoes.ToList()[0].Hotel = hotel;
                dc.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult AddVoo(int? idCompra, int? idPacote)
        {
            if (idCompra == null)
                return HttpNotFound();

            if (idPacote == null)
                return HttpNotFound();

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var carrinho = dc.Carrinhoes.FirstOrDefault(c => c.CompraID == idCompra && c.PacoteID == idPacote);
                if (carrinho == null)
                    return RedirectToAction(nameof(Index));

                List<Voo> voosPacote = dc.Voos.Where(v => v.Destino == carrinho.Local).ToList();

                return View(voosPacote);
            }
        }
    }
}