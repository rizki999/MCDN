using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySqlClientDotNET {
    public static class LanguageApp {
        public static Dictionary<string, string> langMainMenu;
        public static Dictionary<string, string> langStartPage;
        public static Dictionary<string, string> langFormConnection;
        public static Dictionary<string, string> langFormSetting;
        public static Dictionary<string, string> langFormSqlPreview;
        public static Dictionary<string, string> langFormHowTo;
        public static Dictionary<string, string> langFormSelCol;
        public static Dictionary<string, string> langFormImportCSV;
        public static Dictionary<string, string> langFormExportCSV;
        public static Dictionary<string, string> langFormAbout;
        public static Dictionary<string, string> langPanDBBuilder;
        public static Dictionary<string, string> langDynamicTabDoc;
        public static Dictionary<string, string> langMessage;
        public static Dictionary<string, string> langResultGrid;
        public static Dictionary<string, string> langExportImport;
        public static Dictionary<string, string> langSQLEditor;
        public static Dictionary<string, string> langConsole;
        public static Dictionary<string, string> langUserAccount;
        public static Dictionary<string, string> langTableBuilder;

        public static void initializeLangEn() {
            langMainMenu = new Dictionary<string, string>();
            langMainMenu.Add("MMFiles", "&Files");
            langMainMenu.Add("MMView", "&View");
            langMainMenu.Add("MMCreate", "&Create");
            langMainMenu.Add("MMTools", "&Tools");
            langMainMenu.Add("MMHelp", "&Help");

            langMainMenu.Add("SMMNewSql", "&New Sql File");
            langMainMenu.Add("SMMOpenSql", "&Open Sql File");
            langMainMenu.Add("SMMSaveSqlFile", "&Save Sql File");
            langMainMenu.Add("SMMSaveAsSqlFile", "Save &As Sql File");
            langMainMenu.Add("SMMCloseConn", "&Close Connection");
            langMainMenu.Add("SMMExit", "&Exit");

            langMainMenu.Add("SMMDatabaseExplorer", "&Database Explorer");
            langMainMenu.Add("SMMServerIdentity", "&Identity Serever");
            langMainMenu.Add("SMMOutput", "&Output");
            langMainMenu.Add("SMMHideAllPanle", "&All Panle");

            langMainMenu.Add("SMMCreateDatabase", "Create &Database");
            langMainMenu.Add("SMMCreateTable", "Create &Table");

            langMainMenu.Add("SMMOpenConsole", "&Open Console");
            langMainMenu.Add("SMMImportExportDatabase", "&Import Export Database");
            langMainMenu.Add("SMMUserAccount", "&User Acount");
            langMainMenu.Add("SMMSetting", "&Setting");

            langMainMenu.Add("SMMAbout", "&About");

            langMainMenu.Add("TSLDatabaseExplorer", "Database Explorer");
            langMainMenu.Add("TSLServerIdentity", "Serever Identity");
            langMainMenu.Add("TSLOutput", "Output");

            langMainMenu.Add("TSLLoadDatabase", "Load Database...");
            langMainMenu.Add("TSBLSetDBAsDef", "Set Database As Default");
            langMainMenu.Add("TSBLRefresh", "Set Database As Default");

            langMainMenu.Add("DTXTVersion", "Version");
            langMainMenu.Add("DTXTBasedir", "Basedir");
            langMainMenu.Add("DTXTCompiled", "Compiled program");

            langMainMenu.Add("TTMessage", "Message");
            langMainMenu.Add("TTResultGrid", "Result Grid");

            langMainMenu.Add("CMSRefresh", "Refresh");
            langMainMenu.Add("CMSSetDBAsDef", "Set Database As Default");
            langMainMenu.Add("CMSDatabase", "Database");
            langMainMenu.Add("CMSTable", "Table");

            langMainMenu.Add("CSMSAlterDB", "&Alter Database");
            langMainMenu.Add("CSMSDropDB", "&Drop Database");
            langMainMenu.Add("CSMSCraeteTable", "&Create Table");
            langMainMenu.Add("CSMSAlterTB", "&Alter Table");
            langMainMenu.Add("CSMSDropTB", "&Drop Table");
            langMainMenu.Add("CSMSEditData", "&Edit Data Table On Grid");

            langMainMenu.Add("MSGWaitAllDatabase",
@"Now Wait To Load All Database..."
);
            langMainMenu.Add("MSGWaitConn", "Waiting Connection...");
            langMainMenu.Add("MSGErrLoadDbTree", "Load database to tree");
            langMainMenu.Add("MSGStetmentExec", "Statment executed");
            langMainMenu.Add("MSGErrStetmentAbort", "Statment abort");
            langMainMenu.Add("MSGWarnSelectItem", "Selct item tree first");
            langMainMenu.Add("MSGErrSetDB", "Set Database {0} As Default Failed");
            langMainMenu.Add("MSGDBCannotDrop", "Currently the database can not droped");
            langMainMenu.Add("MSGDbExistOnTab", "This database exist on tab, do you want to continue to drop databse ?");
            langMainMenu.Add("MSGDbNotFound", "Database not Found !");
            langMainMenu.Add("MSGActionDropDB", "Drop Database/Schema");
            langMainMenu.Add("MSGTbExistOnTab", "This table exist on tab, do you want to continue to drop table ?");
            langMainMenu.Add("MSGTbNotFound", "Table not Found !");
            langMainMenu.Add("MSGActionDropTB", "Drop Table");
            langMainMenu.Add("MSGNoPrimary",
@"                 This table does not has primary key 
       it's mean you can not update/delete by specific
   click 'yes' to continue but you have 'insert' data only.");
            langMainMenu.Add("MSGConfrimCloseConn",
@"                       Do you wanna close connection ? 
warrning, save all document/editing data before close connection, 
                   it will be froce close all content on tab 
                 without save document/editing data first");
            langMainMenu.Add("MSGWarnSelectDB", "Select database first !");
            langMainMenu.Add("MSGWarnDiscardAllContent", "Discard all content on tab ?");
            langMainMenu.Add("MSGErrTryCloseConn", "try Closing Connection ");

            
            langFormConnection = new Dictionary<string, string>();
            langFormConnection.Add("TWNeConnNew", "New Connection");
            langFormConnection.Add("TWNeConnEdit", "Edit Connection");

            langFormConnection.Add("GBTNewConnection", "New Connection Form");

            langFormConnection.Add("LBConnectionName", "Connection Name");
            langFormConnection.Add("LBHostName", "Host Name");
            langFormConnection.Add("LBUserName", "Username");
            langFormConnection.Add("LBPassword", "Password");
            langFormConnection.Add("LBDefaultDatabase", "Default Database");
            langFormConnection.Add("LBHavePass", "Password");
            langFormConnection.Add("LBHavePassYes", "Yes");
            langFormConnection.Add("LBHavePassNo", "No");

            langFormConnection.Add("BTTestConn", "Test Connection");
            langFormConnection.Add("BTSave", "Save");
            langFormConnection.Add("BTClearPass", "Clear Password");
            langFormConnection.Add("BTSetPass", "Set Password");
            
            langFormConnection.Add("CBTAskPass", "Ask Password When Login");

            langFormConnection.Add("TFNew", "New Connection");
            langFormConnection.Add("TFEdit", "Edit Connection");

            langFormConnection.Add("MSGFillConnName", "Fill connection name");
            langFormConnection.Add("MSGFillHost", "Fill Hostname");
            langFormConnection.Add("MSGFillUser", "Fill Username");
            langFormConnection.Add("MSGConnNameExist", "Connaction name is exist\nTry diffrent name");
            langFormConnection.Add("MSGTryConn", "Trying connecting to MySql");
            langFormConnection.Add("MSGConnMysql", "Connected to MySql");
            langFormConnection.Add("MSGErrSaveConn", "Would you save this connection");
            langFormConnection.Add("MSGErrEditConn", "Would you edit this connection");
            langFormConnection.Add("MSGConnected", "Connected");
            langFormConnection.Add("MSGNotConnected", "Not Connected");
            

            langStartPage = new Dictionary<string, string>();
            langStartPage.Add("HTStartPage", "Start Page");
            langStartPage.Add("BTNewConnection", "New\nConnection");
            langStartPage.Add("LBListConnection", "Connection List");

            langStartPage.Add("CMOpenConn", "Open Connection");
            langStartPage.Add("CMEditConn", "Edit Connection");
            langStartPage.Add("CMDelConn", "Delete Connection");

            langStartPage.Add("MSGErrConnName", "Connection name not found");
            langStartPage.Add("MSGWorngPass", "Worong Password");
            langStartPage.Add("MSGConnWork", "Your connection is worked, Welcome !");
            langStartPage.Add("MSGTryToConn", "Trying to connect to MySQL");
            langStartPage.Add("MSGApplyDel", "Are you sure want to delet this connection ?");
            langStartPage.Add("MSGConnDel", "Connection deleted");


            langFormSetting = new Dictionary<string, string>();
            langFormSetting.Add("TFormSetting", "Setting");

            langFormSetting.Add("LBLimit", "Limit when use SELECT stetment");
            langFormSetting.Add("LBLanguage", "Language");

            langFormSetting.Add("BTOk", "OK");
            langFormSetting.Add("MSGRestart", "Application must restart to change language");


            langFormSqlPreview = new Dictionary<string, string>();
            langFormSqlPreview.Add("FTSQLPreview", "SQL Preview");
            langFormSqlPreview.Add("BTApply", "Apply");
            langFormSqlPreview.Add("BTCancel", "Cancel");
            langFormSqlPreview.Add("BTBack", "Back");
            langFormSqlPreview.Add("BTOk", "OK");

            langFormSqlPreview.Add("MSGAction1", "Stetment executed");
            langFormSqlPreview.Add("MSGAction2", "Action");
            langFormSqlPreview.Add("MSGNothingToExec", "Nothing to executed");
            langFormSqlPreview.Add("MSGSqlStat", "SQL Stetment");
            langFormSqlPreview.Add("MSGErrorSql", "Error Message");
            langFormSqlPreview.Add("MSGSucc", " (Success)");
            langFormSqlPreview.Add("MSGFail", " (One/more failed)");


            langFormHowTo = new Dictionary<string, string>();
            langFormHowTo.Add("FTHowTo", "How To Rename Database");
            langFormHowTo.Add("HTMLHowTo",
@"
<p class=MsoNormal align=center style='text-align:center;line-height:150%'><b><span
style='font-size:14.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>Rename
the database <br> in newer version of MySQL</span></b></p>

<p class=MsoNormal align=center style='text-align:center;line-height:150%'><b><span
style='font-size:14.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>&nbsp;</span></b></p>

<p class=MsoNormal style='text-align:justify;text-indent:36.0pt;line-height:
150%'><span style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>In
newer version of MySQL you can not rename the database directly, it causing
scurity risk, you must store the database to sql file and restore back to new
database with name you want to rename on MySQL</span></p>

<p class=MsoNormal style='text-align:justify;line-height:150%'><b><span
style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>Create
Database</span></b></p>

<p class=MsoNormal align=center style='text-align:center;line-height:150%'><span
style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'><img
width=500 height=378 id=""Picture 1""
src=""ex_1.png""></span></p>

<p class=MsoNormal style='text-align:justify;text-indent:36.0pt;line-height:
150%'><span style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>Create
database with name that you want to rename in main menu Create-&gt;Creat
Database.</span></p>

<p class=MsoNormal style='text-align:justify;line-height:150%'><b><span
style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>Store
Database To Sql File</span></b></p>

<p class=MsoNormal align=center style='text-align:center;line-height:150%'><b><span
style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'><img
width=560 height=210 id=""Picture 2""
src=""ex_2.png""></span></b></p>

<p class=MsoNormal style='text-align:justify;text-indent:36.0pt;line-height:
150%'><span style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>You
must open &quot;Export Database To Sql File&quot; in main menu
Tools-&gt;Import/Export Database select database that you want to rename and
select directory for storing sql file and press button export.</span></p>

<p class=MsoNormal style='line-height:150%'><b><span style='font-size:12.0pt;
line-height:150%;font-family:""Times New Roman"",""serif""'>Restore Database to New
Database</span></b></p>

<p class=MsoNormal align=center style='text-align:center;line-height:150%'><b><span
style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'><img
width=550 height=166 id=""Picture 3""
src=""ex_3.png""></span></b></p>

<p class=MsoNormal style='text-align:justify;text-indent:36.0pt;line-height:
150%'><span style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>After
exporting the database to sql file, import to new database on MySql that was
created before or import database select sql file that was stored and select
new database and then press button import.</span></p>

<p class=MsoNormal style='text-align:justify;line-height:150%'><b><span
style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>Drop
old database</span></b></p>

<p class=MsoNormal align=center style='text-align:center;line-height:150%'><b><span
style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'><img
width=448 height=249 id=""Picture 4""
src=""ex_4.png""></span></b></p>

<p class=MsoNormal style='text-align:justify;text-indent:36.0pt;line-height:
150%'><span style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>If
export and import successfully then drop the database that stored in sql file
(export) before. For drop database right click on database in &quot;Database
Explorer&quot; and select menu Databses-&gt;Drop Database and the sql preview
will showing and click button apply that will execute drop database statment</span></p>
");


            langFormAbout = new Dictionary<string, string>();
            langFormAbout.Add("FTAbout", "About Author");
            langFormAbout.Add("FTAboutText",
@"Author" + "\t\t" + @": Rizki Munandar
NIM" + "\t\t\t" + @": 12720009

Application Name" + "\t" + @": MySql Client .NET (MCDN)
Build" + "\t\t\t" + @": Visual C# 2013 Community Edition
Contact" + "\t\t" + @": munandar.rizki@gmail.com
" + "\t\t\t  win32hacked@gmail.com"
);


            langFormSelCol = new Dictionary<string, string>();
            langFormSelCol.Add("FTSelectCol", "Select Column");
            
            langFormSelCol.Add("LBDbTb", "Database.Table");
            
            langFormSelCol.Add("BTUp", "Up");
            langFormSelCol.Add("BTDown", "Down");
            langFormSelCol.Add("BTApply", "Apply");
            langFormSelCol.Add("BTCancel", "Cancel");

            langFormSelCol.Add("MSGHaveNoCol",
@"you have nothing to insert
select minimal one column !");


            langPanDBBuilder = new Dictionary<string, string>();
            langPanDBBuilder.Add("GBDBBuilder", "Database Builder");

            langPanDBBuilder.Add("LBDatabaseName", "Database Name");
            langPanDBBuilder.Add("LBCollat", "Charset/Collation");
            langPanDBBuilder.Add("LBHowTo", "How To Rename Database");

            langPanDBBuilder.Add("BTApply", "Apply");
            langPanDBBuilder.Add("BTRevert", "Revert");

            langPanDBBuilder.Add("MSGFill", "Fill database name");
            langPanDBBuilder.Add("MSGCollNotChange", "Charset/Collation not changed");

            langPanDBBuilder.Add("THDBBuilderNew", "New Database");

            langDynamicTabDoc = new Dictionary<string, string>();
            langDynamicTabDoc.Add("THNew", "New");

            langDynamicTabDoc.Add("MSGCloseTab", "Do you wanna close tab ?");


            langMessage = new Dictionary<string, string>();
            langMessage.Add("MSGError",
                            "Error Message");
            langMessage.Add("MSGSQLStetment",
                            "SQL Stetment");
            langMessage.Add("MSGAction", 
                            "Action");
            langMessage.Add("MSGMessage",
                            "Message");

            langMessage.Add("BTClearMessage", "Clear Message");

            langResultGrid = new Dictionary<string, string>();
            langResultGrid.Add("BTAdd", "Add Row");
            langResultGrid.Add("BTDel", "Delete row(s)");
            langResultGrid.Add("BTExportImport", "Import/Export");
            langResultGrid.Add("BTExport", "Export to CSV");
            langResultGrid.Add("BTImport", "Import from CSV");
            langResultGrid.Add("BTUp", "Pervius Rows Group");
            langResultGrid.Add("BTDown", "Next Rows Group");
            langResultGrid.Add("BTMode", "Mode");
            langResultGrid.Add("BTInsertOnly", "Insert Only");
            langResultGrid.Add("BTReadOnly", "Read Only");
            langResultGrid.Add("BTApply", "Apply");
            langResultGrid.Add("BTRevert", "Revert");

            langResultGrid.Add("CMOpenFile", "&Open File");
            langResultGrid.Add("CMDelRow", "Delete Row(s)");
            langResultGrid.Add("CMNewRow", "New Row");
            langResultGrid.Add("CMEditCell", "Edit Cell(s)");
            langResultGrid.Add("CMCopySelRow", "Copy Slected Row(s)");
            langResultGrid.Add("CMCopySelCell", "Copy Slected Cell(s)");
            
            langResultGrid.Add("LBPage", "Rows Group");

            langResultGrid.Add("CBIgnorePri", "Ignore edited primary key");

            langResultGrid.Add("MSGSelRowDel", "Select the rows to delete");
            langResultGrid.Add("MSGTbNotChanged", "Table grid is not changed !");
            langResultGrid.Add("MSGNothingToExec", "Nothing to execute!");
            langResultGrid.Add("MSGApplyEdit", "Apply edit data table");
            langResultGrid.Add("MSGApplyInsert", "Apply insert data");
            langResultGrid.Add("MSGOneOrMoreFailed", " (One/More Failed)");
            langResultGrid.Add("MSGWarnIgnoreEdit", "Would you like to discard \"insert data ?\"");
            langResultGrid.Add("MSGWarnSelCell", "Select cell first !");


            langExportImport = new Dictionary<string, string>();
            langExportImport.Add("THExportImport", "Expoer/Import DB");

            langExportImport.Add("GBEx", "Export Database To SQL File");
            langExportImport.Add("GBIm", "Import Database From SQL File");

            langExportImport.Add("LBPath", "Path");
            langExportImport.Add("LBSelDB", "Select DB");
            langExportImport.Add("LBStatus", "Status");

            langExportImport.Add("BTExport", "Export");
            langExportImport.Add("BTImport", "Import");
            langExportImport.Add("BTOpen", "Open");

            langExportImport.Add("MSGFileNotExist", "File does not exist");
            langExportImport.Add("MSGSelFile", "Select File");
            langExportImport.Add("MSGImporting", "Importing...");
            langExportImport.Add("MSGSelTargetDir", "Select Target Directory");
            langExportImport.Add("MSGExporting", "Exporting...");
            langExportImport.Add("MSGExportDB", "Export Database");
            langExportImport.Add("MSGImportDB", "Import Database");
            langExportImport.Add("MSGSaveDB", "Save Database To SQL File");
            langExportImport.Add("MSGOpenFile", "Open File From SQL");

            langFormImportCSV = new Dictionary<string, string>();
            langFormImportCSV.Add("FTImportCSV", "Import From CSV File");

            langFormImportCSV.Add("LBCSVFile", "CSV File");
            langFormImportCSV.Add("LBStatus", "Analyze CSV File...");

            langFormImportCSV.Add("CBContainHeader", "Is Contain Header");

            langFormImportCSV.Add("BTOpen", "Open");
            langFormImportCSV.Add("BTImport", "Import");
            langFormImportCSV.Add("BTCancel", "Cancel");

            langFormImportCSV.Add("MSGWarnOpenFile", "Open CSV file first !");
            langFormImportCSV.Add("MSGLinseIsEmpety", "Line is empty");
            langFormImportCSV.Add("MSGFieldIsEmpety", "Field is empty");
            langFormImportCSV.Add("MSGErrRead", "Error Reading CSV File : ");
            langFormImportCSV.Add("MSGWarnNumField", "Number of CSV field not match with field in table !");
            langFormImportCSV.Add("MSGImportSucc", "Import Success !");
            langFormImportCSV.Add("MSGConfrimCancel", "Do you wanna cancel Import ?");


            langFormExportCSV = new Dictionary<string, string>();
            langFormExportCSV.Add("TFExportCSV", "Export To CSV");

            langFormExportCSV.Add("CBHeaderCSV", "Without Header Table");
            langFormExportCSV.Add("CBNoHeaderCSV", "With Header Table");
            langFormExportCSV.Add("CBExFromCurr", "From current grid");
            langFormExportCSV.Add("CBExFromTb", "From table (all data)");

            langFormExportCSV.Add("LBExFrom", "Export From");
            langFormExportCSV.Add("LBCount", "Count Data...");
            langFormExportCSV.Add("LBPath", "File Path");

            langFormExportCSV.Add("BTExport", "Export");
            langFormExportCSV.Add("BTCancel", "Cancel");
            langFormExportCSV.Add("BTSave", "Save");

            langFormExportCSV.Add("MSGWarnSelDir", "You must select directory to save file");
            langFormExportCSV.Add("MSGErrCount", "Error Couting data : ");
            langFormExportCSV.Add("MSGErrWrite", "Error Write Data : ");
            langFormExportCSV.Add("MSGExportDB", "Export Database CSV file");
            langFormExportCSV.Add("MSGConfrimCacel", "Do you wanna cancel Export ?");


            langSQLEditor = new Dictionary<string, string>();
            langSQLEditor.Add("LBRead", "Read");
            langSQLEditor.Add("LBWrite", "Write");
            langSQLEditor.Add("LBLine", "Line :");
            langSQLEditor.Add("LBLength", "Length :");
            langSQLEditor.Add("LBEncoding", "Encoding :");
            langSQLEditor.Add("LBLimit", "Limit Row(s) : ");
            langSQLEditor.Add("LBFindAndReplace", "Find and Replace Text");
            langSQLEditor.Add("LBFindText", "Find Text");
            langSQLEditor.Add("LBHideLineNum", "Hide Line Number");
            langSQLEditor.Add("LBShowLineNum", "Show Line Number");
            langSQLEditor.Add("LBEnWordWarp", "Enable Word Warp");
            langSQLEditor.Add("LBDisWordWarp", "Disable Word Warp");
            langSQLEditor.Add("LBExecuteSQL", "Execute SQL");
            langSQLEditor.Add("LBSaveSQL", "Save SQL File");
            langSQLEditor.Add("LBSaveSQLAs", "Save SQL File As");
            langSQLEditor.Add("LBOpenSQL", "Open SQL File");

            langSQLEditor.Add("MSGAskClosetab", "Do you wanna save it first ?");
            langSQLEditor.Add("MSGWarnFileIsOpen", "File is opened on this tab");
            langSQLEditor.Add("MSGSave", "Save");
            langSQLEditor.Add("MSGSaveAs", "Save As");
            langSQLEditor.Add("MSGWarnFileNotExist", "File does not exist/moved\r\nkeep file open ?");


            langConsole = new Dictionary<string, string>();
            langConsole.Add("HTConsole", "Console");
            langConsole.Add("MSGHelp", "Ctrl+Enter to new line");


            langUserAccount = new Dictionary<string, string>();
            langUserAccount.Add("HTUserAccount", "User Acount");

            langUserAccount.Add("DGVUsers", "Users"); 
            langUserAccount.Add("DGVHost", "Host");

            langUserAccount.Add("LBUser", "User Name");
            langUserAccount.Add("LBHost", "Host");
            langUserAccount.Add("LBPass", "Password"); 
            langUserAccount.Add("LBPercent", "Use '%' for any host");
            langUserAccount.Add("LBLeftPass", "Left empty if no password");
            langUserAccount.Add("LBMaxQuery", "Max Query Per Hour");
            langUserAccount.Add("LBMaxUpdates", "Max Updates Per Hour"); 
            langUserAccount.Add("LBMaxConn", "Max Connections Per Hour");
            langUserAccount.Add("LBMaxUserConn", "Max User Connection");
            langUserAccount.Add("LBSelDB", "Selct Database");
            langUserAccount.Add("LBSelTB", "Select Table");

            langUserAccount.Add("GBCreate", "Create User");
            langUserAccount.Add("GBData", "Data");
            langUserAccount.Add("GBStruct", "Structure");
            langUserAccount.Add("GBAdmin", "Administration");

            langUserAccount.Add("BTCreate", "Create User");
            langUserAccount.Add("BTChangePass", "Change Password");
            langUserAccount.Add("BTRemove", "Remove User");
            langUserAccount.Add("BTEditPriv", "Cahnge Privilages");
            langUserAccount.Add("BTNext", "Next");
            langUserAccount.Add("BTBack", "Back");
            langUserAccount.Add("BTApply", "Apply");
            langUserAccount.Add("BTCancel", "Cancel");
            langUserAccount.Add("BTGlobPriv", "Global Priv");
            langUserAccount.Add("BTDBPriv", "Database Priv");
            langUserAccount.Add("BTTBPriv", "Table Priv");

            langUserAccount.Add("MSGSelUser", "Select user on grid");
            langUserAccount.Add("MSGWarnDropUser", "Are you sure wat to drop user");
            langUserAccount.Add("MSGChangePass", "Change Password");
            langUserAccount.Add("MSGFillUser", "Fill user !");
            langUserAccount.Add("MSGFillHost", "Fill host or fill with '%' for any host !");
            langUserAccount.Add("MSGUserNotFound", "User not found");
            langUserAccount.Add("MSGConfrim", "Are you sure ?");
            langUserAccount.Add("MSGSelDB", "Select Database first !");
            langUserAccount.Add("MSGSelTB", "Select Table first");
            langUserAccount.Add("MSGCheckUser", "Checking priv user");


            langTableBuilder = new Dictionary<string, string>();
            langTableBuilder.Add("LBTBName", "Table Name");
            langTableBuilder.Add("LBTBColl", "Collation");
            langTableBuilder.Add("LBTBComment", "Comment");
            langTableBuilder.Add("LBTBDatabase", "Database");
            langTableBuilder.Add("LBTBEngine", "Engine");
            langTableBuilder.Add("LBColName", "Column Name");
            langTableBuilder.Add("LBColComment", "Comment");
            langTableBuilder.Add("LBColColl", "Collation");
            langTableBuilder.Add("LBColDataType", "Data Type");
            langTableBuilder.Add("LBColStorage", "Storage");
            langTableBuilder.Add("LBColLen", "Length");
            langTableBuilder.Add("LBColList", "List");

            langTableBuilder.Add("GBColumn", "Column");

            langTableBuilder.Add("BTAddCol", "Add Column");
            langTableBuilder.Add("BTEditCol", "Edit Column");
            langTableBuilder.Add("BTDelColumn", "Remove Column");
            langTableBuilder.Add("BTSaveEdit", "Save Edit");
            langTableBuilder.Add("BTCancelEdit", "Cancel Edit");
            langTableBuilder.Add("BTUpRow", "Move Row Up");
            langTableBuilder.Add("BTDownRow", "Move Row Down");
            langTableBuilder.Add("BTApply", "Apply");
            langTableBuilder.Add("BTRevert", "Revert");

            langTableBuilder.Add("DGVColName", "Column Name");
            langTableBuilder.Add("DGVDataType", "Data Type");

            langTableBuilder.Add("MSGGetDbInfo", "get database information");
            langTableBuilder.Add("MSGGetCollateInfo", "Error get collation db");
            langTableBuilder.Add("MSGGetTbInfo", "Get information table");
            langTableBuilder.Add("MSGColIsExist", "Column name is exist");
            langTableBuilder.Add("MSGDataTypeNotSelected", "Data type not selected");
            langTableBuilder.Add("MSGFillColName", "Fill column name");
            langTableBuilder.Add("MSGIncorectFormat", "Incorrect format length");
            langTableBuilder.Add("MSGIncorectFormatLsVal", "Incorrect format list value");
            langTableBuilder.Add("MSGExFillListVal", "Example for fill list value\" enum : 'val1', 'val2'\"");
            langTableBuilder.Add("MSGExpEmpty", "Expression can not be empety");
            langTableBuilder.Add("MSGFillTbName", "Fill table name !");
            langTableBuilder.Add("MSGNoCol", "You have no collumn in table !");
            langTableBuilder.Add("MSGTBNoChange", "Table not changed");
            langTableBuilder.Add("MSGAlterTB", "Alter Table");
            langTableBuilder.Add("MSGCannotGetInfo", "Alter table stetment executed but cannont get information the table");
            langTableBuilder.Add("MSGTBNotFoud", "The table not found it maybe deleted");
            langTableBuilder.Add("MSGCreateTB", "Create Table ");
            langTableBuilder.Add("MSGCannotGetInfoCr", "Creat table stetment executed but cannont get information table");
        }

        public static void initializeLangId() {
            langMainMenu = new Dictionary<string, string>();
            langMainMenu.Add("MMFiles", "&Fail");
            langMainMenu.Add("MMView", "&Tampilan");
            langMainMenu.Add("MMCreate", "&Buat");
            langMainMenu.Add("MMTools", "&Peralatan");
            langMainMenu.Add("MMHelp", "&Bantuan");

            langMainMenu.Add("SMMNewSql", "&Buat Fail SQL Baru");
            langMainMenu.Add("SMMOpenSql", "&Buka Fail SQL");
            langMainMenu.Add("SMMSaveSqlFile", "&Simpan Fail SQL");
            langMainMenu.Add("SMMSaveAsSqlFile", "Simpan Sebagai Fail Sql Baru");
            langMainMenu.Add("SMMCloseConn", "&Tutup Koneksi");
            langMainMenu.Add("SMMExit", "&Keluar");

            langMainMenu.Add("SMMDatabaseExplorer", "&Penjelajah Database");
            langMainMenu.Add("SMMServerIdentity", "&Identitas Server");
            langMainMenu.Add("SMMOutput", "&Hasil Keluaran");
            langMainMenu.Add("SMMHideAllPanle", "&Sembunyikan Semuanya");

            langMainMenu.Add("SMMCreateDatabase", "Baut &Database");
            langMainMenu.Add("SMMCreateTable", "Buat &Tabel");

            langMainMenu.Add("SMMOpenConsole", "&Buka konsol");
            langMainMenu.Add("SMMImportExportDatabase", "&Impor/Ekspor Database");
            langMainMenu.Add("SMMUserAccount", "&Akun User");
            langMainMenu.Add("SMMSetting", "&Pengaturan");

            langMainMenu.Add("SMMAbout", "&Tentang");

            langMainMenu.Add("TSLDatabaseExplorer", "Penjelajah Database");
            langMainMenu.Add("TSLServerIdentity", "Identitas Server");
            langMainMenu.Add("TSLOutput", "Keluaran");

            langMainMenu.Add("DTXTVersion", "Versi");
            langMainMenu.Add("DTXTBasedir", "Basis Direktori");
            langMainMenu.Add("DTXTCompiled", "Program Yang Dikompilasi");

            langMainMenu.Add("TSLLoadDatabase", "Muat Database");
            langMainMenu.Add("TSBLSetDBAsDef", "Stel Database Sebagai Sering Yang Di Gunakan");
            langMainMenu.Add("TSBLRefresh", "Perbaharui");

            langMainMenu.Add("TTMessage", "Pesan");
            langMainMenu.Add("TTResultGrid", "Hasil Grid");

            langMainMenu.Add("CMSRefresh", "&Perbaharui");
            langMainMenu.Add("CMSSetDBAsDef", "&Stel Database Sebagai Sering Yang Di Gunakan");
            langMainMenu.Add("CMSDatabase", "&Database");
            langMainMenu.Add("CMSTable", "&Tabel");

            langMainMenu.Add("CSMSAlterDB", "&Ubah Database");
            langMainMenu.Add("CSMSDropDB", "&Hapus Database");
            langMainMenu.Add("CSMSCraeteTable", "&Buat Tabel");

            langMainMenu.Add("CSMSAlterTB", "&Ubah Table");
            langMainMenu.Add("CSMSDropTB", "&Hapus Table");
            langMainMenu.Add("CSMSEditData", "&Sunting Data Tabel Di Grid");

            langMainMenu.Add("MSGWaitAllDatabase",
@"Sekarang menunggu memuat database ke penjelajah..."
);
            langMainMenu.Add("MSGWaitConn", "Menyambungkan Koneksi...");
            langMainMenu.Add("MSGErrLoadDbTree", "Memuat database ke penjelajah");
            langMainMenu.Add("MSGStetmentExec", "Statmen tereksekusi");
            langMainMenu.Add("MSGErrStetmentAbort", "Statmen terbatalkan");
            langMainMenu.Add("MSGWarnSelectItem", "Pili isi penjelajah telebih dahulu");
            langMainMenu.Add("MSGErrSetDB", "Stel database {0} sebagai sering yang digunakan gagal !");
            langMainMenu.Add("MSGDBCannotDrop", "Sekearang database tidak bisa di hapus dulu");
            langMainMenu.Add("MSGDbExistOnTab", "Database ini terdapat di tab, apakah ingin di lanjutakan ?");
            langMainMenu.Add("MSGDbNotFound", "Database tidak di temukan !");
            langMainMenu.Add("MSGActionDropDB", "Hapus Database");
            langMainMenu.Add("MSGTbExistOnTab", "Tabel ini terdapat di tab, apakah ingin di lanjutakan ?");
            langMainMenu.Add("MSGTbNotFound", "Tabel tidak di temukan !");
            langMainMenu.Add("MSGActionDropTB", "Hapus Tabel");
            langMainMenu.Add("MSGNoPrimary",
@"                 Tabel ini tidak terdapat pimary key
       Artinya anda tidak bisa memperbaharui/hapus dengan spesifik
   klik 'yes' untuk melanjutkan, tapi hanya bisa memasukan data saja.");
            langMainMenu.Add("MSGConfrimCloseConn",
@"                       Yakin anda ingin menutup koneksi ? 
peringatan, simpan/terapkan dahulu sebelum menutup koneksi dikarnakan, 
                   semua konten di tab akan di tutup paksa 
                 tanpa menyimpan/menerapkan terlebih dahulu");
            langMainMenu.Add("MSGWarnSelectDB", "Pilih database terlebih dahulu !");
            langMainMenu.Add("MSGWarnDiscardAllContent", "Tutup saja tanpa menyimpan/menerapkan konten dalam tab ?");
            langMainMenu.Add("MSGErrTryCloseConn", "Mencoba menutup koneksi ");

            langFormConnection = new Dictionary<string, string>();
            langFormConnection.Add("TWNeConnNew", "Koneksi Baru");
            langFormConnection.Add("TWNeConnEdit", "Edit Koneksi");

            langFormConnection.Add("GBTNewConnection", "Form Koneksi");

            langFormConnection.Add("LBConnectionName", "Nama Koneksi");
            langFormConnection.Add("LBHostName", "Nama Host");
            langFormConnection.Add("LBUserName", "Nama User");
            langFormConnection.Add("LBPassword", "Password");
            langFormConnection.Add("LBDefaultDatabase", "DB Di Gunakan");
            langFormConnection.Add("LBHavePass", "Password");
            langFormConnection.Add("LBHavePassYes", "Ya");
            langFormConnection.Add("LBHavePassNo", "Tidak");

            langFormConnection.Add("BTTestConn", "Tes Koneksi");
            langFormConnection.Add("BTSave", "Simpan");
            langFormConnection.Add("BTClearPass", "Hapus Passwod");
            langFormConnection.Add("BTSetPass", "Beri Password");

            langFormConnection.Add("CBTAskPass", "Pinta Password Ketika Login");

            langFormConnection.Add("TFNew",  "Koneksi Baru");
            langFormConnection.Add("TFEdit", "Edit Koneksi");

            langFormConnection.Add("MSGFillConnName", "Isi nama koneksi");
            langFormConnection.Add("MSGFillHost", "Isi hostname");
            langFormConnection.Add("MSGFillUser", "Isi Username");
            langFormConnection.Add("MSGConnNameExist", "Nama koneksi sudah ada\r\n pilih dengan nama lain");
            langFormConnection.Add("MSGTryConn", "Mencoba koneksi");
            langFormConnection.Add("MSGConnMysql", "Terkoneksi dengan MySQL");
            langFormConnection.Add("MSGErrSaveConn", "Tetap simpan koneksi yang tidak valid ini ?");
            langFormConnection.Add("MSGErrEditConn", "Tetap ubah koneksi yang tidak valid ini ?");
            langFormConnection.Add("MSGConnected", "Terkoneksi");
            langFormConnection.Add("MSGNotConnected", "Tidak Terkoneksi");

            langStartPage = new Dictionary<string, string>();
            langStartPage.Add("HTStartPage", "Halaman Utama");
            langStartPage.Add("BTNewConnection", "Koneksi\nBaru");
            langStartPage.Add("LBListConnection", "Lis Koneksi");

            langStartPage.Add("CMOpenConn", "Buka koneksi");
            langStartPage.Add("CMEditConn", "Edit koneksi");
            langStartPage.Add("CMDelConn", "Hapus Koneksi");

            langStartPage.Add("MSGErrConnName", "Nama koneksi tidak di temukan");
            langStartPage.Add("MSGWorngPass", "Password salah");
            langStartPage.Add("MSGConnWork", "Terkoneksi, selamat datang !");
            langStartPage.Add("MSGTryToConn", "Mengkoneksiklan ke MySQL");
            langStartPage.Add("MSGApplyDel", "Yakin ingin menghapus koneksi ini ?");
            langStartPage.Add("MSGConnDel", "Koneksi terhapus");


            langFormSetting = new Dictionary<string, string>();
            langFormSetting.Add("TFormSetting", "Pengaturan");

            langFormSetting.Add("LBLimit", "Limit Ketika Menggunakan Select");
            langFormSetting.Add("LBLanguage", "Bahasa");

            langFormSetting.Add("BTOk", "OK");

            langFormSetting.Add("MSGRestart", "Aplikasi harus mulai dari awal untuk perubahan bahasa");

            langFormSqlPreview = new Dictionary<string, string>();
            langFormSqlPreview.Add("FTSQLPreview", "Pratinjau SQL");
            langFormSqlPreview.Add("BTApply", "Terapkan");
            langFormSqlPreview.Add("BTCancel", "Batal");
            langFormSqlPreview.Add("BTBack", "Kembali");
            langFormSqlPreview.Add("BTOk", "OK");

            langFormSqlPreview.Add("MSGAction1", "Stetmen tereksekusi");
            langFormSqlPreview.Add("MSGAction2", "Aksi");
            langFormSqlPreview.Add("MSGNothingToExec", "Tidak ada yang tereksekusi");
            langFormSqlPreview.Add("MSGSqlStat", "SQL Stetmen");
            langFormSqlPreview.Add("MSGErrorSql", "Pesan Error");
            langFormSqlPreview.Add("MSGSucc", " (Sukses)");
            langFormSqlPreview.Add("MSGFail", " (Satu atau lebih gagal tereksekusi)");

            
            langFormHowTo = new Dictionary<string, string>();
            langFormHowTo.Add("FTHowTo", "Cara Mengubah Nama Database");
            langFormHowTo.Add("HTMLHowTo",
@"
<p class=MsoNormal align=center style='text-align:center;line-height:150%'><b><span
style='font-size:14.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>
Mengubah nama database <br> di MySQL terbaru</span></b></p>

<p class=MsoNormal align=center style='text-align:center;line-height:150%'><b><span
style='font-size:14.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>&nbsp;</span></b></p>

<p class=MsoNormal style='text-align:justify;text-indent:36.0pt;line-height:
150%'><span style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>
di MySQL terbaru tidak bisa langsung mengubah nama database, di karnakan resiko keamanan
jadi untuk mengubah nama database dengan cara lain seperti membuat database baru dengan nama database yang mau di ubah
lalu menyimpan (ekspor) database ke fail SQL dan mengimpor kembali di database baru di MySQL
</span></p>

<p class=MsoNormal style='text-align:justify;line-height:150%'><b><span
style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>
Membuat Database Baru</span></b></p>

<p class=MsoNormal align=center style='text-align:center;line-height:150%'><span
style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'><img
width=500 height=378 id=""Picture 1""
src=""ex_1.png""></span></p>

<p class=MsoNormal style='text-align:justify;text-indent:36.0pt;line-height:
150%'><span style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>
Buat database baru dengan nama yang ingin di ubah di menu utama Buat-&gt;Buat Database.</span></p>

<p class=MsoNormal style='text-align:justify;line-height:150%'><b><span
style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>
Simpan database ke fail SQL (Ekspor)</span></b></p>

<p class=MsoNormal align=center style='text-align:center;line-height:150%'><b><span
style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'><img
width=560 height=210 id=""Picture 2""
src=""ex_2.png""></span></b></p>

<p class=MsoNormal style='text-align:justify;text-indent:36.0pt;line-height:
150%'><span style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>
Buka &quot;Impor/Ekspor Database dan simpan database ke fail&quot; SQL, 
di menu utama Peralatan-&gt;Impor/Ekspor Database, pilih database yang ingin di ubah namanya
dan pilih folder untuk menyimpan fail SQL setelah itu klik tombol ekspor.</span></p>

<p class=MsoNormal style='line-height:150%'><b><span style='font-size:12.0pt;
line-height:150%;font-family:""Times New Roman"",""serif""'>
Simpan kembali database dari fil SQL ke database baru (Impor)</span></b></p>

<p class=MsoNormal align=center style='text-align:center;line-height:150%'><b><span
style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'><img
width=550 height=166 id=""Picture 3""
src=""ex_3.png""></span></b></p>

<p class=MsoNormal style='text-align:justify;text-indent:36.0pt;line-height:
150%'><span style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>
Setelah di ekspor ke fail SQL, impor database dari fail SQL ke database baru yang telah di buat tadi
dengan pilih database baru lalu pilih fail SQL-nya terus klik tombol impor.</span></p>

<p class=MsoNormal style='text-align:justify;line-height:150%'><b><span
style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>
Hapus database yang telah terekspor</span></b></p>

<p class=MsoNormal align=center style='text-align:center;line-height:150%'><b><span
style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'><img
width=448 height=249 id=""Picture 4""
src=""ex_4.png""></span></b></p>

<p class=MsoNormal style='text-align:justify;text-indent:36.0pt;line-height:
150%'><span style='font-size:12.0pt;line-height:150%;font-family:""Times New Roman"",""serif""'>
Jika database telah terimpor maka hapus database yang telah terekspor,
untuk menghapus database klik kanan pada databas di penjelajah database
dan pilih menu konteks Database-&gt;Hapus Database setelah itu akan muncul
pratinjau SQL dan klik tombol konfir untuk mengeksekusi stetmen SQL.</span></p>
");


            langFormAbout = new Dictionary<string, string>();
            langFormAbout.Add("FTAbout", "Tentang Pembuat");
            langFormAbout.Add("FTAboutText",
@"Pembuat" + "\t\t" + @": Rizki Munandar
NIM" + "\t\t\t" + @": 12720009

Nama Aplikasi" + "\t" + @": MySql Client .NET (MCDN)
Dibuat" + "\t\t\t" + @": Visual C# 2013 Community Edition
Kontak" + "\t\t" + @": munandar.rizki@gmail.com
" + "\t\t\t" + @"  win32hacked@gmail.com"
);


            langFormSelCol = new Dictionary<string, string>();
            langFormSelCol.Add("FTSelectCol", "Pilih Kolom");

            langFormSelCol.Add("LBDbTb", "Database.Tabel");

            langFormSelCol.Add("BTUp", "Atas");
            langFormSelCol.Add("BTDown", "Bawah");
            langFormSelCol.Add("BTApply", "Terapkan");
            langFormSelCol.Add("BTCancel", "Batal");

            langFormSelCol.Add("MSGHaveNoCol",
@"Kolom minimal satu !");


            langPanDBBuilder = new Dictionary<string, string>();
            langPanDBBuilder.Add("GBDBBuilder", "Pembuat Database");

            langPanDBBuilder.Add("LBDatabaseName", "Nama Database");
            langPanDBBuilder.Add("LBCollat", "Charset/Collation");
            langPanDBBuilder.Add("LBHowTo", "Cara Ubah Nama Database");

            langPanDBBuilder.Add("BTApply", "Terapkan");
            langPanDBBuilder.Add("BTRevert", "Kembali");

            langPanDBBuilder.Add("MSGFill", "Isi nama database");
            langPanDBBuilder.Add("MSGCollNotChange", "Charset/Collation tidak berubah");
            langPanDBBuilder.Add("THDBBuilderNew", "Database Baru");

            
            langDynamicTabDoc = new Dictionary<string, string>();
            langDynamicTabDoc.Add("THNew", "Baru");

            langDynamicTabDoc.Add("MSGCloseTab", "Anda yakin ingin menutup tab ?");


            langMessage = new Dictionary<string, string>();
            langMessage.Add("MSGError",
                            "Pesan Error");
            langMessage.Add("MSGSQLStetment",
                            "Stetmen SQL");
            langMessage.Add("MSGAction",
                            "Aksi");
            langMessage.Add("MSGMessage",
                            "Pesan");

            langMessage.Add("BTClearMessage", "Bersihkan Pesan");


            langResultGrid = new Dictionary<string, string>();
            langResultGrid.Add("BTAdd", "Tamabah baris");
            langResultGrid.Add("BTDel", "Hapus Baris");
            langResultGrid.Add("BTExportImport", "Impor/Ekspor");
            langResultGrid.Add("BTExport", "Ekspor ke CSV");
            langResultGrid.Add("BTImport", "Impor dari CSV");
            langResultGrid.Add("BTUp", "Klompok Baris Sebelumnya");
            langResultGrid.Add("BTDown", "Klompok Baris Selanjutnya");
            langResultGrid.Add("BTMode", "Mode");
            langResultGrid.Add("BTInsertOnly", "Hanya memasukan saja");
            langResultGrid.Add("BTReadOnly", "Di lihat saja");
            langResultGrid.Add("BTApply", "Terapkan");
            langResultGrid.Add("BTRevert", "Kembali");

            langResultGrid.Add("CMOpenFile", "&Buka fail");
            langResultGrid.Add("CMDelRow", "Hapus Baris");
            langResultGrid.Add("CMNewRow", "Baris Baru");
            langResultGrid.Add("CMEditCell", "Ubah nilai sel");
            langResultGrid.Add("CMCopySelRow", "Salin baris yang terpilih");
            langResultGrid.Add("CMCopySelCell", "Salin sel yang terpilih");

            langResultGrid.Add("LBPage", "Klompok Baris Ke ");

            langResultGrid.Add("CBIgnorePri", "Lewati primary key yang terubah");

            langResultGrid.Add("MSGSelRowDel", "Pilih baris untuk menghapus");
            langResultGrid.Add("MSGTbNotChanged", "Data tidak berubah");
            langResultGrid.Add("MSGNothingToExec", "Tidak ada yang akan di eksekusi");
            langResultGrid.Add("MSGApplyEdit", "Terapkan pengubahan data dalam tabel");
            langResultGrid.Add("MSGApplyInsert", "Terapkan pemasukan data ke dalam tabel");
            langResultGrid.Add("MSGOneOrMoreFailed", " (Satu/lebih gagal)");
            langResultGrid.Add("MSGWarnIgnoreEdit", "batalkan untuk memasukan data");
            langResultGrid.Add("MSGWarnSelCell", "Pilih sel dulu");


            langExportImport = new Dictionary<string, string>();
            langExportImport.Add("THExportImport", "Ekspor/Impor DB");

            langExportImport.Add("GBEx", "Ekspor Database Ke Berkas SQL");
            langExportImport.Add("GBIm", "Impor Database Dari Berkas SQL");

            langExportImport.Add("LBPath", "Letak");
            langExportImport.Add("LBSelDB", "Pilih DB");
            langExportImport.Add("LBStatus", "Status");

            langExportImport.Add("BTExport", "Ekspor");
            langExportImport.Add("BTImport", "Impor");
            langExportImport.Add("BTOpen", "Buka");

            langExportImport.Add("MSGFileNotExist", "fail Tidak di temukan");
            langExportImport.Add("MSGSelFile", "Pilih fail !");
            langExportImport.Add("MSGImporting", "Mengimpor...");
            langExportImport.Add("MSGSelTargetDir", "Pilih letak fail");
            langExportImport.Add("MSGExporting", "Mengekspor...");
            langExportImport.Add("MSGExportDB", "Ekspor Database");
            langExportImport.Add("MSGImportDB", "Impor Database");
            langExportImport.Add("MSGSaveDB", "Simpan Database Ke fail SQL");
            langExportImport.Add("MSGOpenFile", "Buka fail Dari fail SQL");


            langFormImportCSV = new Dictionary<string, string>();
            langFormImportCSV.Add("FTImportCSV", "Impor Dari Fail CSV");

            langFormImportCSV.Add("LBCSVFile", "Fail CSV");
            langFormImportCSV.Add("LBStatus", "Alisa Fail CSV...");

            langFormImportCSV.Add("CBContainHeader", "Terdapat Judul Kolom");

            langFormImportCSV.Add("BTOpen", "Buka");
            langFormImportCSV.Add("BTImport", "impor");
            langFormImportCSV.Add("BTCancel", "Batal");

            langFormImportCSV.Add("MSGWarnOpenFile", "Open CSV file first !");
            langFormImportCSV.Add("MSGLinseIsEmpety", "Line is empty");
            langFormImportCSV.Add("MSGFieldIsEmpety", "Kolom kosong di dalam fail CSV");
            langFormImportCSV.Add("MSGErrRead", "Error Membaca Fail CSV : ");
            langFormImportCSV.Add("MSGWarnNumField", "Kolom di dalam fail CSV tidak sama dengan tabel yang sekarang !");
            langFormImportCSV.Add("MSGImportSucc", "Sukses Mengimpor !");
            langFormImportCSV.Add("MSGConfrimCancel", "Yakin ingin di batalkan ?");


            langFormExportCSV = new Dictionary<string, string>();
            langFormExportCSV.Add("TFExportCSV", "Ekspor Ke Fail CSV");

            langFormExportCSV.Add("CBHeaderCSV", "Tanpa Judul Kolom");
            langFormExportCSV.Add("CBNoHeaderCSV", "Dengan Judul Kolom");

            langFormExportCSV.Add("LBExFrom", "Ekspor Dari");
            langFormExportCSV.Add("LBCount", "Menghitung Data...");
            langFormExportCSV.Add("LBPath", "Lokasi Fail");

            langFormExportCSV.Add("BTExport", "Ekspor");
            langFormExportCSV.Add("BTCancel", "Batal");
            langFormExportCSV.Add("BTSave", "Simpan");

            langFormExportCSV.Add("CBExFromCurr", "Dari data yang sekarang");
            langFormExportCSV.Add("CBExFromTb", "Semua data dalam tabel");

            langFormExportCSV.Add("MSGWarnSelDir", "Pili letak fail untuk menyimpan fail CSV");
            langFormExportCSV.Add("MSGErrCount", "Error Menghitung Data : ");
            langFormExportCSV.Add("MSGErrWrite", "Error Menulis Data : ");
            langFormExportCSV.Add("MSGExportDB", "Ekspor Database Ke Fail CSV");
            langFormExportCSV.Add("MSGConfrimCacel", "Yakin ingin membatalkan ekspor ?");


            langSQLEditor = new Dictionary<string, string>();
            langSQLEditor.Add("LBRead", "Baca");
            langSQLEditor.Add("LBWrite", "Tulis");
            langSQLEditor.Add("LBLine", "Baris :");
            langSQLEditor.Add("LBLength", "Panjang :");
            langSQLEditor.Add("LBEncoding", "Pengkode :");
            langSQLEditor.Add("LBLimit", "Batas Baris : ");
            langSQLEditor.Add("LBFindAndReplace", "Temukan Dan Ganti Teks");
            langSQLEditor.Add("LBFindText", "Temukan Teks");
            langSQLEditor.Add("LBHideLineNum", "Hilangkan Nomber Baris");
            langSQLEditor.Add("LBShowLineNum", "Tampilkan Nomber Baris");
            langSQLEditor.Add("LBEnWordWarp", "Aktifkan Word Warp");
            langSQLEditor.Add("LBDisWordWarp", "Nonaktifkan Word Warp");
            langSQLEditor.Add("LBExecuteSQL", "Eksekusi SQL");
            langSQLEditor.Add("LBSaveSQL", "Simpan Fail SQL");
            langSQLEditor.Add("LBSaveSQLAs", "Simpan Fail SQL Sebagai");
            langSQLEditor.Add("LBOpenSQL", "Buka Fail SQL");

            langSQLEditor.Add("MSGAskClosetab", "Apkah ingin di simpan terlebihdahulu ?");
            langSQLEditor.Add("MSGWarnFileIsOpen", "Fail sudah terbuka di tab ini");
            langSQLEditor.Add("MSGSave", "Simpan");
            langSQLEditor.Add("MSGSaveAs", "Simpan Sebagai...");
            langSQLEditor.Add("MSGWarnFileNotExist", "Fail tidak di temukan atau sudah di pindahkan\r\nApakah fail ini tetap terbuka ?");


            langConsole = new Dictionary<string, string>();
            langConsole.Add("HTConsole", "Konsol");
            langConsole.Add("MSGHelp", "Ctrl+Enter untuk baris baru");


            langUserAccount = new Dictionary<string, string>();
            langUserAccount.Add("HTUserAccount", "Akun User");

            langUserAccount.Add("DGVUsers", "User");
            langUserAccount.Add("DGVHost", "Host");

            langUserAccount.Add("LBUser", "Nama User");
            langUserAccount.Add("LBHost", "Host");
            langUserAccount.Add("LBPass", "Password");
            langUserAccount.Add("LBPercent", "Gunakan '%' untuk semua host");
            langUserAccount.Add("LBLeftPass", "Kosongkan password jika tidak pakai");
            langUserAccount.Add("LBMaxQuery", "Maks Query Per Jam");
            langUserAccount.Add("LBMaxUpdates", "Maks Perbaharui Per jam");
            langUserAccount.Add("LBMaxConn", "Maks Koneksi Per jam");
            langUserAccount.Add("LBMaxUserConn", "Maks Pengguba Koneksi");
            langUserAccount.Add("LBSelDB", "Pilih Database");
            langUserAccount.Add("LBSelTB", "Pilih Tabel");

            langUserAccount.Add("GBCreate", "Buat User");
            langUserAccount.Add("GBData", "Data");
            langUserAccount.Add("GBStruct", "Struktur");
            langUserAccount.Add("GBAdmin", "Adminstrasi");

            langUserAccount.Add("BTCreate", "Buat User");
            langUserAccount.Add("BTChangePass", "Ganti Pasword");
            langUserAccount.Add("BTRemove", "Hapus User");
            langUserAccount.Add("BTEditPriv", "Ubah Hakakses");
            langUserAccount.Add("BTNext", "Lanjut");
            langUserAccount.Add("BTBack", "Kembali");
            langUserAccount.Add("BTApply", "Terapkan");
            langUserAccount.Add("BTCancel", "Batal");
            langUserAccount.Add("BTGlobPriv", "Hak Akses Global");
            langUserAccount.Add("BTDBPriv", "Hak Akses Database");
            langUserAccount.Add("BTTBPriv", "Hak Akses Tabel");

            langUserAccount.Add("MSGSelUser", "Pilih user telebih dahulu");
            langUserAccount.Add("MSGWarnDropUser", "Anda yakin ingi hapus user");
            langUserAccount.Add("MSGChangePass", "Ganti Password");
            langUserAccount.Add("MSGFillUser", "Isi nama user !");
            langUserAccount.Add("MSGFillHost", "Isi host atau isi dengan '%' untuk semua host !");
            langUserAccount.Add("MSGUserNotFound", "User tidak di temukan");
            langUserAccount.Add("MSGConfrim", "Anda yakin ?");
            langUserAccount.Add("MSGSelDB", "Pilih Database terlebih dahulu !");
            langUserAccount.Add("MSGSelTB", "Pilih Table terlebihdahulu");
            langUserAccount.Add("MSGCheckUser", "Mengecek hak akses user");


            langTableBuilder = new Dictionary<string, string>();
            langTableBuilder.Add("LBTBName", "Nama Tabel");
            langTableBuilder.Add("LBTBColl", "Collation");
            langTableBuilder.Add("LBTBComment", "Komen");
            langTableBuilder.Add("LBTBDatabase", "Database");
            langTableBuilder.Add("LBTBEngine", "Engine");
            langTableBuilder.Add("LBColName", "Nama Kolom");
            langTableBuilder.Add("LBColComment", "Komen");
            langTableBuilder.Add("LBColColl", "Collation");
            langTableBuilder.Add("LBColDataType", "Tipe Data");
            langTableBuilder.Add("LBColStorage", "Storage");
            langTableBuilder.Add("LBColLen", "Panjang");
            langTableBuilder.Add("LBColList", "Lis");

            langTableBuilder.Add("GBColumn", "Kolom");

            langTableBuilder.Add("BTAddCol", "Tambah Kolom");
            langTableBuilder.Add("BTEditCol", "Sunting kolom");
            langTableBuilder.Add("BTDelColumn", "Hapus Kolom");
            langTableBuilder.Add("BTSaveEdit", "Simpan Sunting");
            langTableBuilder.Add("BTCancelEdit", "Batal Sunting");
            langTableBuilder.Add("BTUpRow", "Pindah kolom ke atas");
            langTableBuilder.Add("BTDownRow", "Pindah kolomm ke bawah");
            langTableBuilder.Add("BTApply", "Terapkan");
            langTableBuilder.Add("BTRevert", "Kembali");

            langTableBuilder.Add("DGVColName", "Nama Kolom");
            langTableBuilder.Add("DGVDataType", "Tipe Data");

            langTableBuilder.Add("MSGGetDbInfo", "Dapatkan informasi database");
            langTableBuilder.Add("MSGGetCollateInfo", "Error dapatkan iformasi collation datbase");
            langTableBuilder.Add("MSGGetTbInfo", "Dapatkan informasi tabel");
            langTableBuilder.Add("MSGColIsExist", "Nama kolom sudah ada");
            langTableBuilder.Add("MSGDataTypeNotSelected", "Tipe data tidak di pilih");
            langTableBuilder.Add("MSGFillColName", "Isi nama kolom");
            langTableBuilder.Add("MSGIncorectFormat", "Format salah");
            langTableBuilder.Add("MSGIncorectFormatLsVal", "Format salah lis nilai");
            langTableBuilder.Add("MSGExFillListVal", "Conto yang benar \" enum : 'nil1', 'nil2'\"");
            langTableBuilder.Add("MSGExpEmpty", "Expression tidak bole kosong");
            langTableBuilder.Add("MSGFillTbName", "isi nama tabel !");
            langTableBuilder.Add("MSGNoCol", "Kolom minimal satu !");
            langTableBuilder.Add("MSGTBNoChange", "Tabel tidak berubah");
            langTableBuilder.Add("MSGAlterTB", "Ubah tabel");
            langTableBuilder.Add("MSGCannotGetInfo", "stetmen perubahn tabel telah ter eksekusi tapi tidk bisa mendapatkan informasi tabel");
            langTableBuilder.Add("MSGTBNotFoud", "Tabel tidak di temukan, mungkin telah tehapus");
            langTableBuilder.Add("MSGCreateTB", "Buat tabel ");
            langTableBuilder.Add("MSGCannotGetInfoCr", "stetmen pembuatan tabel telah ter eksekusi tapi tidk bisa mendapatkan informasi tabel");
        }

    }
}
