<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Venue Registration</title>
    <link href="VenueStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Venue Registration</h1>
    <table>
        <tr>
            <td>Venue Name</td>
            <td>
                <asp:TextBox ID="txtVenueName" runat="server"></asp:TextBox></td>
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
            <td>Address</td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>City</td>
            <td>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>State</td>
            <td>
                <asp:TextBox ID="txtState" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Zip Code</td>
            <td>
                <asp:TextBox ID="txtZip" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Phone Number</td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Venue Webpage</td>
            <td>
                <asp:TextBox ID="txtWebPage" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Age restriction</td>
            <td>
                <asp:DropDownList ID="ddlAge" runat="server">
                    <asp:ListItem Text="All ages" Value="0" Selected="True"> </asp:ListItem>
                    <asp:ListItem Text="18" Value="18"> </asp:ListItem>
                    <asp:ListItem Text="21" Value="21"> </asp:ListItem>
                    <asp:ListItem Text="65" Value="65"> </asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td><asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" /></td>
            <td>
                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                </td>
        </tr>
    </table>
        <asp:RequiredFieldValidator ID="NameValidator" runat="server" ErrorMessage="Venue name required" ControlToValidate="txtVenueName" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="AddressValidator" runat="server" ErrorMessage="Address required" ControlToValidate="txtAddress" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="CityValidator" runat="server" ErrorMessage="City required" ControlToValidate="txtCity" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="StateValidator" runat="server" ErrorMessage="State required" ControlToValidate="txtState" Display="None"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="StateRegexValidator" runat="server" ErrorMessage="States are two letters long." Display="None" ControlToValidate="txtState" ValidationExpression="^[a-zA-Z]{2}$"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="ZipValidator" runat="server" ErrorMessage="Zip code required" ControlToValidate="txtZip" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="PhoneValidator" runat="server" ErrorMessage="Phone number required" ControlToValidate="txtPhone" Display="None"></asp:RequiredFieldValidator>
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
