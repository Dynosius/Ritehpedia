<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderMaster" Runat="Server">
    <asp:Login ID="Login1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" CssClass="auto-style3" Font-Names="Verdana" Font-Size="10pt" Height="132px" Width="363px" CreateUserText="Novi korisnički račun" CreateUserUrl="~/Create_account.aspx" LoginButtonText="Dalje" PasswordLabelText="Lozinka:" RememberMeText="Zapamti me" TitleText="Prijava" UserNameLabelText="Korisničko ime:">
    <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
</asp:Login>
</asp:Content>

