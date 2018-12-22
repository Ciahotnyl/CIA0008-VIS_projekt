<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddToShift.aspx.cs" Inherits="Vis_project_web.AddToShift" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <h1>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </h1>
    <form id="form1" runat="server">
        <div>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
            <asp:ListItem Selected="True">SQL</asp:ListItem>
            <asp:ListItem>JSON</asp:ListItem>
        </asp:RadioButtonList>
    </form>
</body>
</html>