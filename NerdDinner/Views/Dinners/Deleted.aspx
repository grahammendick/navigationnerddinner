<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deleted.aspx.cs" Inherits="NerdDinner.Views.Dinners.Deleted" MasterPageFile="~/Views/Shared/Site.Master" Theme="Site" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Dinner Deleted</h2>
    <p>Your dinner was successfully deleted.</p>    
    <p><asp:HyperLink ID="UpcomingLink" runat="server" Text="Click for Upcoming Dinners" /></p>
</asp:Content>
