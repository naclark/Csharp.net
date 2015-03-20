<%@ Page MasterPageFile="~/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="FanHome.aspx.cs" Inherits="FanHome" %>

<asp:Content ID="Content" ContentPlaceHolderID="CPH1" runat="server">

    <h1>Welcome, fan!</h1>
    <h3>Here are your upcoming shows:</h3>
        <asp:GridView ID="grdShows" runat="server" DataKeyNames="ShowDate,ShowName,ShowTicketInfo,ShowTime"></asp:GridView>
        <asp:LinkButton ID="lblAddSomething" runat="server" 
            PostBackUrl="~/FollowNew.aspx">I want to follow a new artist or genre!</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" 
            PostBackUrl="~/Search.aspx">I want to search shows by artist, genre or venue!</asp:LinkButton>
</asp:Content>