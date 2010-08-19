using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Navigation;
using NerdDinner.Models;

namespace NerdDinner.Controllers
{
	public class JsonDinner
	{
		public int DinnerID { get; set; }
		public string Title { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string Description { get; set; }
		public int RSVPCount { get; set; }
		public string DetailsLink { get; set; }
	}

	public class SearchController
	{
		IDinnerRepository dinnerRepository;

		public SearchController(IDinnerRepository repository)
		{
			dinnerRepository = repository;
		}

		public List<JsonDinner> SearchByLocation(float latitude, float longitude)
		{

			var dinners = dinnerRepository.FindByLocation(latitude, longitude).ToList();

			var jsonDinners = from dinner in dinners
							  select new JsonDinner
							  {
								  DinnerID = dinner.DinnerID,
								  Latitude = dinner.Latitude,
								  Longitude = dinner.Longitude,
								  Title = dinner.Title,
								  Description = dinner.Description,
								  RSVPCount = dinner.RSVPs.Count,
								  DetailsLink = StateController.GetNavigationLink("MaintainDinner", new NavigationData() { { "id", dinner.DinnerID } }).Substring(1),
							  };

			return jsonDinners.ToList();
		}
	}
}
