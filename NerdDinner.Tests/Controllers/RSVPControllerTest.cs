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
	public class RSVPControllerTest
	{
		[TestMethod]
		[ExpectedException(typeof(SecurityException))]
		public void Register_Should_Raise_Unauthorised_Error()
		{

			// Arrange
			var testData = FakeDinnerData.CreateTestDinners();
			var repository = new FakeDinnerRepository(testData);
			var controller = new RSVPController(repository);

			// Act
			controller.Register(1);
		}

		[TestMethod]
		public void Register_Should_Add_RSVP()
		{
			// Arrange
			Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("SomeOtherUser"), null);
			var testData = FakeDinnerData.CreateTestDinners();
			var repository = new FakeDinnerRepository(testData);
			var controller = new RSVPController(repository);

			// Act
			controller.Register(1);

			// Assert
			Assert.AreEqual(2, repository.GetDinner(1).RSVPs.Count());
			Assert.AreEqual("SomeOtherUser", repository.GetDinner(1).RSVPs[1].AttendeeName);
		}
	}
}
