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

    

    [Authorize(Roles ="A")]
    public class OrderController : BaseController
    {

        InterfaceBLL<Order> bll;

        public OrderController(InterfaceBLL<Order> bll)
        {
            this.bll = bll;
        }


        public OrderController()
        {
            bll = new OrderBLL();
        }

        // GET: Customer/Order
        public ActionResult Index()
        {
            return View(bll.GetList());
        }


        // GET: Customer/Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = bll.GetById(id);
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



    }
}
