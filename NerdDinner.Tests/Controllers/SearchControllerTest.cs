using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Navigation;
using NerdDinner.Controllers;
using NerdDinner.Models;
using NerdDinner.Tests.Fakes;

namespace NerdDinner.Tests.Controllers
{
	[TestClass]
	public class SearchControllerTest
	{
		SearchController CreateSearchController()
		{
			var testData = FakeDinnerData.CreateTestDinners();
			var repository = new FakeDinnerRepository(testData);

			return new SearchController(repository);
		}

		[TestMethod]
		public void SearchByLocationAction_Should_Return_JsonDinners()
		{
			// Arrange
			var controller = CreateSearchController();

			// Act
			var result = controller.SearchByLocation(99, -99);

			// Assert
			Assert.AreEqual(101, result.Count);
		}

	}
}
