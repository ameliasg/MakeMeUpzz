<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/HeaderBrand.Master" AutoEventWireup="true" CodeBehind="BrandPage.aspx.cs" Inherits="Project.Views.Brand_Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Brand Page</h1>
    <hr />
    <div>
        <asp:GridView ID="BrandGridView" runat="server" AutoGenerateColumns="False" OnRowDeleting="BrandGridView_RowDeleting" OnRowEditing="BrandGridView_RowEditing" >
            <Columns>
                <asp:BoundField DataField="MakeupBrandID" HeaderText="BrandID" SortExpression="MakeupBrandID" />
                <asp:BoundField DataField="MakeupBrandName" HeaderText="Name" SortExpression="MakeupBrandName" />
                <asp:BoundField DataField="MakeupBrandRating" HeaderText="Rating" SortExpression="MakeupBrandRating" />
                <asp:CommandField ButtonType="Button" HeaderText="Actions" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
