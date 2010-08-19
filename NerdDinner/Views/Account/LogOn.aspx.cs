using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Navigation;

namespace NerdDinner.Views.Account
{
	public partial class LogOn : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			RegisterLink.NavigateUrl = StateController.GetNavigationLink("Register");
		}
	}
}
