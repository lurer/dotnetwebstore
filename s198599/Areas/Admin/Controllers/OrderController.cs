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

namespace s198599.Areas.Customer.Controllers
{
    [Authorize(Roles ="A")]
    public class OrderController : Controller
    {
        
        // GET: Customer/Order
        public ActionResult Index()
        {
            return View(new OrderTransaction().GetList());
        }

        // GET: Customer/Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = new OrderTransaction().GetById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Customer/Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderNumber,DateTime,OrderPriceTotal")] Order order)
        {
            if (ModelState.IsValid)
            {
                new OrderTransaction().Insert(order);
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Customer/Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = new OrderTransaction().GetById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Customer/Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderNumber,DateTime,OrderPriceTotal")] Order order)
        {
            if (ModelState.IsValid)
            {
                new OrderTransaction().Update(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Customer/Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = new OrderTransaction().GetById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Customer/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new OrderTransaction().Delete(id);
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
