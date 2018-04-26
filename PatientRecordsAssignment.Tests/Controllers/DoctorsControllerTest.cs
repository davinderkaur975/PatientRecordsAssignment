using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientRecordsAssignment.Controllers;
using Moq;
using PatientRecordsAssignment.Models;
using System.Linq;
using System.Web.Mvc;

namespace PatientRecordsAssignment.Tests.Controllers
{
    [TestClass]
    public class DoctorsControllerTest
    {
        DoctorsController controller;
        List<Doctor> doctors;
        Mock<IMockDoctorsRepository> mock;

        // set up mock data for all unit tests - runs automatically
        [TestInitialize]
        public void TestInitialize()
        {
            // instantiate new mock object
            mock = new Mock<IMockDoctorsRepository>();

            // mock order data
            doctors = new List<Doctor>
            {
                new Doctor { DoctorId = 1, Name = "FirstDoctor" },
                new Doctor { DoctorId = 2, Name = "SecondDoctor" },
                new Doctor { DoctorId = 3, Name = "ThirdDoctor" }
            };

            // populate the mock repo with the mock data
            mock.Setup(m => m.Doctors).Returns(doctors.AsQueryable());

            // inject the mock dependency when calling the controller's constructor
            controller = new DoctorsController(mock.Object);

        }
        [TestMethod]
        public void IndexViewLoads()
        {
            //arrange
            //DoctorsController controller = new DoctorsController();

            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexLoadsOrders()
        {
            // act - cast ActionResult returntype to ViewResult to access the model
            var actual = (List<Doctor>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(doctors, actual);
        }

        [TestMethod]
        public void DetailsValidId()
        {
            // act
            var actual = ((ViewResult)controller.Details(1)).Model;

            // assert
            Assert.AreEqual(doctors[0], actual);
        }

        [TestMethod]
        public void DetailsInvalidId()
        {
            // act
            //var actual = ((ViewResult)controller.Details(4)).Model;
            var actual = (ViewResult)controller.Details(4);

            // assert
            //Assert.IsNull(actual);
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DetailsNoId()
        {
            // act
            var actual = (ViewResult)controller.Details(null);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        // GET: Edit
        [TestMethod]
        public void EditGetValidId()
        {
            // act
            var actual = ((ViewResult)controller.Edit(1)).Model;

            // assert
            Assert.AreEqual(doctors[0], actual);
        }

        [TestMethod]
        public void EditGetInvalidId()
        {
            // act
            var actual = (ViewResult)controller.Edit(4);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void EditGetNoId()
        {
            // assert - must pass an int so the overload calls G not P
            int? id = null;

            // act
            var actual = (ViewResult)controller.Edit(id);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        // POST: Edit
        [TestMethod]
        public void EditPostValid()
        {
            // act - pass in the first moq ordr object
            var actual = (RedirectToRouteResult)controller.Edit(doctors[0]);

            // assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }

        [TestMethod]
        public void EditPostInvalid()
        {
            // arrange - manually set the model state to invalid
            controller.ModelState.AddModelError("key", "unit test error");

            // act - pass in the first mock order object
            var actual = (ViewResult)controller.Edit(doctors[0]);

            // assert
            Assert.AreEqual("Edit", actual.ViewName);
        }

        // GET: Create
        [TestMethod]
        public void CreateViewLoads()
        {
            // act
            var actual = (ViewResult)controller.Create();

            // assert
            Assert.AreEqual("Create", actual.ViewName);
        }

        // POST: Create
        [TestMethod]
        public void CreatePostValid()
        {
            // arrange
            Doctor o = new Doctor
            {
                Name = "Some",

            };

            // act
            var actual = (RedirectToRouteResult)controller.Create(o);

            // assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }

        [TestMethod]
        public void CreatePostInvalid()
        {
            // arrange
            Doctor o = new Doctor
            {
                Name = "Some",
            };

            controller.ModelState.AddModelError("key", "cannot add order");

            // act
            var actual = (ViewResult)controller.Create(o);

            // assert
            Assert.AreEqual("Create", actual.ViewName);
        }

        // GET: Delete
        [TestMethod]
        public void DeleteValidId()
        {
            // act
            var actual = ((ViewResult)controller.Delete(1)).Model;

            // assert
            Assert.AreEqual(doctors[0], actual);
        }

        [TestMethod]
        public void DeleteInvalidId()
        {
            // act
            var actual = (ViewResult)controller.Delete(4);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DeleteNoId()
        {
            // act
            var actual = (ViewResult)controller.Delete(null);

            // assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        // POST: Delete
        [TestMethod]
        public void DeletePostValid()
        {
            // act
            var actual = (RedirectToRouteResult)controller.DeleteConfirmed(34);

            // assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }
    }
}
