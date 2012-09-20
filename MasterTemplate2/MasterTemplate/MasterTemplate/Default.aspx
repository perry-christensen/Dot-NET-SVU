<%@ Page Title="Forsiden" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="MasterTemplate._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<script src="http://code.jquery.com/jquery.min.js" type="text/javascript"></script>
<script type="text/javascript">
    //The following jQuery code iterates pictures by fading them in and out.
        $(function () {
            var images = ['#imgone', '#imgtwo'],
             imgIx = 0;

            (function nextImage() {
                $(images[imgIx++] || images[imgIx = 0, imgIx++]).hide().delay(200).fadeIn(1000).delay(2000).fadeOut(1000, nextImage);
            })();
        });
    

</script>


</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <a href="http://www.itucation.dk">Itucations hjemmeside</a>

    <div id="picContainer">
        <img alt="antique world map" id="imgone" src="/Images/Old-World-Map.jpg" style="display:none; width:640px; height:360px;"/>
        <img alt="modern world map" id="imgtwo" src="/Images/World-Map-with-Time-Zones.jpg" style="display:none; width:640px; height:360px"/>

    </div>
</asp:Content>
