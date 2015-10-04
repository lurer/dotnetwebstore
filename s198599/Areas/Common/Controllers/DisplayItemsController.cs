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
using s198599.Models;
using s198599.Models.ViewModelConverters;
using s198599.Areas.Customer.Controllers;

namespace s198599.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class DisplayItemsController : Controller
    {

        // GET: Common/Item
        public ActionResult ListAll()
        {
            var domainItems = new ItemTransaction().GetList();
            var viewItems = new List<ItemViewPopulated>();
            foreach (var item in domainItems)
            {
                viewItems.Add(ItemViewConverter.convertToView(item));
            }
            return View(viewItems.AsEnumerable());
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
            return View(ItemViewConverter.convertToView(item));
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
