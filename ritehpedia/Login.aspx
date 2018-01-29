<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <div class="box" align="center" style="width: 500px; margin-right: auto; margin-left: auto">
        <asp:login id="LoginControl" runat="server" createusertext="Novi korisnički račun" createuserurl="~/Create_account.aspx" loginbuttontext="Dalje" passwordlabeltext="Lozinka:" remembermetext="Zapamti me" titletext="Prijava" usernamelabeltext="Korisničko ime:" failuretext="Unijeli ste pogrešno korisničko ime ili lozinku.">
            <LayoutTemplate>
                <h1 class="title" style="text-align:center">Login</h1>
                    <div class="field">                       
                        <label style="text-align: left;" class="label">Korisničko ime:</label>
                            <div class="control has has-icons-left has-icons-right ">
                                <asp:TextBox ID="UserName" runat="server" CssClass="input"></asp:TextBox>
                                 <span class="icon is-small is-left">
                                    <i class="fas fa-user"></i>
                                  </span>
                                  <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="LoginControl"> 
                                    <span class="icon is-small is-right">
                                        <i class="fas fa-exclamation-triangle"></i>
                                    </span>
                                   </asp:RequiredFieldValidator>
                            </div>
                    </div>
                    <div class="field">
                        <label style="text-align:left;" class="label">Lozinka:</label>
                            <div class="control has-icons-left has-icons-right">
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="input"></asp:TextBox>
                                    <span class="icon is-small is-left">
                                        <i class="fas fa-user"></i>
                                    </span>    
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="LoginControl">
                                    <span class="icon is-small is-right">
                                        <i class="fas fa-exclamation-triangle"></i>
                                    </span>
                                </asp:RequiredFieldValidator>
                            </div>
                    </div>                 
                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    <div class="field is-grouped">
                        <div class="control">
                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" OnClick="LoginButton_Click" Text="Login" ValidationGroup="LoginControl" CssClass="button is-link"/>
                        </div>
                        <div class="control">
                            <asp:HyperLink ID="CreateUserLink" runat="server" NavigateUrl="~/Create_account.aspx" CssClass="button is-text">Registriraj se</asp:HyperLink>
                        </div>
                    </div>
            </LayoutTemplate>            
        </asp:login>
    </div>
    <br />
</asp:Content>



