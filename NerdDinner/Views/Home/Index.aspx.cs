using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using NerdDinner.Controllers;
using Navigation;
using NerdDinner.Helpers;

namespace NerdDinner.Views.Home
{
	public partial class Index : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			UpcomingLink.NavigateUrl = StateController.GetNavigationLink("Dinners");
		}

		[WebMethod]
		public static List<JsonDinner> SearchByLocation(float latitude, float longitude)
		{
			return ControllerFactory.Resolve<SearchController>().SearchByLocation(latitude, longitude);
		}
	}
}
