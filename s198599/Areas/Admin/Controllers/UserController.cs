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
using BLL.BussinessObjectOperations;
using s198599.Controllers;

namespace s198599.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class UserController : BaseController
    {
        public ActionResult Index()
        {
            return View(new UserTransaction().GetList());
        }

        // GET: User/Users/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User User = new UserTransaction().GetById(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }

        // GET: User/Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FirstName,LastName,Address,PostCode,PostAddress, Email, Telephone")] User User)
        {
            if (ModelState.IsValid)
            {
                using (var UserService = new UserTransaction())
                {
                    UserService.Insert(User);
                }

                return RedirectToAction("Index");
            }

            return View(User);
        }

        // GET: User/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOL.Models.User User = new UserTransaction().GetById(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }

        // POST: User/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,LastName,Address,PostCode,PostAddress, Email, Telephone")] BOL.Models.User User)
        {
            if (ModelState.IsValid)
            {
                new UserTransaction().Update(User);

                return RedirectToAction("Index");
            }
            return View(User);
        }

        // GET: User/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOL.Models.User User = new UserTransaction().GetById(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }

        // POST: User/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            new UserTransaction().Delete(id);
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
