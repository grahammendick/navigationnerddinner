<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="NerdDinner.Views.Dinners.Index" MasterPageFile="~/Views/Shared/Site.Master" Theme="Site" %>
<%@ Register assembly="Navigation" namespace="Navigation" tagprefix="cc1" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Upcoming Dinners</h2>
	<asp:ListView ID="UpcomingListView" runat="server" DataSourceID="UpcomingDataSource">
		<LayoutTemplate>
			<ul>
				<asp:PlaceHolder ID="itemPlaceholder" runat="server" />
			</ul>
		</LayoutTemplate>
		<ItemTemplate>
			<li>
				<cc1:NavigationHyperLink ID="TitleLink" runat="server" ToData='<%# new NavigationData() { { "id", Eval("DinnerID") } }%>' Action="MaintainDinner">
					<asp:Localize ID="Title" runat="server" Text='<%# Eval("Title") %>' Mode="Encode" />
				</cc1:NavigationHyperLink>
				on
				<asp:Localize ID="EventDate" runat="server" Text='<%# Eval("EventDate","{0:d}") %>' Mode="Encode" />
				@
				<asp:Localize ID="EventTime" runat="server" Text='<%# Eval("EventDate","{0:t}") %>' Mode="Encode" />
			</li>
		</ItemTemplate>
	</asp:ListView>
	<asp:ObjectDataSource ID="UpcomingDataSource" runat="server" SelectMethod="Index" TypeName="NerdDinner.Controllers.DinnersController">
		<SelectParameters>
			<cc1:NavigationDataParameter Name="startRowIndex"/>
			<cc1:NavigationDataParameter Name="maximumRows"/>
		</SelectParameters>
	</asp:ObjectDataSource>
	
	<cc1:Pager ID="Pager" runat="server" QueryStringField="q">
		<Fields>
			<asp:NextPreviousPagerField ShowFirstPageButton="false" ShowLastPageButton="false" PreviousPageText="<<<" NextPageText=">>>" />
		</Fields>
	</cc1:Pager>
</asp:Content>
