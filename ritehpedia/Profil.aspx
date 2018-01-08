<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profil.aspx.cs" Inherits="Profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <h1>Osobni podaci korisnika</h1>
    <br />
    <br />
    <table>
        <tr>
            <td><asp:Label runat="server" ID="Label1">Ime:&nbsp</asp:Label></td>
            <td><asp:TextBox runat="server" ID="txt1"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label2">Prezime:&nbsp</asp:Label></td>
            <td><asp:TextBox runat="server" ID="txt2"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label3">Adresa:&nbsp</asp:Label></td>
            <td><asp:TextBox runat="server" ID="txt3"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label4">Grad:&nbsp</asp:Label></td>
            <td><asp:TextBox runat="server" ID="txt4"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="Label5">Broj telefona:&nbsp</asp:Label></td>
            <td><asp:TextBox runat="server" ID="txt5"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Button runat="server" Text="Primjeni izmjene" OnClick="IzmjeniPodatke"/>
    <asp:Label ID="success" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#66FF66"></asp:Label>
    </asp:Content>

