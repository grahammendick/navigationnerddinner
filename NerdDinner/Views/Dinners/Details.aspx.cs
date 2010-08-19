using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using NerdDinner.Controllers;
using NerdDinner.Helpers;

namespace NerdDinner.Views.Dinners
{
	public partial class Details : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		[WebMethod]
		public static string Register(int id)
		{
			ControllerFactory.Resolve<RSVPController>().Register(id);
			return "Thanks - we'll see you there!";
		}
	}
}
