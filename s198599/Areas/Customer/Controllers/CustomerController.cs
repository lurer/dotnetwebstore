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
using BLL.ObjectServices;

namespace s198599.Areas.Customer.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            return View(new CustomerService().GetList());
        }

        // GET: Customer/Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOL.Models.Customer customer = new CustomerService().GetById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customer/Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Address,PostCode,PostAddress, Email, Telephone")] BOL.Models.Customer customer)
        {
            if (ModelState.IsValid)
            {
                using (var customerService = new CustomerService())
                {
                    customerService.Insert(customer);
                }

                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customer/Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOL.Models.Customer customer = new CustomerService().GetById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Address,PostCode,PostAddress, Email, Telephone")] BOL.Models.Customer customer)
        {
            if (ModelState.IsValid)
            {
                new CustomerService().Update(customer);

                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customer/Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOL.Models.Customer customer = new CustomerService().GetById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customer/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new CustomerService().Delete(id);
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
