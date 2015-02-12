<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>First Name</td>
            <td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>Last Name</td>
            <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>Email</td>
            <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>User Name</td>
            <td><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>Password</td>
            <td><asp:TextBox ID="txtPassword" runat="server"  TextMode="Password"></asp:TextBox></td>
        </tr>
         <tr>
            <td>Confirm Password</td>
            <td><asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
         <tr>
            <td>
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" /></td>
            <td>
                <asp:Label ID="lblErrorSuccess" runat="server" Text=""></asp:Label></td>
        </tr>       
    </table>

        <asp:RequiredFieldValidator ID="LastNameValidator" runat="server" ErrorMessage="Last name required" ControlToValidate="txtLastName" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="EmailValidator" runat="server" ErrorMessage="Email required" ControlToValidate="txtEmail" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="UserNameValidator" runat="server" ErrorMessage="Username required" ControlToValidate="txtUserName" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="PasswordValidator" runat="server" ErrorMessage="Password required" ControlToValidate="txtPassword" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="ConfirmValidator" runat="server" ErrorMessage="Password confirmation required" ControlToValidate="txtConfirm" Display="None"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="UserNameRegex" runat="server" ErrorMessage="Username must be alphanumeric" ControlToValidate="txtUserName" ValidationExpression="^[a-zA-Z0-9]+$"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="EmailRegularExpression" runat="server" ErrorMessage="Enter a valid email" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToValidate="txtConfirm" ControlToCompare="txtPassword" ErrorMessage="Passwords don't match"></asp:CompareValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </div>
    </form>
    <a href="Front.aspx">Log in</a>
</body>
</html>