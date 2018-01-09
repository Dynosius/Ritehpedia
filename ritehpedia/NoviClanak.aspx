<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NoviClanak.aspx.cs" Inherits="NoviClanak" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <div>
        <asp:Label runat="server" ID="dodajClanakLabel" Font-Size="X-Large">Dodaj novi članak</asp:Label><br />
        Naslov:
        <br />
        <asp:TextBox ID="naslovClanka" runat="server">

        </asp:TextBox><br />

        Tekst:<br />
        <textarea runat="server" id="textareaNoviClanak" style="width: 806px; height: 207px">

        </textarea>
        <br />
        Kolegij: <asp:DropDownList runat="server" ID="KolegijiDropDown">

        </asp:DropDownList>
        Kategorija: <asp:DropDownList runat="server" ID="KategorijeDropDown">

        </asp:DropDownList>
        <asp:Button runat="server" CssClass="btn btn-primary" Text="Objavi" OnClick="ObjaviClanakClick"/><br />
        <asp:Label runat="server" ID="infoLabel" Font-Size="X-Large" Font-Bold="True" ForeColor="#66FF33"></asp:Label>
    </div>

</asp:Content>

