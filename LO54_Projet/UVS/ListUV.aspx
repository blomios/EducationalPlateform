<%@ Page Title="Liste des UVs existantes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListUV.aspx.cs" Inherits="LO54_Projet.UVS.ListUV" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    
    <div class ="form-horizontal">
        <div style="text-align: right; margin-bottom: 15px;">
            <asp:Button ID="Button_Go_Add_UV" runat="server" BorderStyle="None" CssClass="btn btn-success" Text="Ajouter une UV" OnClick="Button_Go_Add_UV_Click" />
        </div>
        <asp:GridView ID="GridView_UVs" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="10" CssClass="table" DataSourceID="SqlDataSource_UVs" ForeColor="#333333" 
                      OnRowDataBound="GridView_RowDataBound" OnSelectedIndexChanged="GridView_UVs_OnSelectedIndexChanged" OnRowCommand="GridView_UVs_OnRowCommand">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Denomination" HeaderText="Dénomination" SortExpression="Denomination" />
                <asp:BoundField DataField="Name" HeaderText="Nom" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Email" HeaderText="Responsable" SortExpression="Owner" ReadOnly="true" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btn_edit" runat="server" Text="Modifier" CssClass="btn btn-warning btn-sm" CommandName="edit" CommandArgument='<%# Eval("Denomination") %>' />
                        <asp:Button ID="btn_del" runat="server" Text="Supprimer" CssClass="btn btn-danger btn-sm" CommandName="del" CommandArgument='<%# Eval("Denomination") %>' OnClientClick="return confirm('Voulez-vous vraiment supprimer cette UV ? Cette action est irreversibe.')" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle BackColor="#5D7B9D" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource_UVs" runat="server" ConnectionString="<%$ ConnectionStrings:TestReel %>" 
            SelectCommand="SELECT uv.[IdUv], uv.[Denomination], uv.[Name], uv.[Description], usr.[Email], uv.[Owner] AS OwnerId 
                           FROM [UVs] uv INNER JOIN [AspNetUsers] usr ON uv.owner = usr.id ">
        </asp:SqlDataSource>
    </div>

</asp:Content>
