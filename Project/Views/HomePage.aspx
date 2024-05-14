<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Header.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Project.Views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Home Page</h1>
    <hr />
    <div>
        <asp:GridView ID="MakeupGridView" runat="server" AutoGenerateColumns="False" OnRowDeleting="MakeupGridView_RowDeleting" OnRowEditing="MakeupGridView_RowEditing">
            <Columns>
                <asp:BoundField DataField="MakeupID" HeaderText="ID" SortExpression="MakeupID" />
                <asp:BoundField DataField="MakeupName" HeaderText="Makeup Name" SortExpression="MakeupName" />
                <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="MakeupPrice" />
                <asp:BoundField DataField="MakeupWeight" HeaderText="Weight" SortExpression="MakeupWeight" />
                <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Type" SortExpression="MakeupType.MakeupTypeName" />
                <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Brand" SortExpression="MakeupBrand.MakeupBrandName" />
                <asp:CommandField ButtonType="Button" HeaderText="Actions" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
