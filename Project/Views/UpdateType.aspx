<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateType.aspx.cs" Inherits="Project.Views.UpdateType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Update Type</h1>
        <h1><%=Request.QueryString["id"] %></h1>
        <hr />
        <div>
            <asp:Label ID="TypeNameLbl" runat="server" Text="Type Name"></asp:Label>
            <asp:TextBox ID="TypeNameTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="UpdateType" runat="server" Text="Update" OnClick="UpdateType_Click" />
        </div>
    </form>
</body>
</html>
