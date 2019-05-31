<%@ Page Title="Liste des UVs existantes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListUV.aspx.cs" Inherits="LO54_Projet.UVS.ListUV" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    
    <div class ="form-horizontal">
        <div style="text-align: right; margin-bottom: 15px;">
            <asp:Button ID="Button_Go_Add_UV" runat="server" BorderStyle="None" CssClass="btn active" Text="Ajouter une UV" OnClick="Button_Go_Add_UV_Click" />
        </div>
        <asp:GridView ID="GridView_UVs" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="10" CssClass="table" DataSourceID="SqlDataSource_UVs" ForeColor="#333333" onrowdatabound="GridView_RowDataBound" OnRowUpdating="GridView_UVs_RowUpdating" OnSelectedIndexChanged="GridView_UVs_OnSelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowEditButton="true" />
                <asp:BoundField DataField="Denomination" HeaderText="Denomination" SortExpression="Denomination" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Email" HeaderText="Owner" SortExpression="Owner" ReadOnly="true" />
            </Columns>
            <HeaderStyle BackColor="#5D7B9D" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource_UVs" runat="server" ConnectionString="<%$ ConnectionStrings:TestReel %>" 
            SelectCommand="SELECT uv.[Denomination], uv.[Description], usr.[Email], uv.[Owner] AS OwnerId 
                           FROM [UVs] uv INNER JOIN [AspNetUsers] usr ON uv.owner = usr.id " OnSelecting="SqlDataSource_UVs_Selecting">
        </asp:SqlDataSource>
    </div>

</asp:Content>
