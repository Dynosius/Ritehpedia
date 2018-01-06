<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderMaster" runat="server">
    <div>
        <h1>
            Ritehpedia
        </h1>
        <hr />
        <p>
            Dobrodošli na studentsku stranicu ritehpedia</p>
        <hr />
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ritehpediaConnectionString %>" SelectCommand="SELECT [naslov], [brojPregleda], [idClanak] FROM [Clanak]"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="idClanak" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="naslov" HeaderText="Naslov" SortExpression="naslov" />
            <asp:BoundField DataField="brojPregleda" HeaderText="Broj Pregleda" SortExpression="brojPregleda" />
            <asp:BoundField DataField="idClanak" HeaderText="idClanak" InsertVisible="False" ReadOnly="True" SortExpression="idClanak" />
            <asp:HyperLinkField runat="server" navigateUrl="~/Clanak.aspx" Text="Prikaži više"/>
        </Columns>
    </asp:GridView>
<br />
<br />
<br />
<br />
<br />
<br />

    
</asp:Content>

