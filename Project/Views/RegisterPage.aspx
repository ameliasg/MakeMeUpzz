<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/HeaderAuthentication.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Project.Views.RegisterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="RegisterForm" ContentPlaceHolderID="AuthForm" runat="server">
    <h1>MakeMeUpzz</h1>
    <h2>Welcome!</h2>
    <hr />
    <label>Create a new account</label>
    <div>
        <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="UsernameTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="EmailLbl" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="EmailTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <label>Gender</label>
        <asp:RadioButton ID="rbMale" runat="server" GroupName="radioGender" />
        <asp:Label ID="lbMale" runat="server" Text="Male"></asp:Label>
        <asp:RadioButton ID="rbFemale" runat="server" GroupName="radioGender" />
        <asp:Label ID="lbFemale" runat="server" Text="Female"></asp:Label>
    </div>
    <div>
        <asp:Label ID="PasswordLbl" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="PasswordTB" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="ConfirmPasswordLbl" runat="server" Text="Confirmation Password"></asp:Label>
        <asp:TextBox ID="ConfirmPasswordTB" runat="server" TextMode="Password"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="DobLbl" runat="server" Text="Date of Birth"></asp:Label>
        <asp:Calendar ID="DobCalendar" runat="server"></asp:Calendar>
    </div>
    <div>
        <asp:Label ID="lbError" ForeColor="Red" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="ReisterBtn" runat="server" Text="Register" OnClick="ReisterBtn_Click" />
    </div>
    <div>
        <asp:Label ID="lbRegister" runat="server" Text="Have an account? "></asp:Label>
        <a href="login.aspx">Login</a>
    </div>
</asp:Content>
