using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Security;
using Microsoft.Practices.Unity;
using NerdDinner.Controllers;
using NerdDinner.Models;

namespace NerdDinner
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			IUnityContainer unityContainer = new UnityContainer();
			unityContainer
				.RegisterType<DinnersController, DinnersController>()
				.RegisterType<SearchController, SearchController>()
				.RegisterType<RSVPController, RSVPController>()
				.RegisterType<IDinnerRepository, DinnerRepository>();
			Application["Container"] = unityContainer;
		}

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

		protected void Application_Error(object sender, EventArgs e)
		{
			Exception ex = Server.GetLastError();
			while (ex.InnerException != null)
				ex = ex.InnerException;
			if (ex is SecurityException)
			{
				Server.ClearError();
				FormsAuthentication.RedirectToLoginPage();
			}
		}

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}
	}
}