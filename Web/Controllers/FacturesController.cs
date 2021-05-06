using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domain.Entities;
using Service;
using Data.Infrastructure;

namespace Web.Controllers
{
    public class FacturesController : Controller
    {
        //private MyFinanceContext db = new MyFinanceContext();

        private FactureService service_facture;

        public FacturesController () {

            this.service_facture = new FactureService();

        }

        // GET: Factures
        public ActionResult Index()
        {
            return View(service_facture.GetAll());
        }

        // GET: Factures/Details/5
        public ActionResult Details(int Productid, int ClientId, DateTime Dateachat)
        {
            if (Productid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = service_facture.GetFactureById(Productid, ClientId, Dateachat);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // GET: Factures/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(service_facture.unitofwork.DataContext.Client, "CIN", "Prenom");
            ViewBag.ProductId = new SelectList(service_facture.unitofwork.DataContext.Products, "ProductId", "Name");
            return View();
        }

        // POST: Factures/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DateAchat,ProductId,ClientId,Prix")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                service_facture.Create(facture);
               
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(service_facture.unitofwork.DataContext.Client, "CIN", "Prenom", facture.ClientId);
            ViewBag.ProductId = new SelectList(service_facture.unitofwork.DataContext.Products, "ProductId", "Name", facture.ProductId);
            return View(facture);
        }

        // GET: Factures/Edit/5
        public ActionResult Edit(int Productid, int ClientId, DateTime Dateachat)
        {
            if (Productid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = service_facture.GetFactureById(Productid, ClientId, Dateachat);
            if (facture == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = service_facture.unitofwork.DataContext.Client.Where(a => a.CIN == ClientId).FirstOrDefault().Prenom;
            ViewBag.Productid = service_facture.unitofwork.DataContext.Products.Where(a => a.ProductId == Productid).FirstOrDefault().Name;
            return View(facture);
        }

        // POST: Factures/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DateAchat,ProductId,ClientId,Prix")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                service_facture.Update(facture);
                
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(service_facture.unitofwork.DataContext.Client, "CIN", "Prenom", facture.ClientId);
            ViewBag.ProductId = new SelectList(service_facture.unitofwork.DataContext.Products, "ProductId", "Name", facture.ProductId);
            return View(facture);
        }

        // GET: Factures/Delete/5
        public ActionResult Delete(int Productid, int ClientId, DateTime Dateachat)
        {
            if (Productid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = service_facture.GetFactureById(Productid, ClientId, Dateachat);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Productid, int ClientId, DateTime Dateachat)
        {
            Facture facture = service_facture.GetFactureById(Productid, ClientId, Dateachat);
            service_facture.Delete(facture);
            
            return RedirectToAction("Index");
        }

        /*protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
