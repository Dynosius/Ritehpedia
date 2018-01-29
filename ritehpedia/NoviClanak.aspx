<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NoviClanak.aspx.cs" Inherits="NoviClanak" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <div class="box" style="width: 1000px; margin-right: auto; margin-left: auto">
        <asp:Label CssClass="title" runat="server" ID="dodajClanakLabel" Font-Size="X-Large">Dodaj novi članak</asp:Label><br />
        <br />
        <div class="field">
            <div class="control">
            <label style="text-align: left;" class="label">Naslov:</label>
        <asp:TextBox  CssClass= "input" ID="naslovClanka" runat="server">

        </asp:TextBox><br />
        </div>
            </div>
       <div class="field">
           <div class="control">
               <label style="text-align: left;" class="label">Tekst:</label>
        <textarea  class="input" runat="server" id="textareaNoviClanak" style="width: 1000px; height: 207px">

        </textarea>
       </div> 
       </div>
        <br />
        Kolegij: <asp:DropDownList   runat="server" ID="KolegijiDropDown">

        </asp:DropDownList>
        Kategorija: <asp:DropDownList runat="server" ID="KategorijeDropDown">

        </asp:DropDownList>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <br />
        <asp:Button runat="server" CssClass="button is-success" Text="Objavi" OnClick="ObjaviClanakClick"/><br />
        <asp:Label runat="server" ID="infoLabel" Font-Size="X-Large" Font-Bold="True" ForeColor="#66FF33" CssClass></asp:Label>
    </div>
    <br />
</asp:Content>
