<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertBrand.aspx.cs" Inherits="Project.Views.InsertBrand" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Insert Brand</h1>
        <hr />
        <div>
            <asp:Label ID="BrandNameLbl" runat="server" Text="Brand Name"></asp:Label>
            <asp:TextBox ID="BrandNameTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="BrandRatingLbl" runat="server" Text="Rating"></asp:Label>
            <asp:TextBox ID="BrandRatingTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="InsertBtn" runat="server" Text="Insert Brand" OnClick="InsertBtn_Click"/>
        </div>
    </form>
</body>
</html>
