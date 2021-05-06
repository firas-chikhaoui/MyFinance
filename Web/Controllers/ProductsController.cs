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
using Data.Infrastructure;
using Data.Reposetries;
using Data.Repositries;
using Service;
using System.IO;

namespace Web.Controllers
{
    public class ProductsController : Controller
    {
        //private MyFinanceContext db = new MyFinanceContext();

        //private ProductRepository product_repo2;
        private ServiceProduct service_product;

        public ProductsController()
        {
            //this.product_repo2 = new ProductRepository(new DatabaseFactory());
            this.service_product = new ServiceProduct();

        }

        // GET: Products
        public ActionResult Index(string filtre)
        {
            var list = service_product.GetAll().ToList();


            if (!String.IsNullOrEmpty(filtre))
            {
                list = service_product.GetProductByName(filtre).ToList();
            }
            return View(list);
        }

        public ActionResult Index2()
        {
            var list = service_product.GetAll().ToList();
            return View(list);

        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = service_product.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(service_product.unitofwork.DataContext.Categories, "CategoryId", "Name");
            return View(new Product());
        }

        // POST: Products/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Name,Description,Price,Quantity,imageName,DateProd,CategoryId")] Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                    file.SaveAs(path);
                }
                product.imageName = file.FileName;

                service_product.Create(product);
                //service_product.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(service_product.unitofwork.DataContext.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = service_product.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(service_product.unitofwork.DataContext.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Description,Price,Quantity,imageName,DateProd,CategoryId")] Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                    file.SaveAs(path);
                }
                product.imageName = file.FileName;

                service_product.Update(product);
               // service_product.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(service_product.unitofwork.DataContext.Categories, "CategoryId", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = service_product.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = service_product.GetById(id);
            service_product.Delete(product);
            //service_product.Save();
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
