<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="NerdDinner.Views.Account.Register" MasterPageFile="~/Views/Shared/Site.Master" Theme="Site" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <div>
	    <asp:ValidationSummary ID="Validation" runat="server" HeaderText="Please correct the errors and try again." ValidationGroup="CreateUser"/>
		<fieldset>
			<legend>Account Information</legend>
    		<asp:CreateUserWizard ID="CreateUser" runat="server" onnextbuttonclick="CreateUser_NextButtonClick">
				<WizardSteps>
					<asp:CreateUserWizardStep runat="server">
						<ContentTemplate>
							<span class="validation-summary-errors"><asp:Localize ID="ErrorMessage" runat="server" /></span>
							<p>
								<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
								<asp:TextBox ID="UserName" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUser">*</asp:RequiredFieldValidator>
							</p>
							<p>
								<asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
								<asp:TextBox ID="Email" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="CreateUser">*</asp:RequiredFieldValidator>
							</p>
							<p>
								<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
								<asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
								<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="CreateUser">*</asp:RequiredFieldValidator>
							</p>
							<p>
								<asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
								<asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
								<asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required." ValidationGroup="CreateUser">*</asp:RequiredFieldValidator>
								<asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match." ValidationGroup="CreateUser">*</asp:CompareValidator>
							</p>
						</ContentTemplate>
						<CustomNavigationTemplate>
							<p>
								<asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="Create User" ValidationGroup="CreateUser" />
							</p>
						</CustomNavigationTemplate>
					</asp:CreateUserWizardStep>
					<asp:CompleteWizardStep runat="server" />
				</WizardSteps>
			</asp:CreateUserWizard>
		</fieldset>
    </div>
</asp:Content>
