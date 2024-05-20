<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/HeaderType.Master" AutoEventWireup="true" CodeBehind="TypePage.aspx.cs" Inherits="Project.Views.TypePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Type Page</h1>
    <hr />
    <div>
        <asp:GridView ID="TypeGridView" runat="server" AutoGenerateColumns="False" OnRowDeleting="TypeGridView_RowDeleting" OnRowEditing="TypeGridView_RowEditing" >
            <Columns>
                <asp:BoundField DataField="MakeupTypeID" HeaderText="TypeID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupTypeName" HeaderText="Type" SortExpression="MakeupTypeName" />
                <asp:CommandField ButtonType="Button" HeaderText="Actions" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

