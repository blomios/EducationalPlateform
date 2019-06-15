<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DownloadFile.ascx.cs" Inherits="LO54_Projet.Controllers.DownloadFile" %>
<p>
    <asp:Label runat="server" ID="NameFile" ForeColor="#000000"></asp:Label>
</p>
<p>
      <asp:Button id="Button1"
           Text="Download"
           OnClick="GreetingBtn_Click" 
           runat="server"/>
      <br />

      <asp:Button id="Button2"
           Text="Delete"
           OnClick="Delete_Click" 
           runat="server"/>
      <br />
</p>
<hr />
