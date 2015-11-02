using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.BussinessObjectOperations;
using BOL.Models;
using DAL.DBOperations.DataServiceStubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using s198599.Areas.Admin.Controllers;

namespace UnitTests.AdminTests
{
    [TestClass]
    public class RolesControllerTest
    {

        [TestMethod]
        public void ConstructorTest()
        {
            var controller = new RolesController();
            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(Controller));
        }


        //GET: /Roles/Index
        [TestMethod]
        public void GetRoleList()
        {
            var controller = new RolesController(new UserRoleBLL(new RoleServiceStub()));

            var role = new Role { RoleId = 1, RoleStringId = "C", RoleName = "Customer" };
            List<Role> forventet = new List<Role>();
            forventet.Add(role);
            forventet.Add(role);
            forventet.Add(role);

            var actionResult = (ViewResult)controller.Index();
            var result = (List<Role>)actionResult.Model;

            Assert.AreEqual(actionResult.ViewName, "");
            for(var i = 0; i < forventet.Count; i++)
            {
                Assert.AreEqual(forventet[i].RoleId, result[i].RoleId);
                Assert.AreEqual(forventet[i].RoleStringId, result[i].RoleStringId);
                Assert.AreEqual(forventet[i].RoleName, result[i].RoleName);
            }
        }


        //GET: Roles/Create
        [TestMethod]
        public void CreateGetView()
        {
            var controller = new RolesController(new UserRoleBLL(new RoleServiceStub()));
            var actionResult = (ViewResult)controller.Create();
            Assert.AreEqual(actionResult.ViewName, "");
        }


        //POST: /Roles/Create/role
        [TestMethod]
        public void CreateWithValidId()
        {
            var controller = new RolesController(new UserRoleBLL(new RoleServiceStub()));
            var role = new Role { RoleId = 1, RoleStringId = "C", RoleName = "Customer" };

            var actionResult = (RedirectToRouteResult)controller.Create(role);

            Assert.AreEqual(actionResult.RouteName, "");
            Assert.IsTrue(actionResult.RouteValues.Values.Count == 1);
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Index");

        }


        //POST
        [TestMethod]
        public void CreateWithInvalidModel()
        {
            var controller = new RolesController(new UserRoleBLL(new RoleServiceStub()));
            var role = new Role();
            controller.ViewData.ModelState.AddModelError("RoleName", "");
            var actionResult = (ViewResult)controller.Create(role);
            Assert.AreEqual(actionResult.ViewName, "");
        }


        //GET: /Roles/5
        [TestMethod]
        public void EditGetViewValidId()
        {
            var controller = new RolesController(new UserRoleBLL(new RoleServiceStub()));
            var actionResult = (ViewResult)controller.Edit(1);
            Assert.AreEqual(actionResult.ViewName, "");
        
        }


        //GET: /Roles/5
        [TestMethod]
        public void EditGetViewInvalidId()
        {
            var controller = new RolesController(new UserRoleBLL(new RoleServiceStub()));
            var actionResult = (HttpNotFoundResult)controller.Edit(99);
            Assert.AreEqual(actionResult.StatusCode, 404);
        }


        //POST: /Roles/5
        [TestMethod]
        public void EditValidModel()
        {
            var controller = new RolesController(new UserRoleBLL(new RoleServiceStub()));
            var role = new Role { RoleId = 1, RoleStringId = "C", RoleName = "Customer" };

            var actionResult = (RedirectToRouteResult)controller.Edit(role);
            Assert.AreEqual(actionResult.RouteName, "");
            Assert.IsTrue(actionResult.RouteValues.Values.Count == 1);
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Index");
        }


        //POST
        [TestMethod]
        public void EditInvalidModel()
        {
            var controller = new RolesController(new UserRoleBLL(new RoleServiceStub()));
            var role = new Role();
            controller.ViewData.ModelState.AddModelError("RoleName", "");

            var actionResult = (ViewResult)controller.Edit(role);
            Assert.AreEqual(actionResult.ViewName, "");
        }


        //GET: /Roles/5
        [TestMethod]
        public void DeleteGetViewWithValidId()
        {
            var controller = new RolesController(new UserRoleBLL(new RoleServiceStub()));
            var actionResult = (ViewResult)controller.Delete(1);
            Assert.AreEqual(actionResult.ViewName, "");
            
        }

        //GET: /Roles/null
        [TestMethod]
        public void DeleteGetViewWithNullId()
        {
            var controller = new RolesController(new UserRoleBLL(new RoleServiceStub()));
            var actionResult = (HttpStatusCodeResult)controller.Delete(null);
            Assert.AreEqual(actionResult.StatusCode, 400);
        }



        //GET: /Roles/99
        [TestMethod]
        public void DeleteGetViewWithInvalidId()
        {
            var controller = new RolesController(new UserRoleBLL(new RoleServiceStub()));
            var actionResult = (HttpNotFoundResult)controller.Delete(99);
            Assert.AreEqual(actionResult.StatusCode, 404);
        }


        //POST: /Roles/5
        [TestMethod]
        public void DeleteRoleValidId()
        {
            var controller = new RolesController(new UserRoleBLL(new RoleServiceStub()));
            var actionResult = (RedirectToRouteResult)controller.DeleteConfirmed(1);
            Assert.AreEqual(actionResult.RouteName, "");
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Index");
        }


        //POST
        [TestMethod]
        public void DeleteInvalidId()
        {
            var controller = new RolesController(new UserRoleBLL(new RoleServiceStub()));
            var actionResult = (ViewResult)controller.DeleteConfirmed(99);
            Assert.AreEqual(actionResult.ViewName, "");
        }
    }
}
