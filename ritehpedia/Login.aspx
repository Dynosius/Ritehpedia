<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <div style="text-align: center">
        <div style="width: 400px; margin-left: auto; margin-right: auto;">
            <asp:Login ID="LoginControl" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" CssClass="auto-style3" Font-Names="Verdana" Font-Size="10pt" Height="132px" Width="363px" CreateUserText="Novi korisnički račun" CreateUserUrl="~/Create_account.aspx" LoginButtonText="Dalje" PasswordLabelText="Lozinka:" RememberMeText="Zapamti me" TitleText="Prijava" UserNameLabelText="Korisničko ime:" FailureText="Unijeli ste pogrešno korisničko ime ili lozinku.">
                <LayoutTemplate>
                    <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                        <tr>
                            <td>
                                <table cellpadding="0" style="height: 132px; width: 363px;">
                                    <tr>
                                        <td align="center" colspan="2" style="color: White; background-color: #6B696B; font-weight: bold;">Prijava</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Korisničko ime:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="LoginControl">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Lozinka:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="LoginControl">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color: Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" OnClick="LoginButton_Click" Text="Dalje" ValidationGroup="LoginControl" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:HyperLink ID="CreateUserLink" runat="server" NavigateUrl="~/Create_account.aspx">Novi korisnički račun</asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
            </asp:Login>
        </div>
    </div>

</asp:Content>



