<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateBrand.aspx.cs" Inherits="Project.Views.UpdateBrand" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Update Brand</h1>
        <h1><%=Request.QueryString["id"] %></h1>
        <hr />
        <div>
            <asp:Label ID="BrandNameLLbl" runat="server" Text="Brand Name"></asp:Label>
            <asp:TextBox ID="BrandNameTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="RatingLbl" runat="server" Text="Brand Rating"></asp:Label>
            <asp:TextBox ID="RatingTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="UpdateBrand" runat="server" Text="Update" OnClick="UpdateBrand_Click"/>
        </div>
    </form>
</body>
</html>
