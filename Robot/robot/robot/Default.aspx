<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="robot._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to The game of Robot Wars!
    </h2>
    <div>
        Upload the game file of Robot # 1
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </div>
    <div>
        Upload the game file of Robot # 2
        <asp:FileUpload ID="FileUpload2" runat="server" />
    </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Initiate Robot War" />
    </div>
        
    <p>
        
    </p>
</asp:Content>
