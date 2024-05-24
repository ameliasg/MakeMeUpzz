<%@ Page Title="Login" Language="C#" MasterPageFile="~/Layouts/HeaderAuthentication.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Project.Views.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="LoginForm" ContentPlaceHolderID="AuthForm" runat="server">
    <h1>Login</h1>
    <hr />
    <div>
        <asp:Label ID="EmailLbl" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="EmailTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="PasswordTB" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:CheckBox ID="cbRemember" runat="server" Text="Remember Me" AutoPostBack="true" OnCheckedChanged="RememberMe_CheckedChanged" />
    </div>
    <div>
        <asp:Label ID="lbError" ForeColor="Red" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
    </div>
</asp:Content>
