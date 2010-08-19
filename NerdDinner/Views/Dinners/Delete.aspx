<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="NerdDinner.Views.Dinners.Delete" MasterPageFile="~/Views/Shared/Site.Master" Theme="Site" %>
<%@ Register assembly="Navigation" namespace="Navigation" tagprefix="cc1" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Delete Confirmation</h2>
	<asp:FormView ID="DeleteForm" runat="server" DataSourceID="DinnerDataSource" DefaultMode="ReadOnly" DataKeyNames="DinnerID">
		<ItemTemplate>
			<div>
				<p>Please confirm you want to cancel the dinner titled: 
				<i><asp:Localize ID="Title" runat="server" Text='<%# Eval("Title") %>' Mode="Encode" />?</i></p>
			</div>
			<asp:Button ID="ConfirmButton" runat="server" Text="Delete" CommandName="Delete" />
		</ItemTemplate>
	</asp:FormView>
	<asp:ObjectDataSource ID="DinnerDataSource" runat="server" SelectMethod="GetDetails" TypeName="NerdDinner.Controllers.DinnersController" DataObjectTypeName="NerdDinner.Models.Dinner" DeleteMethod="Delete">
		<SelectParameters>
			<cc1:NavigationDataParameter Name="id" />
		</SelectParameters>
	</asp:ObjectDataSource>
</asp:Content>
