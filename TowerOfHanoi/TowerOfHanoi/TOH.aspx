<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TOH.aspx.cs" Inherits="TowerOfHanoi.TOH" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="Stylesheet" type="text/css" href="/Styles/myStyleSheet.css" />
    <title>Tower of Hanoi</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="toh">
            <div id="pegA" class="peg">
                <div class="vertical" id="a"></div>
                <div class="horisontal" id="aa"></div>
            </div>
            <div id="pegB" class="peg">
                <div class="vertical" id="b"></div>
                <div class="horisontal" id="bb"></div>
            </div>
            <div id="pegC" class="peg">
                <div class="vertical" id="c"></div>
                <div class="horisontal" id="cc"></div>
            </div>
        </div>
        <div id="control">

        </div>
    </div>
    </form>
</body>
</html>
