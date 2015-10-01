using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOL.Models;
using BLL.DataServices;
using BLL.BussinessTransactions;

namespace s198599.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ItemCategoriesController : Controller
    {
        
        // GET: Admin/ItemCategories
        public ActionResult Index()
        {
            return View(new CategoryTransaction().GetList());
        }

        // GET: Admin/ItemCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCategory itemCategory = new CategoryTransaction().GetById(id);
            if (itemCategory == null)
            {
                return HttpNotFound();
            }
            return View(itemCategory);
        }

        // GET: Admin/ItemCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ItemCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName")] ItemCategory itemCategory)
        {
            if (ModelState.IsValid)
            {
                itemCategory =  new CategoryTransaction().Insert(itemCategory);
                return RedirectToAction("Index");
            }

            return View(itemCategory);
        }

        // GET: Admin/ItemCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCategory itemCategory = new CategoryTransaction().GetById(id);
            if (itemCategory == null)
            {
                return HttpNotFound();
            }
            return View(itemCategory);
        }

        // POST: Admin/ItemCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName")] ItemCategory itemCategory)
        {
            if (ModelState.IsValid)
            {
                itemCategory = new CategoryTransaction().Update(itemCategory);
                return RedirectToAction("Index");
            }
            return View(itemCategory);
        }

        // GET: Admin/ItemCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCategory itemCategory = new CategoryTransaction().GetById(id);
            if (itemCategory == null)
            {
                return HttpNotFound();
            }
            return View(itemCategory);
        }

        // POST: Admin/ItemCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new CategoryTransaction().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
