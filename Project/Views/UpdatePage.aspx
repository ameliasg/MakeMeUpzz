<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePage.aspx.cs" Inherits="Project.Views.UpdatePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Update Page</h1>
        <h1><%=Request.QueryString["id"] %></h1>
        <hr />
        <div>
            <asp:Label ID="MakeupNameLbl" runat="server" Text="Makeup Name"></asp:Label>
            <asp:TextBox ID="MakeupNameTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupPriceLbl" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="MakeupPriceTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupWeightLbl" runat="server" Text="Weight"></asp:Label>
            <asp:TextBox ID="MakeupWeightTB" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="MakeupTypeLbl" runat="server" Text="Type"></asp:Label>
            <asp:DropDownList ID="MakeupTypeDropDown" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="MakeupBrandLbl" runat="server" Text="Brand"></asp:Label>
            <asp:DropDownList ID="MakeupBrandDropDown" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
        </div>
    </form>
</body>
</html>
