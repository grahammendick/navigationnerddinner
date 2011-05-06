using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Navigation;
using NerdDinner.Controllers;
using NerdDinner.Models;
using NerdDinner.Tests.Fakes;
using System.Threading;
using System.Security.Principal;
using System.Security;

namespace NerdDinner.Tests.Controllers
{
	[TestClass]
	public class DinnersControllerTest
	{
		DinnersController CreateDinnersController()
		{
			var testData = FakeDinnerData.CreateTestDinners();
			var repository = new FakeDinnerRepository(testData);

			return new DinnersController(repository);
		}

		[TestMethod]
		public void GetDetails_Should_Return_Dinner()
		{

			// Arrange
			StateController.Navigate("MaintainDinner");
			var controller = CreateDinnersController();

			// Act
			var dinner = controller.GetDetails(1);

			// Assert
			Assert.AreEqual("Sample Dinner", dinner.Title);
		}

		[TestMethod]
		public void GetDetails_Should_Navigate_NotFound_For_BogusDinner()
		{

			// Arrange
			StateController.Navigate("MaintainDinner");
			var controller = CreateDinnersController();

			// Act
			var dinner = controller.GetDetails(999);

			// Assert
			Assert.AreEqual("NotFound", StateContext.State.Key);
		}

		[TestMethod]
		public void Details_Should_Return_Dinner()
		{

			// Arrange
			StateController.Navigate("MaintainDinner");
			var controller = CreateDinnersController();

			// Act
			var dinner = controller.Details(1);

			// Assert
			Assert.AreEqual("Sample Dinner", dinner.Dinner.Title);
		}

		[TestMethod]
		public void Details_Should_Navigate_NotFound_For_BogusDinner()
		{

			// Arrange
			StateController.Navigate("MaintainDinner");
			var controller = CreateDinnersController();

			// Act
			var dinner = controller.Details(999);

			// Assert
			Assert.AreEqual("NotFound", StateContext.State.Key);
		}

		[TestMethod]
		[ExpectedException(typeof(SecurityException))]
		public void Edit_Should_Raise_Unauthorised_Error()
		{

			// Arrange
			StateController.Navigate("MaintainDinner");
			StateController.Navigate("Edit");
			var controller = CreateDinnersController();

			// Act
			controller.Edit(new Dinner() { DinnerID = 999 });
		}

		[TestMethod]
		public void Edit_Should_Navigate_NotFound_For_BogusDinner()
		{

			// Arrange
			Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("SomeUser"), null); StateController.Navigate("MaintainDinner");
			StateController.Navigate("Edit");
			var controller = CreateDinnersController();

			// Act
			controller.Edit(new Dinner() { DinnerID = 999 });

			// Assert
			Assert.AreEqual("NotFound", StateContext.State.Key);
		}

		[TestMethod]
		public void Edit_Should_Navigate_InvalidOwner_For_InValidOwner()
		{

			// Arrange
			Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("SomeOtherUser"), null);
			StateController.Navigate("MaintainDinner");
			StateController.Navigate("Edit");
			var controller = CreateDinnersController();

			// Act
			controller.Edit(new Dinner() { DinnerID = 1 });

			// Assert
			Assert.AreEqual("InvalidOwner", StateContext.State.Key);
		}

		[TestMethod]
		public void Edit_Should_Navigate_Details_When_Update_Successful()
		{

			// Arrange
			Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("SomeUser"), null);
			int id = 1;
			StateController.Navigate("MaintainDinner", new NavigationData() { { "id", id } });
			StateController.Navigate("Edit");
			var controller = CreateDinnersController();
			var dinner = FakeDinnerData.CreateDinner();
			dinner.DinnerID = id;

			// Act
			controller.Edit(dinner);

			// Assert
			Assert.AreEqual("Details", StateContext.State.Key);
			Assert.AreEqual(id, StateContext.Data["id"]);
		}

		[TestMethod]
		[ExpectedException(typeof(ApplicationException))]
		public void Edit_Should_Raise_Error_When_Update_Fails()
		{

			// Arrange
			Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("SomeUser"), null);
			var controller = CreateDinnersController();

			// Act
			controller.Edit(new Dinner() { DinnerID = 1 });
		}

		[TestMethod]
		public void Index_Should_Return_List()
		{

			// Arrange
			var controller = CreateDinnersController();

			// Act
			var result = controller.Index(0, 10);

			// Assert
			Assert.AreEqual(10, result.Count());
		}

		[TestMethod]
		public void PagedIndex_Should_Return_Paginator_With_Total_of_100_And_Total_10_Pages()
		{

			// Arrange
			var controller = CreateDinnersController();

			// Act
			var result = controller.Index(0, 10);

			// Assert
			Assert.AreEqual(100, StateContext.Data["totalRowCount"]);
			Assert.AreEqual(10, result.Count());
		}

		[TestMethod]
		public void GetCreate_Should_Return_Dinner_With_New_Dinner_7_Days_In_Future()
		{

			// Arrange
			Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("SomeUser"), null);
			var controller = CreateDinnersController();

			// Act
			var dinner = controller.GetCreate();

			// Assert
			Assert.IsTrue(dinner.EventDate > DateTime.Today.AddDays(6) && dinner.EventDate < DateTime.Today.AddDays(8));
		}

		[TestMethod]
		public void Countries_Should_Return_Countries_List()
		{

			// Arrange
			var controller = CreateDinnersController();

			// Act
			var countries = controller.Countries();

			// Assert
			int i = 0;
			foreach (object country in countries)
			{
				i++;
			}
			Assert.AreEqual(3, i);
		}

		[TestMethod]
		[ExpectedException(typeof(SecurityException))]
		public void Create_Should_Raise_Unauthorised_Error()
		{

			// Arrange
			var controller = CreateDinnersController();

			// Act
			controller.Create(new Dinner() {});
		}

		[TestMethod]
		public void Create_With_New_Dinner_Should_Navigate_Details_And_Repo_Should_Contain_New_Dinner()
		{
			// Arrange
			Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("SomeUser"), null);
			var testData = FakeDinnerData.CreateTestDinners();
			var repository = new FakeDinnerRepository(testData);
			var controller = new DinnersController(repository);
			var dinner = FakeDinnerData.CreateDinner();

			// Act
			controller.Create(dinner);

			// Assert
			Assert.AreEqual("Details", StateContext.State.Key);
			Assert.AreEqual(102, repository.FindAllDinners().Count());
		}

		[TestMethod]
		[ExpectedException(typeof(ApplicationException))]
		public void Create_Should_Raise_Error_When_Update_Fails()
		{

			// Arrange
			Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("SomeUser"), null);
			var controller = CreateDinnersController();

			// Act
			controller.Create(new Dinner() { });
		}

		[TestMethod]
		[ExpectedException(typeof(SecurityException))]
		public void Delete_Should_Raise_Unauthorised_Error()
		{

			// Arrange
			var controller = CreateDinnersController();

			// Act
			controller.Delete(new Dinner() { });
		}

		[TestMethod]
		public void Delete_Should_Navigate_NotFound_For_BogusDinner()
		{

			// Arrange
			Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("SomeUser"), null);
			StateController.Navigate("MaintainDinner");
			StateController.Navigate("Delete");
			var controller = CreateDinnersController();

			// Act
			controller.Delete(new Dinner() { DinnerID = 999 });

			// Assert
			Assert.AreEqual("NotFound", StateContext.State.Key);
		}

		[TestMethod]
		public void Delete_Should_Navigate_InvalidOwner_For_InValidOwner()
		{

			// Arrange
			Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("SomeOtherUser"), null);
			StateController.Navigate("MaintainDinner");
			StateController.Navigate("Delete");
			var controller = CreateDinnersController();

			// Act
			controller.Delete(new Dinner() { DinnerID = 1 });

			// Assert
			Assert.AreEqual("InvalidOwner", StateContext.State.Key);
		}

		[TestMethod]
		public void Delete_Should_Navigate_Deleted_When_Delete_Successful()
		{

			// Arrange
			Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("SomeUser"), null);
			int id = 1;
			StateController.Navigate("MaintainDinner", new NavigationData() { { "id", id } });
			StateController.Navigate("Delete");
			var controller = CreateDinnersController();

			// Act
			controller.Delete(new Dinner() { DinnerID = 1 });

			// Assert
			Assert.AreEqual("Deleted", StateContext.State.Key);
		}
	}
}
