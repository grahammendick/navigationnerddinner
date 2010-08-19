using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls;
using NerdDinner.Helpers;

namespace NerdDinner.Controls
{
	public class ObjectDataSourceAdapter : ControlAdapter
	{
		protected override void OnInit(System.EventArgs e)
		{
			((ObjectDataSource)Control).ObjectCreating += ObjectDataSource_ObjectCreating;
			base.OnInit(e);
		}

		private void ObjectDataSource_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
		{
			e.ObjectInstance = ControllerFactory.Resolve(Type.GetType(((ObjectDataSource)Control).TypeName));
		}
	}
}
