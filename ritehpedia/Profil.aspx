<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profil.aspx.cs" Inherits="Profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">



    <div class="box" style="width: 500px; margin-right: auto; margin-left: auto">
        <h1 style="text-align: center" class="title">Osobni podaci korisnika</h1>
        <div class="field">

            <asp:Label runat="server" ID="Label1" CssClass="label">Ime:&nbsp</asp:Label>

            <asp:TextBox runat="server" ID="txt1" CssClass="input"></asp:TextBox>
             <asp:RequiredFieldValidator ID="ValidatorIme" runat="server" ErrorMessage="Molimo unesite vaše ime" ControlToValidate="txt1" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="field">

            <asp:Label runat="server" ID="Label2" CssClass="label">Prezime:&nbsp</asp:Label>

            <asp:TextBox runat="server" ID="txt2" CssClass="input"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ValidatorPrezime" runat="server" ErrorMessage="Molimo unesite vaše prezime" ControlToValidate="txt2" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="field">

            <asp:Label runat="server" ID="Label3" CssClass="label">Adresa:&nbsp</asp:Label>

            <asp:TextBox runat="server" ID="txt3" CssClass="input"></asp:TextBox>
        </div>
        <div class="field">

            <asp:Label runat="server" ID="Label4" CssClass="label">Grad:&nbsp</asp:Label>

            <asp:TextBox runat="server" ID="txt4" CssClass="input"></asp:TextBox>
        </div>
        <div class="field">

            <asp:Label runat="server" ID="Label5" CssClass="label">Broj telefona:&nbsp</asp:Label>

            <asp:TextBox runat="server" ID="txt5" CssClass="input"></asp:TextBox>
        </div>
        <br />
        <div class="field is-grouped">
            <div class="control">
                <asp:Button runat="server" Text="Primjeni izmjene" OnClick="IzmjeniPodatke" CssClass="button is-link" />
            </div>

            <div class="control">
                <asp:Label ID="success" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#66FF66"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>