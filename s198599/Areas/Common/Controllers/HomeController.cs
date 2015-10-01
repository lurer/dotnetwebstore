using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL.Models;
using BLL.BussinessTransactions;
using BLL.AuthenticationServices;
using AuthenticationServices;
using BLL.DataServices;
using BLL.Initializer;

namespace s198599.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Common/Home
        public ActionResult Index()
        {
            InitializeDb.initializeAdmin();

            return View();
        }

    }
}