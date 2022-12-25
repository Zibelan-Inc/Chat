using System;
using System.IO;

namespace Chat
{
    class css
    {
        private static string clase;

        public static void Save()
        {
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KosmoChat", "css", "class.css"), GetMyCSS());
        }
        public static string GetMyCSS()
        {
            clase = @"

            /*Modifications of MainCSS:*/

            *, *:before, *:after {
            box-sizing: border-box;
            }

            .message {
            top:5px;                /*este no lo llevaba... lo puse con lo del avatar*/   
            color: black;
            padding: 8px 20px;
            line-height: 20px;
            border-radius: 7px;
            margin-bottom: 15px;
            position: relative;
            clear:both;
            max-width: 85%;

            }
            .message:before{
            bottom: 100%;
            top:-19px;              
            right:10px;
            border: solid transparent;
            content: ' ';
            height: 0;
            width: 0;
            position: absolute;
            pointer-events: none;
            border-bottom-color: #B6DEFF;
            border-width: 10px;
            }            
            .select-message {
            background-color:#FF1A202F !important;
            }
            .select-message:before{
            border-bottom-color: #FF1A202F !important;
            }
            .hide_message_arrow:before {
            display:none;
            }
            .my-message {
            background: #B6DEFF;
            float:right;
            }
            .other-message {
            background: #B9F98E;
            float:left;
            }
            .other-message:before {
            border-bottom-color: #B9F98E;
            left:unset;
            left:10px;
            }
            .message a{
            color:#0066cc;
            text-decoration:underline;
            cursor:hand;
            }
            a.mention-user{
            background-color:#689F38;
            text-decoration:none;
            color:white;
            padding:2px;
            border-radius:5px;
            }
            .message-data {
            clear:both;
            color: DimGray;
            margin-bottom: 13px;
            margin-top: 2px;
            *margin-bottom: 5px;
            }            
            .privatemessage-data {
            color: silver;
            }
            .message-data-time {
            color: white;
            padding-left: 6px;
            font-size: 8pt;
            }
            .buzz {
            color: #ff0000;
            }
            .align-right {
            text-align: right;
            }
            pre {
            margin: 0px;
            padding: 0px;
            font-size: 10pt;
            white-space: pre-wrap;
            word-wrap: break-word;
            *display:inline;
            }
            pre a {
            cursor: pointer;
            }


            /*---------------------------------------------*/
            /*Default*/
            .my-message-0 {
            background: #b6deff;
            float:right;
            }
            .my-message-0:before {
            border-bottom-color: #b6deff;
            }

            /*Blue*/
            .my-message-1 {
            background-color: Blue;
            color: #ffffff;
            float:right;
            }
            .my-message-1:before {
            border-bottom-color: Blue;
            }

            /*BlueViolet*/
            .my-message-2 {
            background-color: BlueViolet;
            color: #ffffff;
            float:right;
            }
            .my-message-2:before {
            border-bottom-color: BlueViolet;
            }

            /*Crimson*/
            .my-message-3 {
            background-color: Crimson;
            color: #ffffff;
            float:right;
            }
            .my-message-3:before {
            border-bottom-color: Crimson;
            }

            /*DarkOrange*/
            .my-message-4 {
            background-color: DarkOrange;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-4:before {
            border-bottom-color: DarkOrange;
            }

            /*DeepPink*/
            .my-message-5 {
            background-color: DeepPink;
            color: #ffffff;
            float:right;
            }
            .my-message-5:before {
            border-bottom-color: DeepPink;
            }

            /*DeepSkyBlue*/
            .my-message-6 {
            background-color: DeepSkyBlue;
            color: #000000;
            float:right;
            }
            .my-message-6:before {
            border-bottom-color: DeepSkyBlue;
            }

            /*Gold*/
            .my-message-7 {
            background-color: Gold;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-7:before {
            border-bottom-color: Gold;
            }

            /*LightSalmon*/
            .my-message-8 {
            background-color: LightSalmon;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-8:before {
            border-bottom-color: LightSalmon;
            }

            /*LimeGreen*/
            .my-message-9 {
            background-color: LimeGreen;
            color: #FF1A202F;
            float:right;
            }
            .my-message-9:before {
            border-bottom-color: LimeGreen;
            }

            /*OrangeRed*/
            .my-message-10 {
            background-color: OrangeRed;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-10:before {
            border-bottom-color: OrangeRed;
            }

            /*Pink*/
            .my-message-11 {
            background-color: Pink;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-11:before {
            border-bottom-color: Pink;
            }

            /*Plum*/
            .my-message-12 {
            background-color: Plum;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-12:before {
            border-bottom-color: Plum;
            }

            /*Purple*/
            .my-message-13 {
            background-color: Purple;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-13:before {
            border-bottom-color: Purple;
            }

            /*Red*/
            .my-message-14 {
            background-color: Red;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-14:before {
            border-bottom-color: Red;
            }

            /*SkyBlue*/
            .my-message-15 {
            background-color: SkyBlue;
            color: #ffffff;
            float:right;
            }
            .my-message-15:before {
            border-bottom-color: SkyBlue;
            }

            /*Turquoise*/
            .my-message-16 {
            background-color: Turquoise;
            color: #ffffff;
            float:right;
            }
            .my-message-16:before {
            border-bottom-color: Turquoise;
            }

            /*Yellow*/
            .my-message-17 {
            background-color: Yellow;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-17:before {
            border-bottom-color: Yellow;
            }

            /*MediumSeaGreen*/
            .my-message-18 {
            background-color: MediumSeaGreen;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-18:before {
            border-bottom-color: MediumSeaGreen;
            }

            /*Aquamarine*/
            .my-message-19 {
            background-color: Aquamarine;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-19:before {
            border-bottom-color: Aquamarine;
            }

            /*SlateBlue*/
            .my-message-20 {
            background-color: SlateBlue;
            color: #ffffff;
            float:right;
            }
            .my-message-20:before {
            border-bottom-color: SlateBlue;
            }

            /*GreenYellow*/
            .my-message-21 {
            background-color: GreenYellow;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-21:before {
            border-bottom-color: GreenYellow;
            }

            /*Smiley*/
            .my-message-Smiley {
            top:5px;                
            margin-bottom: 15px;
            float:right;
            }
            .my-message-Smiley:before {
            }
            /*---------------------------------------------*/

            /*---------------------------------------------*/

            /*Default*/
            .other-message-0 {
            background: #b6deff;
            float:left;
            }
            .other-message-0:before {
            border-bottom-color: #b6deff;
            left:unset;
            left:10px;
            }

            /*Blue*/
            .other-message-1 {
            background-color: Blue;
            color: #ffffff;
            float:left;
            }
            .other-message-1:before {
            border-bottom-color: Blue;
            left:unset;
            left:10px;
            }

            /*BlueViolet*/
            .other-message-2 {
            background-color: BlueViolet;
            color: #ffffff;
            float:left;
            }
            .other-message-2:before {
            border-bottom-color: BlueViolet;
            left:unset;
            left:10px;
            }

            /*Crimson*/
            .other-message-3 {
            background-color: Crimson;
            color: #ffffff;
            float:left;
            }
            .other-message-3:before {
            border-bottom-color: Crimson;
            left:unset;
            left:10px;
            }

            /*DarkOrange*/
            .other-message-4 {
            background-color: DarkOrange;
            /*color: #ffffff;*/
            float:left;
            }
            .other-message-4:before {
            border-bottom-color: DarkOrange;
            left:unset;
            left:10px;
            }

            /*DeepPink*/
            .other-message-5 {
            background-color: DeepPink;
            color: #ffffff;
            float:left;
            }
            .other-message-5:before {
            border-bottom-color: DeepPink;
            left:unset;
            left:10px;
            }

            /*DeepSkyBlue*/
            .other-message-6 {
            background-color: DeepSkyBlue;
            color: #000000;
            float:left;
            }
            .other-message-6:before {
            border-bottom-color: DeepSkyBlue;
            left:unset;
            left:10px;
            }

            /*Gold*/
            .other-message-7 {
            background-color: Gold;
            /*color: #ffffff;*/
            float:left;
            }
            .other-message-7:before {
            border-bottom-color: Gold;
            left:unset;
            left:10px;
            }

            /*LightSalmon*/
            .other-message-8 {
            background-color: LightSalmon;
            /*color: #ffffff;*/
            float:left;
            }
            .other-message-8:before {
            border-bottom-color: LightSalmon;
            left:unset;
            left:10px;
            }

            /*LimeGreen*/
            .other-message-9 {
            background-color: LimeGreen;
            color: #FF1A202F;
            float:left;
            }
            .other-message-9:before {
            border-bottom-color: LimeGreen;
            left:unset;
            left:10px;
            }

            /*OrangeRed*/
            .my-message-10 {
            background-color: OrangeRed;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-10:before {
            border-bottom-color: OrangeRed;
            }

            /*Pink*/
            .my-message-11 {
            background-color: Pink;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-11:before {
            border-bottom-color: Pink;
            }

            /*Plum*/
            .my-message-12 {
            background-color: Plum;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-12:before {
            border-bottom-color: Plum;
            }

            /*Purple*/
            .my-message-13 {
            background-color: Purple;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-13:before {
            border-bottom-color: Purple;
            }

            /*Red*/
            .my-message-14 {
            background-color: Red;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-14:before {
            border-bottom-color: Red;
            }

            /*SkyBlue*/
            .my-message-15 {
            background-color: SkyBlue;
            color: #ffffff;
            float:right;
            }
            .my-message-15:before {
            border-bottom-color: SkyBlue;
            }

            /*Turquoise*/
            .my-message-16 {
            background-color: Turquoise;
            color: #ffffff;
            float:right;
            }
            .my-message-16:before {
            border-bottom-color: Turquoise;
            }

            /*Yellow*/
            .my-message-17 {
            background-color: Yellow;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-17:before {
            border-bottom-color: Yellow;
            }

            /*MediumSeaGreen*/
            .my-message-18 {
            background-color: MediumSeaGreen;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-18:before {
            border-bottom-color: MediumSeaGreen;
            }

            /*Aquamarine*/
            .my-message-19 {
            background-color: Aquamarine;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-19:before {
            border-bottom-color: Aquamarine;
            }

            /*SlateBlue*/
            .my-message-20 {
            background-color: SlateBlue;
            color: #ffffff;
            float:right;
            }
            .my-message-20:before {
            border-bottom-color: SlateBlue;
            }

            /*GreenYellow*/
            .my-message-21 {
            background-color: GreenYellow;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-21:before {
            border-bottom-color: GreenYellow;
            }

            /*Smiley*/
            .other-message-Smiley {
            background: #ffffff;
            color: #000000;
            float:right;
            }
            .other-message-Smiley:before {
            border-bottom-color: #ffffff;
            }
            /*---------------------------------------------*/





            /*Default*/
            .0 {
            background: #b6deff;
            }
            .0:before {
            border-bottom-color: #b6deff;
            }

            /*Blue*/
            .1 {
            background-color: Blue;
            color: #ffffff;
            }
            .1:before {
            border-bottom-color: Blue;
            }

            /*BlueViolet*/
            .2 {
            background-color: BlueViolet;
            color: #ffffff;
            }
            .2:before {
            border-bottom-color: BlueViolet;
            }

            /*Crimson*/
            .3 {
            background-color: Crimson;
            color: #ffffff;
            }
            .3:before {
            border-bottom-color: Crimson;
            }

            /*DarkOrange*/
            .4 {
            background-color: DarkOrange;
            /*color: #ffffff;*/
            }
            .4:before {
            border-bottom-color: DarkOrange;
            }

            /*DeepPink*/
            .5 {
            background: DeepPink;
            color: #ffffff;
            }
            .5:before {
            border-bottom-color: DeepPink;
            }

            /*DeepSkyBlue*/
            .6 {
            background-color: DeepSkyBlue;
            color: #000000;
            }
            .6:before {
            border-bottom-color: DeepSkyBlue;
            }

            /*Gold*/
            .7 {
            background-color: Gold;
            /*color: #ffffff;*/
            }
            .7:before {
            border-bottom-color: Gold;
            }

            /*LightSalmon*/
            .8 {
            background-color: LightSalmon;
            /*color: #ffffff;*/
            }
            .8:before {
            border-bottom-color: LightSalmon;
            }

            /*LimeGreen*/
            .9 {
            background-color: LimeGreen;
            color: #000000;
            }
            .9:before {
            border-bottom-color: LimeGreen;
            }

            /*OrangeRed*/
            .my-message-10 {
            background-color: OrangeRed;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-10:before {
            border-bottom-color: OrangeRed;
            }

            /*Pink*/
            .my-message-11 {
            background-color: Pink;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-11:before {
            border-bottom-color: Pink;
            }

            /*Plum*/
            .my-message-12 {
            background-color: Plum;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-12:before {
            border-bottom-color: Plum;
            }

            /*Purple*/
            .my-message-13 {
            background-color: Purple;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-13:before {
            border-bottom-color: Purple;
            }

            /*Red*/
            .my-message-14 {
            background-color: Red;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-14:before {
            border-bottom-color: Red;
            }

            /*SkyBlue*/
            .my-message-15 {
            background-color: SkyBlue;
            color: #ffffff;
            float:right;
            }
            .my-message-15:before {
            border-bottom-color: SkyBlue;
            }

            /*Turquoise*/
            .my-message-16 {
            background-color: Turquoise;
            color: #ffffff;
            float:right;
            }
            .my-message-16:before {
            border-bottom-color: Turquoise;
            }

            /*Yellow*/
            .my-message-17 {
            background-color: Yellow;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-17:before {
            border-bottom-color: Yellow;
            }

            /*MediumSeaGreen*/
            .my-message-18 {
            background-color: MediumSeaGreen;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-18:before {
            border-bottom-color: MediumSeaGreen;
            }

            /*Aquamarine*/
            .my-message-19 {
            background-color: Aquamarine;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-19:before {
            border-bottom-color: Aquamarine;
            }

            /*SlateBlue*/
            .my-message-20 {
            background-color: SlateBlue;
            color: #ffffff;
            float:right;
            }
            .my-message-20:before {
            border-bottom-color: SlateBlue;
            }

            /*GreenYellow*/
            .my-message-21 {
            background-color: GreenYellow;
            /*color: #ffffff;*/
            float:right;
            }
            .my-message-21:before {
            border-bottom-color: GreenYellow;
            }
            /*---------------------------------------------*/
            .my-user-avatar {
	            float: right;
	            height: 28px;
	            margin-right: 8px;
	            margin-top: -4px;
	            overflow: hidden;
	            width: 28px;
            }
            .other-user-avatar {
	            float: left;
	            height: 28px;
	            margin-right: 8px;
	            margin-top: -4px;
	            overflow: hidden;
	            width: 35px;
            }





           




           





            ";
            return clase;
        }
        public static string GetHTMLCSS()
        {
            clase = @"

            .navbar-fixed-top,.navbar-fixed-bottom{position:fixed;right:0;left:0;z-index:1030}@media (min-width:768px){.navbar-fixed-top,.navbar-fixed-bottom{border-radius:0}}
            .navbar-fixed-top{top:0;border-width:0 0 1px}.navbar-fixed-bottom{bottom:0;margin-bottom:0;border-width:1px 0 0}
            .navbar-brand:hover,.navbar-brand:focus{text-decoration:none}@media (min-width:768px){.navbar>.container .navbar-brand,.navbar>.container-fluid .navbar-brand{margin-left:-15px}}
            .navbar-form.navbar-right:last-child{margin-right:-15px}}.navbar-nav>li>.dropdown-menu{margin-top:0;border-top-right-radius:0;border-top-left-radius:0}.navbar-fixed-bottom .navbar-nav>li>.dropdown-menu{border-bottom-right-radius:0;border-bottom-left-radius:0}
            .panel{margin-bottom:20px;background-color:#FF1A202F;border:1px solid transparent;border-radius:4px;-webkit-box-shadow:0 1px 1px rgba(0,0,0,.05);box-shadow:0 1px 1px rgba(0,0,0,.05)}.panel-body{padding:15px}.panel-heading{padding:10px 15px;border-bottom:1px solid transparent;border-top-right-radius:3px;border-top-left-radius:3px}.panel-heading>.dropdown .dropdown-toggle{color:inherit}.panel-title{margin-top:0;margin-bottom:0;font-size:16px;color:inherit}.panel-title>a{color:inherit}.panel-footer{padding:10px 15px;background-color:#FF1A202F;border-top:1px solid #ddd;border-bottom-right-radius:3px;border-bottom-left-radius:3px}.panel>.list-group{margin-bottom:0}.panel>.list-group .list-group-item{border-width:1px 0;border-radius:0}.panel>.list-group:first-child .list-group-item:first-child{border-top:0;border-top-right-radius:3px;border-top-left-radius:3px}.panel>.list-group:last-child .list-group-item:last-child{border-bottom:0;border-bottom-right-radius:3px;border-bottom-left-radius:3px}.panel-heading+.list-group .list-group-item:first-child{border-top-width:0}.panel>.table,.panel>.table-responsive>.table{margin-bottom:0}.panel>.table:first-child,.panel>.table-responsive:first-child>.table:first-child{border-top-right-radius:3px;border-top-left-radius:3px}.panel>.table:first-child>thead:first-child>tr:first-child td:first-child,.panel>
            .panel-group .panel-footer+.panel-collapse .panel-body{border-bottom:1px solid #ddd}.panel-default{border-color:#ddd}.panel-default>
            .panel-heading{color:#333;background-color:#FF1A202F;border-color:#FF1A202F}.panel-default>.panel-heading+.panel-collapse .panel-body{border-top-color:#ddd}


            /* header */
            .header {
	            margin: 0;
	            padding: 0;
	            border: 0;
	            margin-bottom: 0;
	            background: #318ce7;
            }
            .header .my-user-photo {
	            float: left;
	            height: 28px;
	            margin-right: 8px;
	            margin-top: -4px;
	            overflow: hidden;
	            width: 28px;
            }
            .header .caret {
	            margin-left: 5px;
            }
            .header-fixed {
	            padding-top: 44px;
            }
            .header.navbar {
	            border-radius: 0;
	            box-shadow: none;
	            min-height: 44px;
            }
            .header h3, .header h4 {
	            margin: 0;
	            padding: 0;
            }
            .header .navbar-toggle {
	            border: 0;
            }
            .header .header-nav {
	            float: right;
            }
            .header .header-nav .icon-nav {
	            float: right;
            }
            .header .header-nav .icon-nav > li {
	            float: left;
            }
            .header .header-nav .icon-nav > li > a {
	            padding: 12px;
            }
            .header .header-nav .icon-nav > li > a > i {
	            font-size: 20px;
            }
            .header .header-nav .icon-nav > li > a > .badge {
	            background: none repeat scroll 0 0 #FF0000;
	            border: 0 none;
	            border-radius: 100%;
	            box-shadow: none;
	            position: absolute;
	            right: 0;
	            top: 7px;
            }
            .header .header-nav .icon-nav > li > .dropdown-menu {
	            margin-top: 0;
            }
            .header .navbar-header {
	            float: none !important;
            }
            .header .navbar-brand {
	            height: 44px;
	            padding-top: 0px;
	            padding-bottom: 0px;
	            color: #f5f5f5;
            }
            .header .navbar-brand .logo {
	            background-image: url('../img/om_48.ico');
	            background-repeat: no-repeat;
	            background-size: 36px 36px;
	            float: left;
	            height: 36px;
	            margin-top: 5px;
	            width: 36px;
            }
            .header .navbar-brand .name {
	            float: left;
	            margin: 10px 0 0 10px;
            }
            .header .navbar-toggle.page-sidebar-toggle {
	            display: none;
            }
            .header .settings .dropdown-menu {
	            width: 300px;
            }
            .header .header-nav .icon-nav > li > a {
	            color: #f5f5f5;
            }
            .header .header-nav .icon-nav > li > a:hover, .header .header-nav .icon-nav > li > a:focus, .header .header-nav .nav .open > a, .header .header-nav .nav .open > a:hover, .header .header-nav .nav .open > a:focus, .header .navbar-toggle.page-sidebar-toggle:hover, .header .navbar-toggle.page-sidebar-toggle:focus {
	            background: #084C9F !important;
	            color: #fff !important;
            }
            .page-fluid .header .container {
	            width: auto;
            }
            .header .navbar-toggle.sidebar-toggle, .header .navbar-toggle.mobile-menu {
	            display: block;
	            border: 0 none;
	            border-radius: 0;
	            margin: 0;
	            padding: 15px 10px;
            }
            .header .user-detail-menu {
	            padding: 10px;
	            width: 250px;
            }

            ";
            return clase;
        }

    }
}
