
using Microsoft.VisualStudio.TestTools.UnitTesting;
using s198599.Areas.Admin.Controllers;
using BLL.BussinessObjectOperations;
using DAL.DBOperations.DataServiceStubs;
using System.Web.Mvc;
using BOL.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CSharp.RuntimeBinder;
using MvcContrib.TestHelper;

namespace UnitTests.AdminTests
{
    [TestClass]
    public class ItemControllerTest
    {
        

        //  Item/Index
        [TestMethod]
        public void ItemList()
        {

            //Arrange
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            List<Item> forventetListe = new List<Item>();
            var Item = new Item
            {
                ItemID = 1,
                ItemCode = "DFGHJ",
                ItemDesc = "Dette er et kjempebra produkt",
                Category = 1,
                ImgPath = "",
                InStock = 5,
                Price = 100
            };
            forventetListe.Add(Item);
            forventetListe.Add(Item);
            forventetListe.Add(Item);


            //Act
            var actionResultat = (ViewResult)controller.Index();
            var resultat = (List<Item>)actionResultat.Model;


            //Result
            Assert.AreEqual(actionResultat.ViewName, "");

            for(var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetListe[i].ItemID, resultat[i].ItemID);
                Assert.AreEqual(forventetListe[i].ItemCode, resultat[i].ItemCode);
                Assert.AreEqual(forventetListe[i].ItemDesc, resultat[i].ItemDesc);
                Assert.AreEqual(forventetListe[i].InStock, resultat[i].InStock);
                Assert.AreEqual(forventetListe[i].ImgPath, resultat[i].ImgPath);
                Assert.AreEqual(forventetListe[i].Category, resultat[i].Category);
                Assert.AreEqual(forventetListe[i].Price, resultat[i].Price);
            }
        }

        // Item/GetItemsAsJson
        [TestMethod]
        public void GetItemsAsJson()
        {
            //Arrange
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));

            List<Item> forventetListe = new List<Item>();
            var Item = new Item
            {
                ItemID = 1,
                ItemCode = "DFGHJ",
                ItemDesc = "Dette er et kjempebra produkt",
                Category = 1,
                ImgPath = "",
                InStock = 5,
                Price = 100
            };
            forventetListe.Add(Item);
            forventetListe.Add(Item);
            forventetListe.Add(Item);


            //Act
            var resultat = controller.GetItemsAsJson() as JsonResult;
            dynamic data = resultat.Data;

            //Assert
            for(var i = 0; i < forventetListe.Count; i++)
            {
                Assert.AreEqual(forventetListe[i].ItemID, data[i].ItemID);
                Assert.AreEqual(forventetListe[i].ItemCode, data[i].ItemCode);
                Assert.AreEqual(forventetListe[i].ItemDesc, data[i].ItemDesc);
                Assert.AreEqual(forventetListe[i].InStock, data[i].InStock);
                Assert.AreEqual(forventetListe[i].ImgPath, data[i].ImgPath);
                Assert.AreEqual(forventetListe[i].Category, data[i].Category);
                Assert.AreEqual(forventetListe[i].Price, data[i].Price);
            }
            
        }

        // Item/Details/1
        [TestMethod]
        public void DetailsValidID()
        {
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            var forventet = new Item
            {
                ItemID = 1,
                ItemCode = "DFGHJ",
                ItemDesc = "Dette er et kjempebra produkt",
                Category = 1,
                ImgPath = "",
                InStock = 5,
                Price = 100
            };

            var actionResultat = (ViewResult)controller.Details(1);
            var resultat = (Item)actionResultat.Model;

            Assert.AreEqual(forventet.ItemID, resultat.ItemID);
            Assert.AreEqual(forventet.ItemCode, resultat.ItemCode);
            Assert.AreEqual(forventet.ItemDesc, resultat.ItemDesc);
            Assert.AreEqual(forventet.InStock, resultat.InStock);
            Assert.AreEqual(forventet.ImgPath, resultat.ImgPath);
            Assert.AreEqual(forventet.Category, resultat.Category);
            Assert.AreEqual(forventet.Price, resultat.Price);
        }


        [TestMethod]
        public void DetailsNullAsId()
        {
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            var actionResult = (HttpStatusCodeResult)controller.Details(null);

            Assert.AreEqual(actionResult.StatusCode, 400);

        }

        [TestMethod]
        public void DetailsInvalidResult()
        {
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            var actionResult = (HttpNotFoundResult)controller.Details(99);

            Assert.AreEqual(actionResult.StatusCode, 404);

        }


        //POST: Item/Create
        [TestMethod]
        public void CreateOK()
        {

            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            var forventet = new Item
            {
                ItemID = 1,
                ItemCode = "DFGHJ",
                ItemDesc = "Dette er et kjempebra produkt",
                Category = 1,
                ImgPath = "",
                InStock = 5,
                Price = 100
            };

            var actionResult = (RedirectToRouteResult)controller.Create(forventet);

            Assert.AreEqual(actionResult.RouteName, "");
            Assert.IsTrue(actionResult.RouteValues.Values.Count == 1);
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Index");
        }

        // Item/Create
        [TestMethod]
        public void CreateWithModelError()
        {
            //Arrange
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            var forventet = new Item();
            controller.ViewData.ModelState.AddModelError("ItemDesc", "");

            //Act
            var actionResult = (ViewResult)controller.Create(forventet);

        
            //Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void CreateWithDbError()
        {
            //Arrange
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            var forventet = new Item();
            forventet.ItemDesc = "";

            //Act
            var actionResult = (RedirectToRouteResult)controller.Create(forventet);

            //Assert
            Assert.AreEqual(actionResult.RouteName, "");
        }

        //GET: Item/Create
        [TestMethod]
        public void CreateGetView()
        {
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            var actionResult = (ViewResult)controller.Create();

            Assert.AreEqual(actionResult.ViewName, "");
        }


        [TestMethod]
        public void ConstructorTest()
        {
            var controller = new ItemController();
            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(Controller));
        }


        //POST: Admin/Item/Edit/5
        [TestMethod]
        public void EditValidModel()
        {
            //Arrange
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            var forventet = new Item
            {
                ItemID = 1,
                ItemCode = "DFGHJ",
                ItemDesc = "Dette er et kjempebra produkt",
                Category = 1,
                ImgPath = "",
                InStock = 5,
                Price = 100
            };

            //Act
            var actionResult = (RedirectToRouteResult)controller.Edit(forventet);

            //Assert
            Assert.AreEqual(actionResult.RouteName, "");
            Assert.IsTrue(actionResult.RouteValues.Values.Count == 1);
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Index");

        }


        //POST
        [TestMethod]
        public void EditModelStateInvalid()
        {
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            var forventet = new Item();
            controller.ModelState.AddModelError("ItemDesc", "");

            //Act
            var actionResult = (ViewResult)controller.Edit(forventet);
            
            //Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewName, "");
        }

        //GET
        [TestMethod]
        public void EditGetViewPassing()
        {
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));

            //Act
            var actionResult = (ViewResult)controller.Edit(1);

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");

        }

        //GET
        [TestMethod]
        public void EditGetViewWrongId()
        {
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            //Act
            var actionResult = (HttpNotFoundResult)controller.Edit(99);
            Assert.AreEqual(actionResult.StatusCode, 404);
        }


        //GET: /Admin/Item/Delete/5
        [TestMethod]
        public void DeleteGetView()
        {
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            var actionResult = (ViewResult)controller.Delete(1);

            Assert.AreEqual(actionResult.ViewName, "");
            Assert.IsNotNull(actionResult.Model);
        }


        //GET: /Admin/Item/Delete/5
        [TestMethod]
        public void DeleteGetViewBadId()
        {
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            var result = (HttpStatusCodeResult)controller.Delete(null);

            Assert.AreEqual(result.StatusCode, 400);
        }


        //POST: /Admin/Item/Delete/5
        [TestMethod]
        public void DeleteValidId()
        {
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            var actionResult = (RedirectToRouteResult)controller.DeleteConfirmed(1);

            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Index");
        }



        //POST: /Admin/Item/Delete/5
        [TestMethod]
        public void DeleteNotValidId()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            SessionMock.InitializeController(controller);
            var actionResult = (ViewResult)controller.DeleteConfirmed(99);

            Assert.AreEqual(actionResult.ViewName, "");
        }

     
        //POST: /Admin/Item/UpdateItemStock/5/10
        [TestMethod]
        public void UpdateItemStockValid()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            SessionMock.InitializeController(controller);

            var actionResult = (RedirectToRouteResult)controller.UpdateItemStock(1, 10);

            Assert.AreEqual(actionResult.RouteName, "");
            Assert.AreEqual(controller.Session["MsgType"], "SUCCESS");
        }

        //POST: /Admin/Item/UpdateItemStock/5/10
        [TestMethod]
        public void UpdateItemStockInvalidId()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            SessionMock.InitializeController(controller);

            var actionResult = (RedirectToRouteResult)controller.UpdateItemStock(-2, 10);

            Assert.AreEqual(actionResult.RouteName, "");
            Assert.AreEqual(controller.Session["MsgType"], "FAIL");
        }


        //POST: /Admin/Item/UpdateItemStock/5/10
        [TestMethod]
        public void UpdateItemStockReturnNullObject()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new ItemController(new ItemBLL(new ItemServiceStub()));
            SessionMock.InitializeController(controller);

            var actionResult = (HttpNotFoundResult)controller.UpdateItemStock(99, 10);

            Assert.AreEqual(actionResult.StatusCode, 404);
            
        }
    }
}
