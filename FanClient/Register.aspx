<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fan Registration</title>
    <link href="FanStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Fan Registration</h1>
    <table>
        <tr>
            <td>Your Name</td>
            <td>
                <asp:TextBox ID="txtFanName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Login Name</td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password">
                </asp:TextBox></td>
        </tr>
        <tr>
            <td>Confirm Password</td>
            <td>
                <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password">
                </asp:TextBox></td>
        </tr>
        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td><asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" /></td>
            <td>
                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                </td>
        </tr>
    </table>
        <asp:RequiredFieldValidator ID="EmailValidator" runat="server" ErrorMessage="Your email required" ControlToValidate="txtEmail" Display="None"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="EmailRegex" runat="server" ErrorMessage="Not a valid email" ControlToValidate="txtEmail" Display="None" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="UserNameValidator" runat="server" ErrorMessage="Username required" ControlToValidate="txtUserName" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ErrorMessage="Password required" ControlToValidate="txtPassword" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="ConfirmValidator" runat="server" ErrorMessage="Password confirmation required" ControlToValidate="txtConfirm" Display="None"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="UserNameRegex" runat="server" ErrorMessage="Username must be alphanumeric" ControlToValidate="txtUserName" ValidationExpression="^[a-zA-Z0-9]+$"></asp:RegularExpressionValidator>
        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToValidate="txtConfirm" ControlToCompare="txtPassword" ErrorMessage="Passwords don't match"></asp:CompareValidator>
        <asp:ValidationSummary ID="ValidationSummary" runat="server" />
        <asp:LinkButton ID="lbLogin" runat="server" PostBackURL="~/Default.aspx" CausesValidation="False">Log in</asp:LinkButton>
    </div>
    </form>
</body>
</html>
