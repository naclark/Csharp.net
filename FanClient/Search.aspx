<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="SearchPage" ContentPlaceHolderID="CPH1" runat="server">
        <h1>Search Shows</h1>
        <asp:DropDownList ID="ddlSearchType" runat="server">
            <asp:ListItem Text="Please select search type." Selected="True"></asp:ListItem>
            <asp:ListItem Text="Artist name" Value="1"></asp:ListItem>
            <asp:ListItem Text="Genre name" Value="2"></asp:ListItem>
            <asp:ListItem Text="Venue name" Value="3"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtQuery" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search!" OnClick="btnSearch_Click" />
        <asp:GridView ID="grdShows" runat="server"></asp:GridView>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        <asp:LinkButton ID="LinkButton1" runat="server" 
            PostBackUrl="~/Default.aspx">Go back</asp:LinkButton>
</asp:Content>
