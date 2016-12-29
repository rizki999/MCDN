using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MySqlClientDotNET.DesignControls {
    public partial class FormHowToRenameDB : Form {
        public FormHowToRenameDB() {
            InitializeComponent();
            Language();
            if (System.IO.File.Exists(ResourcesPath.htmlHowTo))
                System.IO.File.Delete(ResourcesPath.htmlHowTo);
            using (System.IO.FileStream fs = System.IO.File.Create(ResourcesPath.htmlHowTo)) {
                Byte[] file = new UTF8Encoding(true).GetBytes(html);

                fs.Write(file, 0, file.Length);
            }
            webBrowser.Navigate("file://" + ResourcesPath.htmlHowTo);
            /*
            pic1.Image = Image.FromFile(ResourcesPath.img_db_ex1);
            pic2.Image = Image.FromFile(ResourcesPath.img_db_ex2);
            pic3.Image = Image.FromFile(ResourcesPath.img_db_ex3);
            pic4.Image = Image.FromFile(ResourcesPath.img_db_ex4);
            */
        }

        private void Language() {
            this.Text =  LanguageApp.langFormHowTo["FTHowTo"];
            html =
@"
<html>
<head>
<meta http-equiv=Content-Type content=""text/html; charset=windows-1252"">
<meta name=Generator content=""Microsoft Word 12 (filtered)"">
<style>
<!--
 /* Font Definitions */
 @font-face
	{font-family:""Cambria Math"";
	panose-1:2 4 5 3 5 4 6 3 2 4;}
@font-face
	{font-family:Calibri;
	panose-1:2 15 5 2 2 2 4 3 2 4;}
@font-face
	{font-family:Tahoma;
	panose-1:2 11 6 4 3 5 4 4 2 4;}
 /* Style Definitions */
 p.MsoNormal, li.MsoNormal, div.MsoNormal
	{margin-top:0cm;
	margin-right:0cm;
	margin-bottom:10.0pt;
	margin-left:0cm;
	line-height:115%;
	font-size:11.0pt;
	font-family:""Calibri"",""sans-serif"";}
p.MsoAcetate, li.MsoAcetate, div.MsoAcetate
	{mso-style-link:""Balloon Text Char"";
	margin:0cm;
	margin-bottom:.0001pt;
	font-size:8.0pt;
	font-family:""Tahoma"",""sans-serif"";}
span.BalloonTextChar
	{mso-style-name:""Balloon Text Char"";
	mso-style-link:""Balloon Text"";
	font-family:""Tahoma"",""sans-serif"";}
.MsoPapDefault
	{margin-bottom:10.0pt;
	line-height:115%;}
@page Section1
	{size:612.0pt 792.0pt;
	margin:72.0pt 72.0pt 72.0pt 72.0pt;}
div.Section1
	{page:Section1;}
-->
</style>

</head>

<body lang=EN-US>

<div class=Section1>

" + LanguageApp.langFormHowTo["HTMLHowTo"] + @"

</div>

</body>

</html>
";
        }

        private string html;
    }
}
