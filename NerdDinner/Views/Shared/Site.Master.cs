using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Navigation;

namespace NerdDinner.Views.Shared
{
	public partial class Site : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			LoginStatus.LogoutPageUrl = StateController.GetNavigationLink("Home");
			FindDinnerLink.NavigateUrl = StateController.GetNavigationLink("Home");
			HostDinnerLink.NavigateUrl = StateController.GetNavigationLink("HostDinner");
			AboutLink.NavigateUrl = StateController.GetNavigationLink("About");
		}
	}
}
