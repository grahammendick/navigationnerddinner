using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls;

namespace NerdDinner.Controls
{
	public class LoginAdapter : ControlAdapter
	{
		protected override void Render(HtmlTextWriter writer)
		{
			foreach (Control control in ((Login)Control).Controls[0].Controls)
			{
				control.RenderControl(writer);
			}
		}
	}
}
