<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolderMaster" runat="server">

    

    <div class="column is-9 box" runat="server" style="margin:0 auto" >

        <h1 class="title">Članci:</h1>

        <nav class="navbar is-white">
            <div class="container">
                <div class="navbar-menu">
                    <div class="navbar-start">
                        <a class="navbar-item is-active" href="#">Popular</a>
                        <a class="navbar-item" href="#">Recent</a>
                        <a class="navbar-item" href="#">Rising</a>
                    </div>
                    <div class="navbar-end">
                        
                    </div>
                </div>
            </div>
        </nav>
        <br />


        <asp:Repeater runat="server" ID="ClanakRepeater">
            <ItemTemplate>
                <div class="box content">
                    <article class="post">
                        <a href="Clanak.aspx?idClanak=<%# Eval("idClanak") %>"><%# Eval("naslov") %></a>

                        <div class="media">
                            <div class="media-left">
                                <p class="image is-32x32">
                                    <img src="slike/96x96.png">
                                </p>
                            </div>

                            <div class="media-content">
                                <div class="content">
                                    <p>
                                        Kreirao: <a href="#"> <%# Eval("Korisnik") %></a>
                                        <br />
                                        <span class="tag">Tag</span>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </article>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        
        <nav class="pagination" role="navigation" aria-label="pagination">
        <a class="pagination-previous">Previous</a>
        <a class="pagination-next">Next page</a>
        <ul class="pagination-list">
            <li>
                <a class="pagination-link" aria-label="Goto page 1">1</a>
            </li>
            <li>
                <span class="pagination-ellipsis">&hellip;</span>
            </li>
            <li>
                <a class="pagination-link" aria-label="Goto page 45">45</a>
            </li>
            <li>
                <a class="pagination-link is-current" aria-label="Page 46" aria-current="page">46</a>
            </li>
            <li>
                <a class="pagination-link" aria-label="Goto page 47">47</a>
            </li>
            <li>
                <span class="pagination-ellipsis">&hellip;</span>
            </li>
            <li>
                <a class="pagination-link" aria-label="Goto page 86">86</a>
            </li>
        </ul>
    </nav>
    </div>




    <ul class="nav nav-pills flex-column">
    </ul>
</asp:Content>

