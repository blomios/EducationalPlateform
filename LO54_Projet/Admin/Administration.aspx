<%@ Page Title="Administration des utilisateurs de l'application" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administration.aspx.cs" Inherits="LO54_Projet.Administration.Administration" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <br />
        <h3>Liste des utilisateurs</h3>
        <hr />
        <div>


            <asp:SqlDataSource ID="SqlDataSource_users" runat="server" ConnectionString="<%$ ConnectionStrings:TestReel %>" SelectCommand="SELECT [Id], [Nom], [Prenom], [UserName], [Email], [Role] FROM [AspNetUsers]">
            </asp:SqlDataSource>
        <asp:GridView ID="GridView_Users" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="10" CssClass="table" DataSourceID="SqlDataSource_users" ForeColor="#333333" AutoGenerateEditButton="True" DataMember="DefaultView" OnRowUpdating="GridView_Users_RowUpdating" DataKeyNames="Id">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Id"  HeaderText="Id" SortExpression="Id" ReadOnly="True" />
                <asp:BoundField DataField="Nom" HeaderText="Nom" SortExpression="Nom" ReadOnly ="True"/>
                <asp:BoundField DataField="Prenom" HeaderText="Prenom" SortExpression="Prenom" ReadOnly ="true"/>
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"/>
                <asp:BoundField DataField="Role" HeaderText="Role" SortExpression="Role" />
            </Columns>
            <HeaderStyle BackColor="#5D7B9D" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" />
        </asp:GridView>


        </div>
       
    </div>



</asp:Content>