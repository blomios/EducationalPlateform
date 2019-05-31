<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Uploadfile.ascx.cs" Inherits="LO54_Projet.Controllers.Uploadfile" %>
                <p>
 <asp:FileUpload  runat="server" ID="fuSample" />
        </p>
<p>
        <asp:Button  runat="server" ID="btnUpload" Text="Upload" 
                onclick="btnUpload_Click" />
                </p>
<p>
                <asp:Label runat="server" ID="lblMessage" ForeColor="#00CC00"></asp:Label>
</p>

