<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
    <tr>
        <td class="auto-style2" style="background-color: #3399FF; width: 200px; padding-left: 10px;">
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/index.aspx">HyperLink</asp:HyperLink>
            <br />
            <br />
            <br />
            <br />
            <br />
        </td>
        <td class="auto-style2" style="background-color: #FFFFFF"></td>
        <td class="auto-style2" style="background-color: #0099FF; width: 200px; padding-left: 10px;">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/index.aspx">HyperLink</asp:HyperLink>
            <br />
            <br />
            <br />
            <br />
            <br />
        </td>
    </tr>
</table>
</asp:Content>

