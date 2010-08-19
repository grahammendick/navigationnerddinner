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
				<asp:HyperLink ID="TitleLink" runat="server" NavigateUrl='<%# Eval("DetailsLink") %>'>
					<asp:Localize ID="Title" runat="server" Text='<%# Eval("Dinner.Title") %>' Mode="Encode" />
				</asp:HyperLink>
				on
				<asp:Localize ID="EventDate" runat="server" Text='<%# Eval("Dinner.EventDate","{0:d}") %>' Mode="Encode" />
				@
				<asp:Localize ID="EventTime" runat="server" Text='<%# Eval("Dinner.EventDate","{0:t}") %>' Mode="Encode" />
			</li>
		</ItemTemplate>
	</asp:ListView>
	<asp:ObjectDataSource ID="UpcomingDataSource" runat="server" SelectMethod="Index" TypeName="NerdDinner.Controllers.DinnersController">
		<SelectParameters>
			<cc1:NavigationDataParameter Name="page"/>
		</SelectParameters>
	</asp:ObjectDataSource>
	
	<asp:FormView ID="PagerFormView" runat="server" DataSourceID="PagerDataSource">
		<ItemTemplate>
		<asp:HyperLink ID="PreviousPageLink" runat="server" Text="<<<" NavigateUrl='<%# Eval("PreviousPageLink") %>' Visible='<%# Eval("HasPreviousPage") %>'/>
		<asp:HyperLink ID="NextPageLink" runat="server" Text=">>>" NavigateUrl='<%# Eval("NextPageLink") %>' Visible='<%# Eval("HasNextPage") %>'/>
		</ItemTemplate>
	</asp:FormView>
	<asp:ObjectDataSource ID="PagerDataSource" runat="server" SelectMethod="PagedIndex" TypeName="NerdDinner.Controllers.DinnersController">
		<SelectParameters>
			<cc1:NavigationDataParameter Name="page"/>
		</SelectParameters>
	</asp:ObjectDataSource>
</asp:Content>
