<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="kontakt.aspx.cs" Inherits="kontakt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMaster" runat="Server">

    <div class="box" align="center" style="width: 750px; margin-right: auto; margin-left: auto">
        <h1 class="title" >Kontakti</h1>

        <table class="table">
            <thead>
                <tr>
                    <th>
                        Ime</th>
                    <th>Prezime</th>
                    <th>Broj Telefona
                        </th>
                    <th>
                        E - Mail</th>
                    <th>Facebook
                        </th>
                </tr>
            </thead>
            <tbody>
                <td>Dino</td>
                <td>Kralj</td>
                <td>**********</td>
                <td>dinokraljmusic@gmail.com</td>
                <td>
                    <span class="icon">
                        <a href="https://www.facebook.com/TheDyn0"><i class="fab fa-facebook"></i></a>
                    </span>
                </td>
            </tbody>
            <tbody>
                <td>Maikol</td>
                <td>Hrvatin</td>
                <td>**********</td>
                <td>?</td>
                <td>
                    <span class="icon">
                        <a href="https://www.facebook.com/maikol.hrvatin"><i class="fab fa-facebook"></i></a>
                    </span>
                </td>
            </tbody>
            <tbody>
                <td>Dino</td>
                <td>Cifrić</td>
                <td>**********</td>
                <td>cifridino@gmail.com</td>
                <td>
                    <span class="icon">
                        <a href="https://www.facebook.com/metamemelord"><i class="fab fa-facebook"></i></a>
                    </span>
                </td>
            </tbody>
        </table>
        
    </div>
    <br />
</asp:Content>

