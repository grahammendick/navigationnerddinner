using System.Web.UI;
using System.Web.UI.Adapters;
using System.Web.UI.WebControls;

namespace NerdDinner.Controls
{
	public class CreateUserWizardAdapter : ControlAdapter
	{
		protected override void Render(HtmlTextWriter writer)
		{
			ControlCollection controlColl = ((CreateUserWizard)Control).CreateUserStep.ContentTemplateContainer.Controls;
			while (controlColl.Count == 1)
				controlColl = controlColl[0].Controls;
			foreach (Control control in controlColl)
			{
				control.RenderControl(writer);
			}
			foreach (Control control in ((CreateUserWizard)Control).CreateUserStep.CustomNavigationTemplateContainer.Controls)
			{
				control.RenderControl(writer);
			}
		}
	}
}
