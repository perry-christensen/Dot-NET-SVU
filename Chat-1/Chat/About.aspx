<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="Chat.About" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
<!-- Copied from default.aspx -->    

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
                    currentScript = $(event.target).data("script");
                    act = $(event.target).data("act");
                    target = "#" + $(event.target).data("target");
                    $.post('AjaxLoadFromDatabase.aspx', { option: "load", script: currentScript }, function (data) {
                        switch (act) {
                            case "replace":
                                $(target).html(data);
                                break;
                            case "append":
                                $(target).append(data);
                                //$('#Chat').value(data);
                                break;
                            case "prepend":
                                $(target).prepend(data);
                            default:
                        }

                        //$('#TextHere').html(data);                  //Write this to div with id="TextHere"
                        //$(data).appendTo('#TextHere');              //Append this to div with id="TextHere"
                        //$('#TextHere').append(data);                    //Performs the same task as appendTo function
                    });
                }
            });
        });
    </script>

    <!--<style type="text/css">
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
        
        </div><br /><br /><br />
        <div style="Margin-right:5px">
        <asp:TextBox ID="Message" runat="server" TextMode="MultiLine" Rows="5" Width="650px" Height="50px"></asp:TextBox>
        </div>
        <div style="Margin-left:5px;width:100px">
        <asp:Button ID="Submit" class="btn" runat="server" Text="Send" data-script="" data-act="" data-target="Chat" Height="50px" Width="100px" />
        </div>
    </div>
    
        
        <!--
        <asp:Button ID="Submit" class="btn" runat="server" Text="Hola Señor" data-script="Hola Señor" data-act="replace" data-target="TextHere"
            Height="82px" Width="93px" /><br />
        <asp:Button ID="Button1" class="btn" runat="server" Text="Facebook" data-script="Facebook" data-act="append" data-target="AlsoTextHere"
            Height="82px" Width="93px" /><br />
        <asp:Button ID="Button2" class="btn" runat="server" Text="Perry Dahl Christensen" data-script="Perry Dahl Christensen" data-act="prepend" data-target="AlsoTextHere"
            Height="82px" Width="93px" /><br />
    </div>
    
   
    <div id="container">
	<div class="share">
        <div id="facebook">
            <div id="fb-root"></div>
            <script src="http://connect.facebook.net/en_US/all.js#xfbml=1"></script>
            <fb:like href="http://hvadmed.nu/" layout="box_count" show_faces="true" width="0" font=""></fb:like>
        </div>
        <div id="twitter">
            <a href="http://twitter.com/share" class="twitter-share-button" data-count="vertical" data-related="madsgodvin:Author of Hvad med nu? and passionate single-serving-sites inspector">Tweet</a><script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>
        </div>
	</div>
    <br />
    #TextHere <br />
    <div id="TextHere">

    </div>
    #AlsoTextHere <br />
    <div id="AlsoTextHere">

    </div>
    -->
</asp:Content>
