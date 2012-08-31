<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Chat._Default" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <!-- mest praktisk at hente jQuery-versionen ned lokalt og henvise til den fremfor at henvise til et link.
    På denne måde ved vi altid hvilken version vi henviser til og dermed har vi kontrol over om koden fejler eller ej -->
    <script src="http://code.jquery.com/jquery.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        v = 0;
        $(document).ready(function () {
            //Code execute on page load
            $(document).on("click", function (event) {
                //Global on-click function

                if ($(event.target).hasClass("btn")) {
                    event.preventDefault();
                    //currentScript = $(event.target).data("Chat");
                    //act = $(event.target).data("act");
                    uploadMessage = $("#MainContent_Message").val();    //retrieve message - Remember to prepend "MainContent_" to the actual id-name
                    $("#MainContent_Message").val("");                  //reset content of textbox
                    //target = "#" + $(event.target).data("target");
                    $.post('AjaxLoadFromDatabase.aspx', { option: "load", message: uploadMessage }, function (data) {
                        //$(target).append(data);
                    });
                    //$("#Chat").append("AjaxLoadFromDatabase.aspx #output > div");
                }
            });
            updateChat();
        });

        function updateChat()
        {
            $.post('AjaxLoadFromDatabase.aspx', { option: "retrieve", updateVersion: v }, function (data) {
                no = $("<div />").html(data).find("#no").html();    //A hack to get the #no element. Because #no is not child of any div, it is necessary
                //alert(no);                                        //to make a hack for outer html-childs.
                if (no > v) {
                    v = no;
                }
                var doc = $("<div />").html(data).find("#output").html();
                $("#Chat").prepend(doc);
                setTimeout(function() { updateChat(); }, 1500);     //updateChat is called as a callback-function
            });
            //
        }
    </script>

    <!-- <style type="text/css">
        #Message
        {
            width: 612px;
            height: 98px;
        }
    </style> -->
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div id="Chat" style="width:850px;height:200px;overflow:auto;">

        </div>
        <!-- <asp:ListBox ID="Chat" runat="server" Height="200px" Width="904px"></asp:ListBox> <br /><br /><br /> -->
        <asp:TextBox ID="Message" runat="server" TextMode="MultiLine" Rows="5" 
            Width="650px" Height="50px"></asp:TextBox>
        <asp:Button ID="Submit" class="btn" runat="server" Text="Send" onclick="Submit_Click" 
            Height="82px" Width="93px" data-target="Chat" AccessKey="e" /><br />
    </div>
    <div id="TextHere">

    </div>
</asp:Content>
