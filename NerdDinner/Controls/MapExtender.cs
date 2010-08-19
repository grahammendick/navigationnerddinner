using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace NerdDinner.Controls
{
	[TargetControlType(typeof(Control))]
	public class MapExtender : ExtenderControl
	{
		public string LatitudeID
		{
			get;
			set;
		}

		public string LongitudeID
		{
			get;
			set;
		}

		public string Name
		{
			get
			{
				return (string)ViewState["name"];
			}
			set
			{
				ViewState["name"] = value;
			}
		}

		public string Description
		{
			get
			{
				return (string)ViewState["description"];
			}
			set
			{
				ViewState["description"] = value;
			}
		}

		public string AddressID
		{
			get;
			set;
		}

		public string BehaviorId
		{
			get;
			set;
		}

		protected override IEnumerable<ScriptDescriptor> GetScriptDescriptors(Control targetControl)
		{
			ScriptBehaviorDescriptor descriptor = new ScriptBehaviorDescriptor("NerdDinner.Scripts.MapBehavior", targetControl.ClientID);
			if (LatitudeID != null)
				descriptor.AddElementProperty("latitude", FindControl(LatitudeID).ClientID);
			if (LongitudeID != null)
				descriptor.AddElementProperty("longitude", FindControl(LongitudeID).ClientID);
			if (Name != null)
				descriptor.AddProperty("name", Name);
			if (Description != null)
				descriptor.AddProperty("description", Description);
			if (AddressID != null)
				descriptor.AddElementProperty("address", FindControl(AddressID).ClientID);
			if (BehaviorId != null)
				descriptor.AddProperty("id", BehaviorId);
			yield return descriptor;
		}

		protected override IEnumerable<ScriptReference> GetScriptReferences()
		{
			yield return new ScriptReference("http://dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=6.2");
			yield return new ScriptReference("NerdDinner.Scripts.MapBehavior.js", this.GetType().Assembly.FullName);
		}
	}
}
