using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NerdDinner.Models;
using Navigation;
using NerdDinner.Helpers;
using System.Threading;
using System.Security.Permissions;

namespace NerdDinner.Controllers
{
	public class DinnerDetailsViewModel
	{
		public Dinner Dinner { get; private set; }
		public bool IsHost
		{
			get
			{
				return Dinner.IsHostedBy(Thread.CurrentPrincipal.Identity.Name);
			}
		}
		public bool Registered
		{
			get
			{
				return Thread.CurrentPrincipal.Identity.IsAuthenticated && Dinner.IsUserRegistered(Thread.CurrentPrincipal.Identity.Name);
			}
		}
		public bool Unregistered
		{
			get
			{
				return Thread.CurrentPrincipal.Identity.IsAuthenticated && !Dinner.IsUserRegistered(Thread.CurrentPrincipal.Identity.Name);
			}
		}
		public bool Unauthenticated
		{
			get
			{
				return !Thread.CurrentPrincipal.Identity.IsAuthenticated;
			}
		}


		public DinnerDetailsViewModel(Dinner dinner)
		{
			Dinner = dinner;
		}
	}

	public class DinnersController
	{
		IDinnerRepository dinnerRepository;

		public DinnersController(IDinnerRepository repository)
		{
			dinnerRepository = repository;
		}

		public List<Dinner> Index(int startRowIndex, int maximumRows)
		{
			var q = dinnerRepository.FindUpcomingDinners();
			StateContext.Data["totalRowCount"] = q.Count();
			return q.Skip(startRowIndex).Take(maximumRows).ToList();
		}

		public DinnerDetailsViewModel Details(int id)
		{
			return new DinnerDetailsViewModel(GetDetails(id));
		}

		public Dinner GetDetails(int id)
		{
			Dinner dinner = dinnerRepository.GetDinner(id);
			if (dinner == null)
				StateController.Navigate("NotFound");
			return dinner;
		}

		[PrincipalPermission(SecurityAction.Demand)]
		public void Edit(Dinner dinner)
		{
			Dinner oldDinner = GetDetails(dinner.DinnerID);
			if (oldDinner == null) return;
			if (!oldDinner.IsHostedBy(Thread.CurrentPrincipal.Identity.Name))
			{
				StateController.Navigate("InvalidOwner");
				return;
			}
			oldDinner.Title = dinner.Title;
			oldDinner.EventDate = dinner.EventDate;
			oldDinner.Description = dinner.Description;
			oldDinner.Address = dinner.Address;
			oldDinner.Country = dinner.Country;
			oldDinner.ContactPhone = dinner.ContactPhone;
			oldDinner.Latitude = dinner.Latitude;
			oldDinner.Longitude = dinner.Longitude;
			dinnerRepository.Save();
			StateController.NavigateBack(1);
		}

		[PrincipalPermission(SecurityAction.Demand)]
		public Dinner GetCreate()
		{
			return new Dinner()
			{
				EventDate = DateTime.Now.AddDays(7),
				Country = "USA"
			};
		}

		[PrincipalPermission(SecurityAction.Demand)]
		public void Create(Dinner dinner)
		{
			dinner.HostedBy = Thread.CurrentPrincipal.Identity.Name;
			RSVP rsvp = new RSVP();
			rsvp.AttendeeName = Thread.CurrentPrincipal.Identity.Name;
			dinner.RSVPs.Add(rsvp);
			dinnerRepository.Add(dinner);
			dinnerRepository.Save();
			StateController.Navigate("MaintainDinner", new NavigationData() { { "id", dinner.DinnerID } });
		}

		[PrincipalPermission(SecurityAction.Demand)]
		public void Delete(Dinner dinner)
		{
			dinner = GetDetails(dinner.DinnerID);
			if (dinner == null) return;
			if (!dinner.IsHostedBy(Thread.CurrentPrincipal.Identity.Name))
			{
				StateController.Navigate("InvalidOwner");
				return;
			}
			dinnerRepository.Delete(dinner);
			dinnerRepository.Save();
			StateController.Navigate("Confirm");
		}

		public IEnumerable<KeyValuePair<string, string>> Countries()
		{
			foreach (string country in PhoneValidator.Countries)
				yield return new KeyValuePair<string, string>(country, country);
		}
	}
}
