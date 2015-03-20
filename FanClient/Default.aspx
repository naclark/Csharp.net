<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content" ContentPlaceHolderID="CPH1" runat="server">
        <h1>Fan-Show Connection</h1>
        <hr />
        <p>To get show information you must log in.</p>
        <table class="login">
            <tr>
                <td class="login">User Name</td>
                <td class="login">
                    <asp:TextBox ID="txtUserName" runat="server">
</asp:TextBox></td>
            </tr>
                <tr>
                <td class="login">Password</td>
                <td class="login">
                    <asp:TextBox ID="txtPassword" runat="server" 
TextMode="Password">
                   </asp:TextBox></td>
            </tr>
                <tr>
                <td class="login">
                    <asp:Button ID="btnLogin" runat="server" Text="Log in" OnClick="btnLogin_Click" />
                </td>
                <td class="login">
                    <asp:Label ID="lblMessage" runat="server" Text="">
</asp:Label> </td>
            </tr>
        </table>
        <asp:LinkButton ID="lbRegister" runat="server" 
            PostBackUrl="~/Register.aspx">Register</asp:LinkButton>
        <asp:LinkButton ID="LinkButton1" runat="server" 
            PostBackUrl="~/Search.aspx">Search shows by artist, genre or venue (no login required)</asp:LinkButton>
</asp:Content>
