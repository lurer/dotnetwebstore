using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;
using BLL.BussinessObjectOperations;
using BOL.Models;
using DAL.DBOperations.DataServiceStubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using s198599.Areas.Admin.Controllers;
using MvcContrib.TestHelper;

namespace UnitTests.AdminTests
{

    [TestClass]
    public class UserControllerTest
    {

        [TestMethod]
        public void ConstructorTest()
        {
            var controller = new UserController();
            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(Controller));
        }


        //GET: /Users/
        [TestMethod]
        public void GetUserList()
        {
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            var User = new User
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
            };
            List<User> forventet = new List<User>();
            forventet.Add(User);
            forventet.Add(User);
            forventet.Add(User);


            var actionResult = (ViewResult)controller.Index();
            var result = (List<User>)actionResult.Model;

            Assert.AreEqual(actionResult.ViewName, "");
            for(var i = 0; i < forventet.Count; i++)
            {
                Assert.AreEqual(forventet[i].UserID, result[i].UserID);
                Assert.AreEqual(forventet[i].FirstName, result[i].FirstName);
                Assert.AreEqual(forventet[i].LastName, result[i].LastName);
                Assert.AreEqual(forventet[i].Address, result[i].Address);
                Assert.AreEqual(forventet[i].PostCode, result[i].PostCode);
                Assert.AreEqual(forventet[i].PostAddress, result[i].PostAddress);
                Assert.AreEqual(forventet[i].Email, result[i].Email);
                Assert.AreEqual(forventet[i].Password, result[i].Password);
                Assert.AreEqual(forventet[i].RoleId, result[i].RoleId);
                Assert.AreEqual(forventet[i].RoleStringId, result[i].RoleStringId);
                Assert.AreEqual(forventet[i].Telephone, result[i].Telephone);
            }
        }


        //GET: /User/Create
        [TestMethod]
        public void CreateGetView()
        {
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            var actionResult = (ViewResult)controller.Create();
            Assert.AreEqual(actionResult.ViewName, "");
        }


        //POST: /User/Create/model
        [TestMethod]
        public void CreateValidModel()
        {
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            var User = new User
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
            };

            var actionResult = (RedirectToRouteResult)controller.Create(User);
            Assert.AreEqual(actionResult.RouteName, "");
            Assert.IsTrue(actionResult.RouteValues.Values.Count == 1);
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Index");

        }


        //POST: /User/Create/model
        [TestMethod]
        public void CreateInvalidModel()
        {
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            var User = new User();
            controller.ModelState.AddModelError("FirstName", "");

            var actionResult = (ViewResult)controller.Create(User);
            Assert.AreEqual(actionResult.ViewName, "");
        }


        //GET: /User/Details/5
        [TestMethod]
        public void GetUserDetailsValidId()
        {
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            var actionResult = (ViewResult)controller.Details(1);
            Assert.AreEqual(actionResult.ViewName, "");

        }


        //GET: /User/Details/5
        [TestMethod]
        public void GetUserDetailsIdIsNull()
        {
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            var actionResult = (HttpStatusCodeResult)controller.Details(null);
            Assert.AreEqual(actionResult.StatusCode, 400);

        }

        //GET: /User/Details/5
        [TestMethod]
        public void GetUserDetailsIdInvalid()
        {
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            var actionResult = (HttpNotFoundResult)controller.Details(99);
            Assert.AreEqual(actionResult.StatusCode, 404);

        }


        //GET: /User/Edit/5
        [TestMethod]
        public void EditGetViewValidId()
        {
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            var actionResult = (ViewResult)controller.Edit(1);
            Assert.AreEqual(actionResult.ViewName, "");

        }


        //GET: /User/Edit/5
        [TestMethod]
        public void EditGetViewInvalidId()
        {
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            var actionResult = (HttpNotFoundResult)controller.Edit(99);
            Assert.AreEqual(actionResult.StatusCode, 404);

        }


        //POST: /User/Edit/5
        [TestMethod]
        public void EditValidModel()
        {
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            var User = new User
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
            };

            var actionResult = (RedirectToRouteResult)controller.Edit(User);
            Assert.AreEqual(actionResult.RouteName, "");
            Assert.IsTrue(actionResult.RouteValues.Values.Count == 1);
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Index");

        }


        //POST: /User/Edit/5
        [TestMethod]
        public void EditInvalidModel()
        {
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            var User = new User();
            controller.ModelState.AddModelError("FirstName", "");
            var actionResult = (ViewResult)controller.Edit(User);
            Assert.AreEqual(actionResult.ViewName, "");
        }


        //GET: /User/Delete/5
        [TestMethod]
        public void DeleteGetValid()
        {
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            var actionResult = (ViewResult)controller.Delete(1);
            Assert.AreEqual(actionResult.ViewName, "");

        }


        //GET:
        [TestMethod]
        public void DeleteGetNoId()
        {
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            var actionResult = (HttpStatusCodeResult)controller.Delete(null);
            Assert.AreEqual(actionResult.StatusCode, 400);
        }


        //GET:
        [TestMethod]
        public void DeleteGetInvalidId()
        {
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            var actionResult = (HttpNotFoundResult)controller.Delete(99);
            Assert.AreEqual(actionResult.StatusCode, 404);
        }


        //POST: /User/Delete/5
        [TestMethod]
        public void DeleteValidId()
        {
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            var actionResult = (RedirectToRouteResult)controller.DeleteConfirmed(1);
            Assert.AreEqual(actionResult.RouteName, "");
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Index");
            Assert.IsTrue(actionResult.RouteValues.Values.Count == 1);
        }


        //POST: /USer/Delete/5
        [TestMethod]
        public void DeleteInvalidId()
        {
            var SessionMock = new TestControllerBuilder();
            var controller = new UserController(new UserBLL(new UserServiceStub()));
            SessionMock.InitializeController(controller);
            var actionResult = (ViewResult)controller.DeleteConfirmed(99);
            Assert.AreEqual(actionResult.ViewName, "");
        }
    }
}
