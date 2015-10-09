using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL.Models;
using BLL.BussinessObjectOperations;
using BLL.AuthenticationServices;
using AuthenticationServices;
using BLL.DBOperations.DataServices;
using BLL.Initializer;
using s198599.Controllers;

namespace s198599.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        // GET: Common/Home
        public ActionResult Index()
        {
            InitializeDb.initializeAdmin();
            return View();
        }

    }
}