using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NerdDinner.Models;
using System.Threading;
using System.Security.Permissions;

namespace NerdDinner.Controllers
{
	public class RSVPController
	{
		IDinnerRepository dinnerRepository;

		public RSVPController(IDinnerRepository repository)
		{
			dinnerRepository = repository;
		}


		[PrincipalPermission(SecurityAction.Demand)]
		public void Register(int id)
		{
			Dinner dinner = dinnerRepository.GetDinner(id);
			if (!dinner.IsUserRegistered(Thread.CurrentPrincipal.Identity.Name))
			{
				RSVP rsvp = new RSVP();
				rsvp.AttendeeName = Thread.CurrentPrincipal.Identity.Name;
				dinner.RSVPs.Add(rsvp);
				dinnerRepository.Save();
			}
		}
	}
}
