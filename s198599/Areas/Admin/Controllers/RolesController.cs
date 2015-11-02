using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOL.Models;
using BLL.BussinessObjectOperations;
using s198599.Controllers;

namespace s198599.Areas.Admin.Controllers
{
    public class RolesController : BaseController
    {

        InterfaceBLL<Role> bll;
        

        public RolesController(InterfaceBLL<Role> bll)
        {
            this.bll = bll;
        }

        public RolesController()
        {
            bll = new UserRoleBLL();
        }

        // GET: Admin/Roles
        public ActionResult Index()
        {
            return View(bll.GetList());
        }



        // GET: Admin/Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleId,RoleStringId,RoleName")] Role role)
        {
            if (ModelState.IsValid)
            {
                bll.Insert(role);
                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: Admin/Roles/Edit/5
        public ActionResult Edit(int? id)
        {

            Role role = bll.GetById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Admin/Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleId,RoleStringId,RoleName")] Role role)
        {
            if (ModelState.IsValid)
            {
                bll.Update(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Admin/Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = bll.GetById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Admin/Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var deletedOK = bll.Delete(id);
            if(deletedOK)
                return RedirectToAction("Index");
            return SetSessionMessage(View(), SESSIONMESSAGE.FAIL,
                "The role is being used by users. It can't be deleted");

        }

    }
}
