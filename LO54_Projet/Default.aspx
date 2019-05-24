<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LO54_Projet._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Accéder au CRUD des UVs</h2>
            <p>

            <asp:Button ID="Button1" runat="server" CssClass="btn-primary" OnClick="Button1_Click" Text="CRUD UVs" />

            </p>
        </div>
         <div class="col-md-4">
            <h2>Accéder au CRUD des QUIZZ</h2>
            <p>

            <asp:Button ID="Button3" runat="server" CssClass="btn-primary" OnClick="Button3_Click" Text="CRUD QUIZZ" />

            </p>
        </div
        <div class="col-md-4">
            <h2>Affichage des informations :</h2>
            <p>
                <asp:GridView ID="GridViewToto" runat="server" AutoGenerateColumns="False" CellPadding="10" DataSourceID="SqlDataSourceUsers" ForeColor="#333333" AllowSorting="True" OnSelectedIndexChanged="GridViewToto_SelectedIndexChanged" CssClass="table">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                        <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" />
                        <asp:BoundField DataField="Prenom" HeaderText="Prenom" SortExpression="Prenom" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSourceUsers" runat="server" ConnectionString="<%$ ConnectionStrings:TestReel %>" SelectCommand="SELECT [UserName], [Nom], [Prenom] FROM [AspNetUsers]"></asp:SqlDataSource>
                <asp:EntityDataSource ID="EntityDataSourceUsers" runat="server">
                </asp:EntityDataSource>
                <asp:SqlDataSource ID="SqlDataSourceToto" runat="server" ConnectionString="<%$ ConnectionStrings:TestConnection %>" SelectCommand="SELECT * FROM [toto]"></asp:SqlDataSource>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Remise à 0</h2>
            <p>
                DELETE</p>
            <p>
                &nbsp;<asp:Button ID="Button2" runat="server" CssClass="btn-warning" OnClick="Button2_Click" Text="Delete" />
            </p>
        </div>
    </div>

</asp:Content>
