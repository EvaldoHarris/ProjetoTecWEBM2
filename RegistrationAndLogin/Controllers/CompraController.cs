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

        //Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var compra = dc.Compras.FirstOrDefault(c => c.Id == id);

                if (compra == null)
                    return HttpNotFound();

                return View(compra);
            }
        }

        [HttpPost]
        public ActionResult Edit(Compra compra)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                dc.Compras.ToList()[0].vezesPagamento = compra.vezesPagamento;
                dc.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult AddPagamento(int? id)
        {
            if (id == null)
                return HttpNotFound();

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var compra = dc.Compras.FirstOrDefault(c => c.Id == id);
                if (compra == null)
                    return HttpNotFound();

                return View(dc.Pagamentoes.ToList());
            }
        }

        public ActionResult ConfirmAddPagamento(int? id)
        {
            if (id == null)
                return HttpNotFound();

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var pagamento = dc.Pagamentoes.FirstOrDefault(p => p.Id == id);
                if (pagamento == null)
                    return HttpNotFound();

                dc.Compras.ToList()[0].PagamentoID = pagamento.Id;
                dc.Compras.ToList()[0].TipoPagamento = pagamento.Tipo;
                if (dc.Compras.ToList()[0].TipoPagamento.Equals("Boleto"))
                    dc.Compras.ToList()[0].vezesPagamento = 1;
                else
                    dc.Compras.ToList()[0].vezesPagamento = null;
                dc.Compras.ToList()[0].Pagamento = pagamento;
                dc.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult ConcluirCompra(int? id)
        {
            if (id == null)
                return HttpNotFound();

            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var compra = dc.Compras.FirstOrDefault(c => c.Id == id);
                if (compra == null)
                    return HttpNotFound();

                if (compra.PagamentoID == null || compra.vezesPagamento == null)
                    return RedirectToAction("CompraError", "Compra"); //retornar mensagem escrito: "Faltam campos a preencher"

                return View(compra);
            }
        }

        [HttpPost, ActionName("ConcluirCompra")]
        public ActionResult ConcluirCompraConfirmed(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var carrinho = dc.Carrinhoes.ToList()[0];
                dc.Carrinhoes.Remove(carrinho);
                dc.Compras.ToList()[0].PagamentoID = null;
                dc.Compras.ToList()[0].TipoPagamento = null;
                dc.Compras.ToList()[0].Pagamento = null;
                dc.Compras.ToList()[0].PrecoTotal = null;
                dc.Compras.ToList()[0].vezesPagamento = null;
                dc.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]
        public ActionResult CompraError()
        {
            return View();
        }
    }
}