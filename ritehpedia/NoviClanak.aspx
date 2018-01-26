<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NoviClanak.aspx.cs" Inherits="NoviClanak" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <div>
        <asp:Label runat="server" ID="dodajClanakLabel" Font-Size="X-Large">Dodaj novi članak</asp:Label><br />
        Naslov:
        <br />
        <asp:TextBox ID="naslovClanka" runat="server">

        </asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="naslovClanka" ErrorMessage="RequiredFieldValidator" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />

        Tekst:<br />
        <textarea runat="server" id="textareaNoviClanak" style="width: 806px; height: 207px">

        </textarea>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="textareaNoviClanak" ErrorMessage="RequiredFieldValidator" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        Upload file:<br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        Kolegij: <asp:DropDownList runat="server" ID="KolegijiDropDown">

        </asp:DropDownList>
        Kategorija: <asp:DropDownList runat="server" ID="KategorijeDropDown">

        </asp:DropDownList>
        <asp:Button runat="server" CssClass="btn btn-primary" Text="Objavi" OnClick="ObjaviClanakClick"/><br />
        <asp:Label runat="server" ID="infoLabel" Font-Size="X-Large" Font-Bold="True" ForeColor="#66FF33"></asp:Label>
    </div>

</asp:Content>

