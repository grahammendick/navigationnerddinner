<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="NerdDinner.Views.Dinners.Details" MasterPageFile="~/Views/Shared/Site.Master" Theme="Site" %>
<%@ Register assembly="Navigation" namespace="Navigation" tagprefix="cc1" %>
<%@ Register assembly="NerdDinner" namespace="NerdDinner.Controls" tagprefix="cc2" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
PageMethods.set_path('/Views/Dinners/Details.aspx');
function RSVPCompleted(message) {
	$("#rsvpmsg").html(message);
	$("#rsvpmsg").animate({ fontSize: "1.5em" }, 400);
}
</script>
	<asp:FormView ID="DetailsForm" runat="server" DataSourceID="DinnerDataSource">
		<ItemTemplate>
			<div id="dinnerDiv">
		    <h2><asp:Localize ID="Title" runat="server" Text='<%# Eval("Dinner.Title") %>' Mode="Encode" /></h2>
			<p>
				<strong>When:</strong>
				<asp:Localize ID="EventDate" runat="server" Text='<%# Eval("Dinner.EventDate","{0:d}") %>' Mode="Encode" />
				<strong>@</strong>
				<asp:Localize ID="EventTime" runat="server" Text='<%# Eval("Dinner.EventDate","{0:t}") %>' Mode="Encode" />
			</p>
			<p>
				<strong>Where:</strong>
				<asp:Localize ID="Address" runat="server" Text='<%# Eval("Dinner.Address") %>' Mode="Encode" />,
				<asp:Localize ID="Country" runat="server" Text='<%# Eval("Dinner.Country") %>' Mode="Encode" />
			</p>
			<p>
				<strong>Description:</strong>
				<asp:Localize ID="Description" runat="server" Text='<%# Eval("Dinner.Description") %>' Mode="Encode" />
			</p>
			<p>
				<strong>Organizer:</strong>
				<asp:Localize ID="HostedBy" runat="server" Text='<%# Eval("Dinner.HostedBy") %>' Mode="Encode" />
				(<asp:Localize ID="ContactPhone" runat="server" Text='<%# Eval("Dinner.ContactPhone") %>' Mode="Encode" />)
			</p>
			<div id="rsvpmsg">
				<asp:Localize ID="Registered" runat="server" Text="<p>You are registered for this event!</p>" Visible='<%# Eval("Registered")%>' />
				<asp:HyperLink ID="RegisterLink" runat="server" Text="RSVP for this event" NavigateUrl='<%# Eval("Dinner.DinnerID","javascript:PageMethods.Register({0}, RSVPCompleted);") %>' Visible='<%# Eval("Unregistered")%>' />
				<cc1:NavigationHyperLink ID="LoginLink" runat="server" Action="LogOn" Text="Logon" Visible='<%# Eval("Unauthenticated")%>' /><asp:Localize ID="Login" runat="server" Text=" to RSVP for this event" Visible='<%# Eval("Unauthenticated")%>' />
			</div>
			<asp:Panel ID="LinksPanel" runat="server" Visible='<%# Eval("IsHost") %>'>
				<cc1:NavigationHyperLink ID="EditLink" runat="server" ToData='<%# new NavigationData() { { "id", Eval("Dinner.DinnerID") } }%>' Action="Edit" Text="Edit Dinner" />
				|
				<cc1:NavigationHyperLink ID="DeleteLink" runat="server" ToData='<%# new NavigationData() { { "id", Eval("Dinner.DinnerID") } }%>' Action="Delete" Text="Delete Dinner" />
			</asp:Panel>
			</div>
			<asp:HiddenField ID="Latitude" runat="server" Value='<%# Eval("Dinner.Latitude") %>' />
			<asp:HiddenField ID="Longitude" runat="server" Value='<%# Eval("Dinner.Longitude") %>' />
			<div id="mapDiv">
				<asp:Panel ID="Map" runat="server" style="width:520px;height:400px;position:relative"/>
				<cc2:MapExtender ID="Map_MapExtender" runat="server" TargetControlID="Map" LatitudeID="Latitude" LongitudeID="Longitude" Name='<%# Eval("Dinner.Title") %>' Description='<%# Eval("Dinner.Address") %>' />
			</div>
		</ItemTemplate>
	</asp:FormView>
    
	<asp:ObjectDataSource ID="DinnerDataSource" runat="server" SelectMethod="Details" TypeName="NerdDinner.Controllers.DinnersController">
		<SelectParameters>
			<cc1:NavigationDataParameter Name="id"/>
		</SelectParameters>
	</asp:ObjectDataSource>
</asp:Content>
