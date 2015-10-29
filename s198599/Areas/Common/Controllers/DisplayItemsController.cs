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

namespace s198599.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class DisplayItemsController : BaseController
    {

        // GET: Common/Item
        public ActionResult ListAll()
        {
            List<Item> domainItems = new List<Item>();
            try { 
                domainItems = new ItemBLL().GetList();
                return View(domainItems.AsEnumerable());
            }
            catch (Exception)
            {
                return SetSessionMessage(View(domainItems), SESSIONMESSAGE.FAIL, "We could not retrieve products from the database");
            }
            


        }

        // GET: Common/Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = new ItemBLL().GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        public JsonResult AddItemToCart(int id)
        {
            var mySessionID = Session["SessionID"] as string;
            return new ShoppingCartController().AddItemToCart(id, mySessionID);

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
