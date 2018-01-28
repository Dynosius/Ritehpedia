<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Clanak.aspx.cs" Inherits="Clanak" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">
    <asp:Label runat="server" ID="naslovLabel"></asp:Label>
    <br />
    <asp:Label runat="server" ID="brPregledaLabel"></asp:Label>
    <br />
    <asp:Label runat="server" ID="clanakLabel"></asp:Label>
    <br />
    <asp:Label runat="server" ID="downloadLabel"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton1" runat="server" Text="Download attachment" OnClick="DownloadFile"></asp:LinkButton>
    <br />
    <asp:Button runat="server" ID="DeleteButton" Text="Izbriši članak" OnClick="DeleteButton_Click" Visible="false" />
</asp:Content>
