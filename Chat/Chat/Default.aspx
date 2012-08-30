<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Chat._Default" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <!-- mest praktisk at hente jQuery-versionen ned lokalt og henvise til den fremfor at henvise til et link.
    På denne måde ved vi altid hvilken version vi henviser til og dermed har vi kontrol over om koden fejler eller ej -->
    <script src="http://code.jquery.com/jquery.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            //Code execute on page load
            $(document).on("click", function (event) {
                //Global on-click function
                
                if ($(event.target).hasClass("btn")) {
                    event.preventDefault();
                    $("#TextHere").load("AjaxLoadFromServer.aspx #container");
                }
            });
        });
    </script>

    <style type="text/css">
        #Message
        {
            width: 612px;
            height: 98px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:ListBox ID="Chat" runat="server" Height="200px" Width="904px"></asp:ListBox> <br /><br /><br />
        <asp:TextBox ID="Message" runat="server" TextMode="MultiLine" Rows="5" 
            Width="789px"></asp:TextBox>
        <asp:Button ID="Submit" class="btn" runat="server" Text="Submit" onclick="Submit_Click" 
            Height="82px" Width="93px" /><br />
    </div>
    <div id="TextHere">

    </div>
</asp:Content>
