using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL.Models;
using BLL.BussinessTransactions;
using s198599.Areas.Admin.Models;

namespace s198599.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ItemController : Controller
    {

        // GET: Common/Item
        public ActionResult Index()
        {
             return View(new ItemTransaction().GetList());
        }

        // GET: Common/Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = new ItemTransaction().GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Common/Item/Create
        public ActionResult Create()
        {
            var categories = new CategoryTransaction().GetList();
            IEnumerable<SelectListItem> categoryList = categories.ToList().Select(x => new SelectListItem()
            {
                Value = x.CategoryId.ToString(),
                Text = x.CategoryName
            });
            var viewItem = new ItemViewPopulated();
            viewItem.Categories = new SelectList(categoryList, "Value", "Text");
            return View(viewItem);
        }

        // POST: Common/Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemCode,ItemDesc,SelectedCategory,InStock,Price")] ItemViewPopulated item)
        {
            if (ModelState.IsValid)
            {

                var domainItem = new Item()
                {
                    ItemCode = item.ItemCode,
                    ItemDesc = item.ItemDesc,
                    Category = item.SelectedCategory,
                    InStock = item.InStock,
                    Price = item.Price,
                    ImgPath = item.ImgPath
                };

                new ItemTransaction().Insert(domainItem);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Common/Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = new ItemTransaction().GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Common/Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemNumber,ItemDesc,InStock,Price")] Item item)
        {
            if (ModelState.IsValid)
            {
                new ItemTransaction().Update(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Common/Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = new ItemTransaction().GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Common/Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new ItemTransaction().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            //base.Dispose(disposing);
        }
    }
}
