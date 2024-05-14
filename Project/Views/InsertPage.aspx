<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertPage.aspx.cs" Inherits="Project.Views.InsertPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Insert Page</h1>
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
            <asp:Button ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click"/>
        </div>
    </form>
</body>
</html>
