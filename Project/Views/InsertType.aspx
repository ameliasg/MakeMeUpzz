<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertType.aspx.cs" Inherits="Project.Views.InsertType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Insert Type</h1>
        <hr />
        <div>
            <asp:Label ID="TypeNameLbl" runat="server" Text="Brand Name"></asp:Label>
            <asp:TextBox ID="TypeNameTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="InsertBtn" runat="server" Text="Insert Type" OnClick="InsertBtn_Click" />
        </div>
    </form>
</body>
</html>
