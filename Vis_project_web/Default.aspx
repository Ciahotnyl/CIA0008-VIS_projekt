﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vis_project_web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound">
        </asp:GridView>
        <br />
        <asp:Button ID="Export_to_json" runat="server" OnClick="Export_to_json_Click" Text="Export to JSON" />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Selected="True">SQL</asp:ListItem>
            <asp:ListItem>JSON</asp:ListItem>
        </asp:RadioButtonList>
    </form>
</body>
</html>
