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

namespace s198599.Areas.Common.Controllers
{
    [AllowAnonymous]
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
