<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="Admin_AdminPage" %>



<asp:Content ContentPlaceHolderID="ContentPlaceHolderMaster" runat="server">
    <div>
        <b>Create a New Role:<br />
&nbsp;</b><asp:TextBox ID="RoleName" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="CreateRoleButton" runat="server" Text="Create Role" OnClick="CreateRoleButton_Click1" />
        <asp:GridView ID="RoleList" runat="server" OnRowDeleting="RoleList_RowDeleting" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:TemplateField HeaderText="Role">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="RoleNameLabel" Text='<%# Bind("uloga") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Izbriši" ShowDeleteButton="True" ShowHeader="True" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
        <asp:Label runat="server" ID="StatusLabel"></asp:Label>
    </div>
    <div>
        <b>Edit user roles:
        </b>
        <asp:GridView runat="server" ID="UserListGridView" OnRowCancelingEdit="UserListGridView_RowCancelingEdit" OnRowEditing="UserListGridView_RowEditing" OnRowUpdating="UserListGridView_RowUpdating" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            
            <Columns>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
            
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />

        </asp:GridView>
    </div>

</asp:Content>
