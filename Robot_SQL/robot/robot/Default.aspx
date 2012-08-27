<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="robot._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to The game of Robot Wars!
    </h2>
    <div>
        <!-- <asp:Label ID="Label2" runat="server" Text="Upload the game file of Robot # 1"></asp:Label> -->
        <asp:Label ID="Label9" runat="server" Text="Upload a gamefile of a robot"></asp:Label>
        <asp:FileUpload ID="FileUpload3" runat="server" />
        <asp:Button ID="Button5" runat="server" Text="Upload" 
            onclick="Button5_Click" />
        <!-- <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button3" runat="server" Text="Upload" /> -->
    </div>
    <!-- <div>
        <asp:Label ID="Label3" runat="server" Text="Upload the game file of Robot # 2"></asp:Label>
        <asp:FileUpload ID="FileUpload2" runat="server" />
    </div>
    <div>
        <asp:Label ID="Label4" runat="server" Text="Number of Rounds"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Initiate Robot War" 
            onclick="Button1_Click" />
    </div> -->
    
    <div id="files" runat="server">
        <asp:Label ID="Label7" runat="server" Text="War between "></asp:Label>

        <asp:DropDownList ID="RobotHome" runat="server">
        </asp:DropDownList>
        
        <asp:Label ID="Label5" runat="server" Text=" and "></asp:Label>
        <asp:DropDownList ID="RobotAway" runat="server">
        </asp:DropDownList>
        <asp:Label ID="Label6" runat="server" Text=" fought over a maximum of "></asp:Label>
        <asp:DropDownList ID="Rounds" runat="server">
        </asp:DropDownList>
        <asp:Label ID="Label8" runat="server" Text=" rounds"></asp:Label>
    </div>
    <div>
        <asp:Button ID="Button2" runat="server" Text="Initiate war!" 
            onclick="Button2_Click" />
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Battlefield"></asp:Label>
    </div>
    <div id="downLinks">
        <a href="robot1.xml">Robot 1 - Altered game file</a> 
        <a href="robot2.xml">Robot 2 - Altered game file</a>
    </div> 
</asp:Content>
