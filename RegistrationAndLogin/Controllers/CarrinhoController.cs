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

        //Edit
        [HttpGet]
        public ActionResult Edit(int? idCompra, int? idPacote)
        {
            if (idCompra == null)
                return HttpNotFound();

            if (idPacote == null)
                return HttpNotFound();

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var carrinho = dc.Carrinhoes.FirstOrDefault(c => c.CompraID == idCompra && c.PacoteID == idPacote);

                if (carrinho == null)
                    return HttpNotFound();

                return View(carrinho);
            }
        }

        [HttpPost]
        public ActionResult Edit(Carrinho carrinho)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                dc.Carrinhoes.ToList()[0].DataIda = carrinho.DataIda;
                dc.Carrinhoes.ToList()[0].DataVolta = carrinho.DataVolta;
                dc.Carrinhoes.ToList()[0].Quantidade = carrinho.Quantidade;
                dc.Carrinhoes.ToList()[0].Dias = Convert.ToInt32(carrinho.DataVolta.Value.Subtract(carrinho.DataIda.Value).TotalDays);
                dc.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        //Delete
        [HttpGet]
        public ActionResult Delete(int? idCompra, int? idPacote)
        {
            if (idCompra == null)
                return HttpNotFound();

            if (idPacote == null)
                return HttpNotFound();

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var carrinho = dc.Carrinhoes.FirstOrDefault(c => c.CompraID == idCompra && c.PacoteID == idPacote);

                if (carrinho == null)
                    return HttpNotFound();

                return View(carrinho);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int idCompra, int idPacote)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var carrinho = dc.Carrinhoes.ToList()[0];
                dc.Carrinhoes.Remove(carrinho);
                dc.SaveChanges();
                return RedirectToAction(nameof(Index));
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
                    return HttpNotFound();

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

        public ActionResult ConfirmAddVoo(int? id)
        {
            if (id == null)
                return HttpNotFound();

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var voo = dc.Voos.FirstOrDefault(v => v.Id == id);

                if (voo == null)
                    return HttpNotFound();

                dc.Carrinhoes.ToList()[0].VooID = voo.Id;
                dc.Carrinhoes.ToList()[0].Voo = voo;
                dc.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult FinishCompra(int? idCompra, int? idPacote)
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

                if (carrinho.HotelID == null || carrinho.VooID == null || carrinho.DataIda == null || carrinho.DataVolta == null || carrinho.Quantidade == null || carrinho.Dias == null)
                    return HttpNotFound(); //retornar mensagem escrito: "Faltam campos a preencher"

                dc.Compras.ToList()[0].PrecoTotal = carrinho.Quantidade * (carrinho.Pacote.Preco + (carrinho.Hotel.Diaria * carrinho.Dias));
                dc.SaveChanges();

                return RedirectToAction("Index", "Compra");
            }
        }
    }
}