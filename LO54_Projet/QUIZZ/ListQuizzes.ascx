﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListQuizzes.ascx.cs" Inherits="LO54_Projet.Controllers.ListQuizzes" %>

<asp:GridView ID="GridView_Projects" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="10" CssClass="table" DataSourceID="SqlDataSource_Projects" ForeColor="#333333" 
                OnRowDataBound="GridView_RowDataBound" OnSelectedIndexChanged="GridView_OnSelectedIndexChanged" OnRowCommand="GridView_OnRowCommand">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="Name" HeaderText="Nom" SortExpression="Name" />
        <asp:BoundField DataField="Score" HeaderText="Note" SortExpression="Score" />
        <asp:BoundField DataField="ScoreMax" HeaderText="Maximum" SortExpression="ScoreMax" />
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="btn_del" runat="server" Text="Supprimer" CssClass="btn btn-danger btn-sm" CommandName="del" CommandArgument='<%# Eval("IdQuizz") %>' OnClientClick="return confirm('Voulez-vous vraiment supprimer ce quizz ? Cette action est irreversibe.')" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <HeaderStyle BackColor="#5D7B9D" ForeColor="White" />
    <RowStyle BackColor="#F7F6F3" />
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource_Projects" runat="server" ConnectionString="<%$ ConnectionStrings:TestReel %>" >
</asp:SqlDataSource>
