<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="NerdDinner.Views.Home.About" MasterPageFile="~/Views/Shared/Site.Master" Theme="Site" %>
<%@ Register assembly="Navigation" namespace="Navigation" tagprefix="cc1" %>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>What is NerdDinner.com?</h2>
    <p>
         <p><asp:Image ID="NerdImage" runat="server" SkinID="Nerd" ImageAlign="Left" Height="200" style="padding-right:20px" />Are you a huge nerd? Perhaps a geek? No? Maybe a dork, dweeb or wonk. 
         Quite possibly you're just a normal person. Either way, you're a social being. You need to get out for a bite
         to eat occasionally, preferably with folks that are like you.</p>
         <p>Enter <a href="http://www.nerddinner.com">NerdDinner.com</a>, for all your event planning needs. We're focused on one thing. Organizing the world's
         nerds and helping them eat in packs. </p>
         <p>We're free and fun. <cc1:NavigationHyperLink ID="FindLink" runat="server" Action="Home" Text="Find a dinner near you" />, or <cc1:NavigationHyperLink ID="CreateLink" runat="server" Action="HostDinner" Text="host a dinner" />. Be social.</p>
         <p>We also have blog badges and widgets that you can install on your blog or website so your readers can get 
         involved in the Nerd Dinner movement. Well, it's not really a movement. Mostly just geeks in a food court, but still.</p>
    </p>
</asp:Content>

