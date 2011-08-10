<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deleted.aspx.cs" Inherits="NerdDinner.Views.Dinners.Deleted" MasterPageFile="~/Views/Shared/Site.Master" Theme="Site" %>
<%@ Register assembly="Navigation" namespace="Navigation" tagprefix="cc1" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Dinner Deleted</h2>
    <p>Your dinner was successfully deleted.</p>    
    <p><cc1:NavigationHyperLink ID="UpcomingLink" runat="server" Action="Dinners" Text="Click for Upcoming Dinners" /></p>
</asp:Content>
