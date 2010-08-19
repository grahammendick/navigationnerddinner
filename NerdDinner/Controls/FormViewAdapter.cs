using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls;

namespace NerdDinner.Controls
{
	public class FormViewAdapter : ControlAdapter
	{
		protected override void Render(HtmlTextWriter writer)
		{
			((FormView)Control).Row.Cells[0].RenderControl(writer);
		}
	}
}
