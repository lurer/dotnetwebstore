using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using BOL.Models;
using DAL.DBOperations.DataServiceStubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using s198599.Areas.Admin.Controllers;
using BLL.BussinessObjectOperations;

namespace UnitTests.AdminTests
{
    [TestClass]
    public class OrderControllerTest
    {

        [TestMethod]
        public void ConstructorTest()
        {
            var controller = new OrderController();
            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(Controller));
        }


        //GET: /Order/Index
        [TestMethod]
        public void GetOrderList()
        {
            //Arrange
            var controller = new OrderController(new OrderBLL(new OrderServiceStub()));
            var order = new Order
            {
                OrderNumber = 1,
                DateTime = DateTime.Now,
                OrderPriceTotal = 100,

                User = new User
                {
                    UserID = 1,
                    FirstName = "Espen",
                    LastName = "Zaal",
                    Address = "Osloveien 123",
                    PostCode = "1234",
                    PostAddress = "Oslo",
                    Email = "test@test.no",
                    Orders = new List<Order>(),
                    Password = "Letmein",
                    RoleId = 1,
                    RoleStringId = "C",
                    Telephone = "22334455"
                },
                Items = new List<OrderLine>()

            };


            //Act
            List<Order> forventetListe = new List<Order>();
            forventetListe.Add(order);
            forventetListe.Add(order);
            forventetListe.Add(order);

            var actionResult = (ViewResult)controller.Index();
            var resultat = (List<Order>)actionResult.Model;
            
            //Assert
            for(var i = 0; i < forventetListe.Count; i++)
            {
                Assert.AreEqual(forventetListe[i].OrderNumber, resultat[i].OrderNumber);
                Assert.AreEqual(forventetListe[i].OrderPriceTotal, resultat[i].OrderPriceTotal);
                
                var forventetUser = forventetListe[i].User;
                var resUser = resultat[i].User;
                Assert.AreEqual(forventetUser.UserID, resUser.UserID);
                Assert.AreEqual(forventetUser.FirstName, resUser.FirstName);
                Assert.AreEqual(forventetUser.LastName, resUser.LastName);
                Assert.AreEqual(forventetUser.Address, resUser.Address);
                Assert.AreEqual(forventetUser.PostCode, resUser.PostCode);
                Assert.AreEqual(forventetUser.PostAddress, resUser.PostAddress);
                Assert.AreEqual(forventetUser.Email, resUser.Email);
                Assert.AreEqual(forventetUser.Password, resUser.Password);
                Assert.AreEqual(forventetUser.RoleId, resUser.RoleId);
                Assert.AreEqual(forventetUser.RoleStringId, resUser.RoleStringId);
                Assert.AreEqual(forventetUser.Telephone, resUser.Telephone);

                var forventetItems = forventetListe[i].Items;
                var resItems = resultat[i].Items;

            }

            Assert.AreEqual(actionResult.ViewName, "");
        }


        //GET: /Order/Details/5
        [TestMethod]
        public void OrderDetailsValid()
        {
            var controller = new OrderController(new OrderBLL(new OrderServiceStub()));
            var actionResult = (ViewResult)controller.Details(1);

            Assert.AreEqual(actionResult.ViewName, "");
        }


        [TestMethod]
        public void OrderDetailsNullAsId()
        {
            var controller = new OrderController(new OrderBLL(new OrderServiceStub()));
            var actionResult = (HttpStatusCodeResult)controller.Details(null);
            Assert.AreEqual(actionResult.StatusCode, 400);
        }


        [TestMethod]
        public void OrderDetailsInvalidId()
        {
            var controller = new OrderController(new OrderBLL(new OrderServiceStub()));
            var actionResult = (HttpStatusCodeResult)controller.Details(99);
            Assert.AreEqual(actionResult.StatusCode, 404);
        }


        //GET: /Order/Create
        [TestMethod]
        public void ReturnCreateView()
        {
            var controller = new OrderController(new OrderBLL(new OrderServiceStub()));
            var actionResult = (ViewResult)controller.Create();
            Assert.AreEqual(actionResult.ViewName, "");
        }

    }
}
