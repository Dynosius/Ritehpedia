<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Create_account.aspx.cs" Inherits="Create_account" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Izradite novi račun</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <style>
        .center {
            text-align: center;
        }

        .right {
            text-align: right;
        }

        .centerBlock {
            position: fixed;
            top: 66%;
            left: 66%;
            width: 50%;
            height: 200px;
            margin: -100px 0 0 -25%;
        }

        .auto-style1 {
            height: 22px;
        }

        .errorCode {
            color: red;
        }

        .auto-style2 {
            height: 39px;
        }
        .auto-style3 {
            height: 42px;
        }
    </style>
</head>
<body>
    <h1 style="text-align: center; background-color: #CCFFFF;">Izradite korisnički račun</h1>

    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel runat="server">
        <ContentTemplate>
        <div>
            <table class="table">
                <tr>
                    <td class="auto-style1">Korisničko ime:</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="Username" runat="server" OnTextChanged="Username_TextChanged" Autopostback = "true"> </asp:TextBox><!--AutoPostBack="true" , za autopostback dinamicki poziv funkcije-->
                        &nbsp;<asp:Label ID="LabelUsernamePostoji" runat="server" ForeColor="Red" Text="Username već postoji" Visible="False"></asp:Label>
                        &nbsp;<asp:RequiredFieldValidator ID="ValidatorName" runat="server" ControlToValidate="Username" ErrorMessage="Molimo unesite vaši username" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style3">Lozinka:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="ValidatorLozinka" runat="server" ErrorMessage="Molimo unesite vašu lozinku" ControlToValidate="Password" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Potvrdi lozinku:</td>
                    <td>
                        <asp:TextBox ID="Confirmpass" runat="server" TextMode="Password"></asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="ValidatorLozinka2" runat="server" ErrorMessage="Molimo unesite ponovo lozinku" ControlToValidate="Confirmpass" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidatorlozinka" runat="server" ErrorMessage="Unijeli ste pogrešnu lozinku" ForeColor="Red" ControlToCompare="Password" ControlToValidate="Confirmpass"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>Ime:</td>
                    <td>
                        <asp:TextBox ID="Name" runat="server">

                        </asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="ValidatorIme" runat="server" ErrorMessage="Molimo unesite vaše ime" ForeColor="Red" ControlToValidate="Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Prezime:</td>
                    <td>
                        <asp:TextBox ID="Surname" runat="server">

                        </asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="ValidatorPrezime" runat="server" ErrorMessage="Molimo unesite vaše prezime" ForeColor="Red" ControlToValidate="Surname"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="Email" runat="server" OnTextChanged="Email_TextChanged">
                        </asp:TextBox>
                        &nbsp;
                        <asp:RequiredFieldValidator ID="ValidatorMail" runat="server" ErrorMessage="Molimo unesite vaši email" ForeColor="Red" ControlToValidate="Email"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Email" ErrorMessage="Molimo unesite ispravan mail" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>*Grad:</td>
                    <td dir="ltr">
                        <asp:TextBox ID="City" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>*Adresa:</td>
                    <td dir="ltr">
                        <asp:TextBox ID="adress" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>*Broj telefona (09x... - sve spojeno bez znakova):</td>
                    <td dir="ltr">
                        <asp:TextBox ID="tel" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Datum rođenja:
                    </td>
                    <td>Dan: 
                        <asp:TextBox ID="day" runat="server"></asp:TextBox>
                        &nbsp;
                        <asp:RangeValidator ID="dvalidator" runat="server" Type="Integer" MinimumValue="1" MaximumValue="31" ErrorMessage="Unesite pravilan dan" ControlToValidate="day" SetFocusOnError="True" CssClass="errorCode"></asp:RangeValidator>
                        Mjesec:
                        <asp:TextBox ID="month" runat="server"></asp:TextBox>
                        &nbsp;
                        <asp:RangeValidator ID="mvalidator" runat="server" Type="Integer" MinimumValue="1" MaximumValue="12" ErrorMessage="Unesite pravilan mjesec" ControlToValidate="month" CssClass="errorCode"></asp:RangeValidator>
                        Godina:
                        <asp:TextBox ID="year" runat="server"></asp:TextBox>
                        &nbsp;
                        <asp:RangeValidator ID="yvalidator" runat="server" Type="Integer" MinimumValue="1930" MaximumValue="2010" ErrorMessage="Unesite pravilnu godinu" ControlToValidate="year" SetFocusOnError="True" CssClass="errorCode"></asp:RangeValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="day" ErrorMessage="Molimo unesite dan" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="month" ErrorMessage="Molimo unesite mjesec" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="year" ErrorMessage="Molimo unesite godinu" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Odabir kolegija</td>
                    <td class="auto-style2">
                        <asp:DropDownList runat="server" ID="kolegijLista" AutoPostBack="True">
                            <asp:ListItem>Računarstvo</asp:ListItem>
                            <asp:ListItem>Elektrotehnika</asp:ListItem>
                            <asp:ListItem>Brodogradnja</asp:ListItem>
                            <asp:ListItem>Strojarstvo</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <!-- button -->
                <tr>
                    <td style="text-align: center;" colspan="2">
                        <asp:Button ID="backButton" runat="server" Text="Povratak" PostBackUrl="~/Login.aspx" Width="5%" CausesValidation="False"/>
                        <asp:Button ID="sendButton" runat="server" Text="Registriraj se" Width="10%" OnClick="sendButton_Click" />
                    </td>
                </tr>
            </table>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <p>
        &nbsp; * - polja označena zvjezdicom nisu obvezna za ispunjavanje
    </p>
    <asp:Label runat="server" ID="ErrorMessage" ForeColor="Red">

    </asp:Label>
</body>
</html>





