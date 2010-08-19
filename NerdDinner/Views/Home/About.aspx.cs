﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Navigation;

namespace NerdDinner.Views.Home
{
	public partial class About : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			FindLink.NavigateUrl = StateController.GetNavigationLink("Home");
			CreateLink.NavigateUrl = StateController.GetNavigationLink("HostDinner");
		}
	}
}
