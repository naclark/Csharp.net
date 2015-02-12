<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Front.aspx.cs" Inherits="Front" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Welcome to Fan Login</h1>
        <p>Log in or register</p>
        <table>
            <tr>
                <td>User Name</td>
                <td><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Password</td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="btnLogin" runat="server" Text="Log in" OnClick="btnLogin_Click" /></td>
                <td><asp:Label ID="lblError" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        <p>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Register</asp:LinkButton>
        </p>
    </div>
    </form>
</body>
</html>
