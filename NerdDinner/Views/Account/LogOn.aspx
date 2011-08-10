<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogOn.aspx.cs" Inherits="NerdDinner.Views.Account.LogOn" MasterPageFile="~/Views/Shared/Site.Master" Theme="Site" %>
<%@ Register assembly="Navigation" namespace="Navigation" tagprefix="cc1" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <div>
		<h2>Log On</h2>
		<p>
			Please enter your username and password. <cc1:NavigationHyperLink ID="RegisterLink" runat="server" Action="Register" Text="Register"/> if you don't have an account.
		</p>
	    <asp:ValidationSummary ID="Validation" runat="server" HeaderText="Please correct the errors and try again." ValidationGroup="Login"/>
		<fieldset>
			<legend>Account Information</legend>
    		<asp:Login ID="Login" runat="server" RenderOuterTable="false">
				<LayoutTemplate>
					<span class="validation-summary-errors"><asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></span>
					<p>
						<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
						<asp:TextBox ID="UserName" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="You must specify a username." ValidationGroup="Login">*</asp:RequiredFieldValidator>
					</p>
					<p>
						<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
						<asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
						<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="You must specify a password." ValidationGroup="Login">*</asp:RequiredFieldValidator>
					</p>
					<p>
						<asp:CheckBox ID="RememberMe" runat="server" />
						<asp:Label ID="RememberMeLabel" runat="server" Text="Remember me?" AssociatedControlID="RememberMe" CssClass="inline"/>
					</p>
					<p>
						<asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log On" ValidationGroup="Login" />
					</p>
				</LayoutTemplate>
			</asp:Login>    
		</fieldset>
    </div>
</asp:Content>
