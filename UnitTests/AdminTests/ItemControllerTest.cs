
using Microsoft.VisualStudio.TestTools.UnitTesting;
using s198599.Areas.Admin.Controllers;
using BLL.BussinessObjectOperations;
using DAL.DBOperations.DataServiceStubs;
using System.Web.Mvc;


namespace UnitTests
{
    [TestClass]
    public class ItemControllerTest
    {
        [TestMethod]
        public void Index()
        {
            ItemBLL bll = new ItemBLL(new ItemServiceStub());

            var controller = new ItemController(bll);

            var resultat = (ViewResult)controller.Index();
            Assert.AreEqual(resultat.ViewName, "");
        }
    }
}
