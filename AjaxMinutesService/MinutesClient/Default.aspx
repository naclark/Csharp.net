<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Assignment #6: Minutes to a Date</title>
    <style>
        br {
            clear:both;
            padding:10px;
        }
        body {
            font-family: sans-serif;
        }
    </style>
</head>
<body>
    <p>This form tells you how many minutes it will be until a certain date.</p>
    <asp:Image ID="logo2112" runat="server" AlternateText="2112 booklet" ImageUrl="~/2112booklet.jpg" ImageAlign="Left" />
    <asp:Label ID="lbl2112" runat="server" Text="The default value is December 21, 2112."></asp:Label>
    <br />
    <asp:Image ID="singularity" runat="server" AlternateText="Singularity" ImageUrl="~/singularity.jpg" ImageAlign="Right" />
    <asp:Label ID="lblSingularity" runat="server" Text="Another is 2045, which is when Ray Kurzweil predicts a technological singularity will happen."></asp:Label>
    <br />
    <form id="form1" runat="server">
    <div>
        <p>If you want, type in a year and click "Jump to Year".</p>
        <asp:TextBox ID="txtYear" runat="server"></asp:TextBox>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnJump" runat="server" Text="Jump to Year" OnClick="btnJump_Click" />
        <p>Select a day.</p>
        <asp:Calendar ID="clnBDay" runat="server" OnSelectionChanged="clnBDay_SelectionChanged"></asp:Calendar>
        <br />
        <p>The number of minutes until your chosen date refreshes every 60 seconds.</p>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
