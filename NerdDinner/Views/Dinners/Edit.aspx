<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="NerdDinner.Views.Dinners.Edit" MasterPageFile="~/Views/Shared/Site.Master" Theme="Site" %>
<%@ Register assembly="Navigation" namespace="Navigation" tagprefix="cc1" %>
<%@ Register assembly="NerdDinner" namespace="NerdDinner.Controls" tagprefix="cc2" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit Dinner</h2>
    <asp:ValidationSummary ID="Validation" runat="server" HeaderText="Please correct the errors and try again."/>
	<asp:FormView ID="EditForm" runat="server" DataSourceID="DinnerDataSource" DefaultMode="Edit" DataKeyNames="DinnerID">
		<EditItemTemplate>
			<fieldset>
				<div id="dinnerDiv">
				<p>
					<asp:Label ID="TitleLabel" runat="server" Text="Dinner Title:" AssociatedControlID="TitleTextBox"/>
					<asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
					<asp:RequiredFieldValidator ID="TitleValidator" runat="server" ControlToValidate="TitleTextBox" ErrorMessage="Title is required" Text="*"/>
				</p>
				<p>
					<asp:Label ID="EventDateLabel" runat="server" Text="Event Date:" AssociatedControlID="EventDateTextBox"/>
					<asp:TextBox ID="EventDateTextBox" runat="server" Text='<%# Bind("EventDate","{0:g}") %>' />
					<asp:RequiredFieldValidator ID="EventDateValidator" runat="server" ControlToValidate="EventDateTextBox" ErrorMessage="Event Date is required" Text="*"/>
					<cc2:DateTimeValidator ID="EventDateFormatValidator" runat="server" ControlToValidate="EventDateTextBox" ErrorMessage="Invalid Event Date format" Text="*"/>
				</p>
				<p>
					<asp:Label ID="DescriptionLabel" runat="server" Text="Description:" AssociatedControlID="DescriptionTextBox"/>
					<asp:TextBox ID="DescriptionTextBox" runat="server" Text='<%# Bind("Description") %>' TextMode="MultiLine" />
					<asp:RequiredFieldValidator ID="DescriptionValidator" runat="server" ControlToValidate="DescriptionTextBox" ErrorMessage="Description is required" Text="*"/>
				</p>
				<p>
					<asp:Label ID="AddressLabel" runat="server" Text="Address:" AssociatedControlID="AddressTextBox"/>
					<asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
					<asp:RequiredFieldValidator ID="AddressValidator" runat="server" ControlToValidate="AddressTextBox" ErrorMessage="Address is required" Text="*"/>
				</p>
				<p>
					<asp:Label ID="CountryLabel" runat="server" Text="Country:" AssociatedControlID="CountryDropDown"/>
					<asp:DropDownList ID="CountryDropDown" runat="server" DataSourceID="CountryDataSource" DataTextField="Value" DataValueField="Key" SelectedValue='<%# Bind("Country") %>'>
					</asp:DropDownList>
					<asp:ObjectDataSource ID="CountryDataSource" runat="server" SelectMethod="Countries" TypeName="NerdDinner.Controllers.DinnersController"></asp:ObjectDataSource>
					<asp:RequiredFieldValidator ID="CountryValidator" runat="server" ControlToValidate="CountryDropDown" ErrorMessage="Country is required" Text="*" />
				</p>
				<p>
					<asp:Label ID="ContactPhoneLabel" runat="server" Text="Contact Phone #:" AssociatedControlID="ContactPhoneTextBox"/>
					<asp:TextBox ID="ContactPhoneTextBox" runat="server" Text='<%# Bind("ContactPhone") %>' />
					<asp:RequiredFieldValidator ID="ContactPhoneValidator" runat="server" ControlToValidate="ContactPhoneTextBox" ErrorMessage="Phone# is required" Text="*" />
					<cc2:PhoneCountryValidator ID="PhoneCountryValidator" runat="server" ControlToValidate="ContactPhoneTextBox" CountryID="CountryDropDown" ErrorMessage="Phone# does not match country" Text="*" />
				</p>
				<p>
					<asp:Button ID="SaveButton" runat="server" Text="Save" CommandName="Update" />
				</p>
				</div>
				<asp:HiddenField ID="Latitude" runat="server" Value='<%# Bind("Latitude") %>' />
				<asp:HiddenField ID="Longitude" runat="server" Value='<%# Bind("Longitude") %>' />
				<div id="mapDiv">
					<asp:Panel ID="Map" runat="server" style="width:520px;height:400px;position:relative"/>
					<cc2:MapExtender ID="Map_MapExtender" runat="server" TargetControlID="Map" LatitudeID="Latitude" LongitudeID="Longitude" Name='<%# Eval("Title") %>' Description='<%# Eval("Address") %>' AddressID="AddressTextBox" />
				</div>
			</fieldset>
		</EditItemTemplate>
	</asp:FormView>
	
	<asp:ObjectDataSource ID="DinnerDataSource" runat="server" SelectMethod="GetDetails" TypeName="NerdDinner.Controllers.DinnersController" DataObjectTypeName="NerdDinner.Models.Dinner" UpdateMethod="Edit">
		<SelectParameters>
			<cc1:NavigationDataParameter Name="id"/>
		</SelectParameters>
		<UpdateParameters>
			<asp:Parameter Name="EventDate" Type="DateTime" />
		</UpdateParameters>
	</asp:ObjectDataSource>
</asp:Content>
