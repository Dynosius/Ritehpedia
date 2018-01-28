<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderMaster" runat="server">
    <h1>Dobrodošli na Ritehpediu!</h1>

    
    <ul class="nav nav-pills flex-column">
        <asp:Repeater runat="server" ID="ClanakRepeater">
            <ItemTemplate>
                <li class="nav-item">
                   <a href="Clanak.aspx?idClanak=<%# Eval("idClanak") %>" onserverclick="prikazIncrement(<%# Eval("idClanak") %>)"><%# Eval("naslov") %></a>

                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

    
</asp:Content>
