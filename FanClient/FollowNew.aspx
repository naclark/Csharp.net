<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FollowNew.aspx.cs" Inherits="FollowNew" %>

<asp:Content ID="FollowPage" ContentPlaceHolderID="CPH1" runat="server">
        Here are the artists you currently follow:
        <asp:GridView ID="grdArtists" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ArtistName" HeaderText="Artist Name" />
                <asp:BoundField DataField="ArtistEmail" HeaderText="Email" />
                <asp:BoundField DataField="ArtistWebPage" HeaderText="Home Page" />
            </Columns>
        </asp:GridView>
        And here are your current genres:
        <asp:GridView ID="grdGenres" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="GenreName" HeaderText="Genre Name" />
            </Columns>
        </asp:GridView>
        Select just one of these and click "Follow." <br />
        <asp:DropDownList ID="ddlArtists" runat="server" AppendDataBoundItems="True">
            <asp:ListItem Selected="True">Select an artist</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:DropDownList ID="ddlGenres" runat="server" AppendDataBoundItems="true">
            <asp:ListItem Selected="True">Select a genre</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnFollow" runat="server" Text="Follow" OnClick="btnFollow_Click" />
        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/FanHome.aspx" >Head back</asp:LinkButton>
</asp:Content>