<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Create_account.aspx.cs" Inherits="Create_account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style3 {
            margin-left: 646px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <p>
        <asp:Table ID="Table1" runat="server" BackColor="Aqua" BorderColor="#333300" BorderStyle="Dashed" Height="73px" Width="117px" GridLines="Both">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:HyperLink ID="HyperLink1" runat="server" Text="Home" NavigateUrl="~/index.aspx">Home</asp:HyperLink>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:HyperLink ID="HyperLink2" runat="server" Text="Login" NavigateUrl="~/Login.aspx">Login</asp:HyperLink>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:HyperLink ID="HyperLink3" runat="server" Text="About" NavigateUrl="~/About.aspx">About</asp:HyperLink>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <%--                            <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="#CCFFFF" BorderColor="Black" BorderStyle="Groove" CssClass="auto-style3">
                                <WizardSteps>
                                    <asp:CreateUserWizardStep runat="server">
                                        <ContentTemplate>
                                            <label>Ovo je moj template za content</label>
                                            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:CreateUserWizardStep>
                                    <asp:CompleteWizardStep runat="server">
                                        <ContentTemplate>
                                            <label>Ovo je moj template za complete</label>
                                        </ContentTemplate>
                                    </asp:CompleteWizardStep>
                                </WizardSteps>
                            </asp:CreateUserWizard>--%>

        <asp:Table ID="CreateAccount" runat="server" HorizontalAlign="Center" BorderColor="#CCFF66">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server">Korisničko ime:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="username" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server">Lozinka:</asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button runat="server" Text="Pošalji" onClick="Send_click" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
    </p>
</asp:Content>


