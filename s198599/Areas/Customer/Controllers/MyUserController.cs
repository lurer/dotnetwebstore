using BLL.BussinessObjectOperations;
using BOL.Models;
using Microsoft.AspNet.Identity;
using s198599.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace s198599.Areas.Customer.Controllers
{
    [Authorize]
    public class MyUserController : BaseController
    {
        // GET: Customer/MyUser
        public ActionResult Index()
        {
            string myId = User.Identity.GetUserName();
            User myUser = new UserBLL().getUserByEmail(myId);
            if (myUser == null)
                return SetSessionMessage(View(myUser), SESSIONMESSAGE.FAIL, "Could not get information for your user");
            return View(myUser);
            
        }

        public JsonResult myUserAsJson()
        {
            string myId = User.Identity.GetUserName();
            User myUser = new UserBLL().getUserByEmail(myId);
            return this.Json(myUser);
        }

        public ActionResult _UserPartialView()
        {
            string myId = User.Identity.GetUserName();
            User myUser = new UserBLL().getUserByEmail(myId);
            return View(myUser);
        }


        public JsonResult GetMyOrders(int id)
        {
            var orders = new OrderBLL().GetList().Where(x => x.User.UserID == id);
            return this.Json(orders);
        }


        public JsonResult GetOrderDetail(int id)
        {
            var order = new OrderBLL().GetById(id);
            return Json(order);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User User = new UserBLL().GetById(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,LastName,Address,PostCode, Email, Telephone")] BOL.Models.User User)
        {
            if (ModelState.IsValid)
            {
                var updatedUser = new UserBLL().Update(User);
                if(updatedUser != null)
                    return SetSessionMessage(RedirectToAction("Index"), SESSIONMESSAGE.SUCESS, "Your user account information is updated");
            }
            return SetSessionMessage(View(User), SESSIONMESSAGE.FAIL, "Something went wrong. Please try again!");
        }
    }
}