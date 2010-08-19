using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Navigation;

namespace NerdDinner.Tests.Navigation
{
	[TestClass]
	public class NavigationTest
	{
		[TestMethod]
		public void Home_Should_Navigate_FindDinner()
		{
			//Act
			StateController.Navigate("Home");

			//Assert
			Assert.AreEqual("FindDinner", StateContext.State.Key);
			Assert.AreEqual("~/Views/Home/Index.aspx", StateContext.State.Page);
		}

		[TestMethod]
		public void LogOn_Should_Navigate_Page()
		{
			//Act
			StateController.Navigate("LogOn");

			//Assert
			Assert.AreEqual("Page", StateContext.State.Key);
			Assert.AreEqual("~/Views/Account/LogOn.aspx", StateContext.State.Page);
		}

		[TestMethod]
		public void Register_Should_Navigate_Page()
		{
			//Act
			StateController.Navigate("Register");

			//Assert
			Assert.AreEqual("Page", StateContext.State.Key);
			Assert.AreEqual("~/Views/Account/Register.aspx", StateContext.State.Page);
		}

		[TestMethod]
		public void About_Should_Navigate_Page()
		{
			//Act
			StateController.Navigate("About");

			//Assert
			Assert.AreEqual("Page", StateContext.State.Key);
			Assert.AreEqual("~/Views/Home/About.aspx", StateContext.State.Page);
		}

		[TestMethod]
		public void Dinners_Should_Navigate_Upcoming()
		{
			//Act
			StateController.Navigate("Dinners");

			//Assert
			Assert.AreEqual("Upcoming", StateContext.State.Key);
			Assert.AreEqual("~/Views/Dinners/Index.aspx", StateContext.State.Page);
		}

		[TestMethod]
		public void HostDinner_Should_Navigate_Create()
		{
			//Act
			StateController.Navigate("HostDinner");

			//Assert
			Assert.AreEqual("Create", StateContext.State.Key);
			Assert.AreEqual("~/Views/Dinners/Create.aspx", StateContext.State.Page);
		}

		[TestMethod]
		public void MaintainDinner_Should_Navigate_Details()
		{
			//Act
			StateController.Navigate("MaintainDinner");

			//Assert
			Assert.AreEqual("Details", StateContext.State.Key);
			Assert.AreEqual("~/Views/Dinners/Details.aspx", StateContext.State.Page);
		}

		[TestMethod]
		public void MaintainDinner_Details_NotFound_Should_Navigate_NotFound()
		{
			// Arrange
			StateController.Navigate("MaintainDinner");

			//Act
			StateController.Navigate("NotFound");

			//Assert
			Assert.AreEqual("NotFound", StateContext.State.Key);
			Assert.AreEqual("~/Views/Dinners/NotFound.aspx", StateContext.State.Page);
		}

		[TestMethod]
		public void MaintainDinner_Details_Edit_Should_Navigate_Details()
		{
			// Arrange
			StateController.Navigate("MaintainDinner");

			//Act
			StateController.Navigate("Edit");

			//Assert
			Assert.AreEqual("Edit", StateContext.State.Key);
			Assert.AreEqual("~/Views/Dinners/Edit.aspx", StateContext.State.Page);
		}

		[TestMethod]
		public void MaintainDinner_Details_Delete_Should_Navigate_Delete()
		{
			// Arrange
			StateController.Navigate("MaintainDinner");

			//Act
			StateController.Navigate("Delete");

			//Assert
			Assert.AreEqual("Delete", StateContext.State.Key);
			Assert.AreEqual("~/Views/Dinners/Delete.aspx", StateContext.State.Page);
		}

		[TestMethod]
		public void MaintainDinner_Edit_NotFound_Should_Navigate_NotFound()
		{
			// Arrange
			StateController.Navigate("MaintainDinner");
			StateController.Navigate("Edit");

			//Act
			StateController.Navigate("NotFound");

			//Assert
			Assert.AreEqual("NotFound", StateContext.State.Key);
			Assert.AreEqual("~/Views/Dinners/NotFound.aspx", StateContext.State.Page);
		}

		[TestMethod]
		public void MaintainDinner_Edit_InvalidOwner_Should_Navigate_InvalidOwner()
		{
			// Arrange
			StateController.Navigate("MaintainDinner");
			StateController.Navigate("Edit");

			//Act
			StateController.Navigate("InvalidOwner");

			//Assert
			Assert.AreEqual("InvalidOwner", StateContext.State.Key);
			Assert.AreEqual("~/Views/Dinners/InvalidOwner.aspx", StateContext.State.Page);
		}

		[TestMethod]
		public void MaintainDinner_Delete_Confirm_Should_Navigate_Deleted()
		{
			// Arrange
			StateController.Navigate("MaintainDinner");
			StateController.Navigate("Delete");

			//Act
			StateController.Navigate("Confirm");

			//Assert
			Assert.AreEqual("Deleted", StateContext.State.Key);
			Assert.AreEqual("~/Views/Dinners/Deleted.aspx", StateContext.State.Page);
		}

		[TestMethod]
		public void MaintainDinner_Delete_NotFound_Should_Navigate_NotFound()
		{
			// Arrange
			StateController.Navigate("MaintainDinner");
			StateController.Navigate("Delete");

			//Act
			StateController.Navigate("NotFound");

			//Assert
			Assert.AreEqual("NotFound", StateContext.State.Key);
			Assert.AreEqual("~/Views/Dinners/NotFound.aspx", StateContext.State.Page);
		}

		[TestMethod]
		public void MaintainDinner_Delete_InvalidOwner_Should_Navigate_InvalidOwner()
		{
			// Arrange
			StateController.Navigate("MaintainDinner");
			StateController.Navigate("Delete");

			//Act
			StateController.Navigate("InvalidOwner");

			//Assert
			Assert.AreEqual("InvalidOwner", StateContext.State.Key);
			Assert.AreEqual("~/Views/Dinners/InvalidOwner.aspx", StateContext.State.Page);
		}
	}
}
