<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Trazi.aspx.cs" Inherits="Trazi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" Runat="Server">

    <ul class="nav nav-pills flex-column">
        <asp:Repeater runat="server" ID="ClanakRepeater">
            <ItemTemplate>
                <li class="nav-item">
                   <a href="Clanak.aspx?idClanak=<%# Eval("idClanak") %>"><%# Eval("naslov") %></a>

                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</asp:Content>
