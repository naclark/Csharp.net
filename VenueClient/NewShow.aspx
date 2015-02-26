<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewShow.aspx.cs" Inherits="NewShow" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New Show</title>
    <link href="VenueStyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Venue Connection</h1>
        <hr />
        <p>Add your show</p>
            <p>Enter the name of the show.</p>
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>
            <br />
            <p>When is the show?</p>
            <asp:Calendar ID="showDate" runat="server"></asp:Calendar>
        <table>
        <tr>
            <td>What time does it start? <br /> Please use military time, e.g. 16:00 for 4 pm.</td>
            <td>
                <asp:TextBox ID="txtShowTime" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>When does the artist start playing?</td>
            <td>
                <asp:TextBox ID="txtArtistTime" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Choose an existing artist or enter your own:</td>
            <td>
                <asp:DropDownList ID="ddlArtist" runat="server"></asp:DropDownList></td>
            <td>
                Artist Name<asp:TextBox ID="txtArtistName" runat="server"></asp:TextBox></td>
            <td>
                Artist Email<asp:TextBox ID="txtArtistEmail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Any special ticket information?</td>
            <td>
                <asp:TextBox ID="txtTicketInfo" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Any other show details?</td>
            <td>
                <asp:TextBox ID="txtShowDetails" runat="server"></asp:TextBox>  </td>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
            <td>
                <asp:Label ID="lbResult" runat="server" Text=""></asp:Label> </td>
            <td>
                </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
