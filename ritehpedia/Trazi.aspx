<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Trazi.aspx.cs" Inherits="Trazi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" Runat="Server">

    <ul class="nav nav-pills flex-column">
       <asp:Repeater runat="server" ID="ClanakRepeater">
            <ItemTemplate>
                <div class="box content">
                    <article class="post">
                        <a href="Clanak.aspx?idClanak=<%# Eval("idClanak") %>"><%# Eval("naslov") %></a>

                        <div class="media">
                            <div class="media-left">
                                <p class="image is-32x32">
                                    <img src="slike/96x96.png" />
                                </p>
                            </div>

                            <div class="media-content">
                                <div class="content">
                                    <p>
                                        Kreirao: <a href="#">User</a>
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
    </ul>
</asp:Content>
