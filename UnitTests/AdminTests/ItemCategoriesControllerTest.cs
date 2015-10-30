using BLL.BussinessObjectOperations;
using BOL.Models;
using DAL.DBOperations.DataServiceStubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using s198599.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UnitTests.AdminTests
{
    [TestClass]
    public class ItemCategoriesControllerTest
    {


        [TestMethod]
        public void ConstructorTest()
        {
            var controller = new ItemCategoriesController();
            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(Controller));
        }


        //GET: /ItemCategories/Index
        [TestMethod]
        public void ItemCategoryList()
        {
            var controller = new ItemCategoriesController(new CategoryBLL(new CategoryServiceStub()));
            List<ItemCategory> forventetListe = new List<ItemCategory>();
            var ItemCat = new ItemCategory
            {
                CategoryId = 1,
                CategoryName = "TestCategory"
            };
            forventetListe.Add(ItemCat);
            forventetListe.Add(ItemCat);
            forventetListe.Add(ItemCat);

            var actionResultat = (ViewResult)controller.Index();
            var resultat = (List<ItemCategory>)actionResultat.Model;

            Assert.AreEqual(actionResultat.ViewName, "");

            for(var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetListe[i].CategoryId, resultat[i].CategoryId);
                Assert.AreEqual(forventetListe[i].CategoryName, resultat[i].CategoryName);
            }
        }


        //GET: /ItemCategories/Create
        [TestMethod]
        public void CreateGetView()
        {
            var controller = new ItemCategoriesController(new CategoryBLL(new CategoryServiceStub()));
            var actionResult = (ViewResult)controller.Create();
            Assert.AreEqual(actionResult.ViewName, "");
        }


        //POST: /ItemCategories/Create/5
        [TestMethod]
        public void CreateModelOK()
        {
            var controller = new ItemCategoriesController(new CategoryBLL(new CategoryServiceStub()));
            var forventet = new ItemCategory
            {
                CategoryId = 1,
                CategoryName = "TestCategory"
            };

            var actionResult = (RedirectToRouteResult)controller.Create(forventet);

            Assert.AreEqual(actionResult.RouteName, "");
            Assert.IsTrue(actionResult.RouteValues.Values.Count == 1);
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Index");
        }


        //POST: 
        [TestMethod]
        public void CreateModelInvalid()
        {
            var controller = new ItemCategoriesController(new CategoryBLL(new CategoryServiceStub()));
            var forventet = new ItemCategory();
            controller.ViewData.ModelState.AddModelError("CategoryName", "");

            var actionResult = (ViewResult)controller.Create(forventet);
            Assert.AreEqual(actionResult.ViewName, "");
            
        }



        //GET: /ItemCategories/Edit
        [TestMethod]
        public void EditGetViewPassing()
        {
            var controller = new ItemCategoriesController(new CategoryBLL(new CategoryServiceStub()));

            //Act
            var actionResult = (ViewResult)controller.Edit(1);

            //Assert
            Assert.AreEqual(actionResult.ViewName, "");

        }


        //GET: /ItemCategories/Edit/null
        [TestMethod]
        public void EditGetViewIdNull()
        {
            var controller = new ItemCategoriesController(new CategoryBLL(new CategoryServiceStub()));
            var actionResult = (HttpNotFoundResult)controller.Edit(99);

            Assert.AreEqual(actionResult.StatusCode, 404);
        }



        //POST: /ItemCategories/Edit/5
        [TestMethod]
        public void EditItemCategoryValidModel()
        {
            var controller = new ItemCategoriesController(new CategoryBLL(new CategoryServiceStub()));
            var forventet = new ItemCategory
            {
                CategoryId = 1,
                CategoryName = "TestCategory"
            };

            var actionResult = (RedirectToRouteResult)controller.Edit(forventet);

            Assert.AreEqual(actionResult.RouteName, "");
            Assert.IsTrue(actionResult.RouteValues.Values.Count == 1);
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Index");
        }


        //POST: /ItemCategories/Edit/5
        [TestMethod]
        public void EditItemCategoryInvalidModel()
        {
            var controller = new ItemCategoriesController(new CategoryBLL(new CategoryServiceStub()));
            var forventet = new ItemCategory();
            controller.ViewData.ModelState.AddModelError("CategoryName", "");

            var actionResult = (ViewResult)controller.Edit(forventet);

            Assert.AreEqual(actionResult.ViewName, "");
            
        }

        //GET: /ItemCategories/Delete/5
        [TestMethod]
        public void DeleteGetView()
        {
            var controller = new ItemCategoriesController(new CategoryBLL(new CategoryServiceStub()));
            var actionResult = (ViewResult)controller.Delete(1);
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.IsNotNull(actionResult.Model);
        }

        //GET: /ItemCategories/Delete/5
        [TestMethod]
        public void DeleteGetViewBadId()
        {
            var controller = new ItemCategoriesController(new CategoryBLL(new CategoryServiceStub()));
            var actionResult = (HttpStatusCodeResult)controller.Delete(99);
            Assert.AreEqual(actionResult.StatusCode, 404);
        }


        //POST: /ItemCategories/Delete/5
        [TestMethod]
        public void DeletePassingId()
        {
            var controller = new ItemCategoriesController(new CategoryBLL(new CategoryServiceStub()));
            var actionResult = (RedirectToRouteResult)controller.DeleteConfirmed(1);
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Index");
        }

        //POST: /ItemCategories/Delete/99
        [TestMethod]
        public void DeleteNotValidId()
        {
            var controller = new ItemCategoriesController(new CategoryBLL(new CategoryServiceStub()));
            var actionResult = (RedirectToRouteResult)controller.DeleteConfirmed(99);
            Assert.AreEqual(actionResult.RouteName, "");
        }
        

        
        //POST: /ItemCategories/GetCategoryName/5
        [TestMethod]
        public void GetCategoryNameValidId()
        {
            var controller = new ItemCategoriesController(new CategoryBLL(new CategoryServiceStub()));
            var actionResult = controller.GetCategoryName(1);

            Assert.AreEqual(actionResult, "TestCategory");
        }


        ////POST: /ItemCategories/GetCategoryName/5
        //public void GetCategoryNameInvalidId()
        //{
        //    var controller = new ItemCategoriesController(new CategoryBLL(new CategoryServiceStub()));
        //    var actionResult = controller.GetCategoryName(99);

        //    Assert.IsNull(actionResult);
        //}


        //GET: /ItemCategories/getCategoryNameList
        [TestMethod]
        public void getCategoryNameList()
        {
            var controller = new ItemCategoriesController(new CategoryBLL(new CategoryServiceStub()));

            List<ItemCategory> forventetListe = new List<ItemCategory>();
            var ItemCat = new ItemCategory
            {
                CategoryId = 1,
                CategoryName = "TestCategory"
            };
            forventetListe.Add(ItemCat);
            forventetListe.Add(ItemCat);
            forventetListe.Add(ItemCat);

            var actionResult = controller.getCategoryNameList();

            Assert.IsNotNull(actionResult.Data);
        }

    }
}
