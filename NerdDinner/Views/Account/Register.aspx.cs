using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Navigation;

namespace NerdDinner.Views.Account
{
	public partial class Register : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void CreateUser_NextButtonClick(object sender, WizardNavigationEventArgs e)
		{
			if (!e.Cancel)
				StateController.Navigate("Home");
		}
	}
}
