using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Drawing;
using System.IO;
using System.ComponentModel;

namespace MySqlClientDotNET.DesignControls.SqlEditorNS {
    public class SqlEditor : DynamicTabNS.DynamicTabPage {

        #region Declar class

        private ToolStrip toolStripEditor;
        private ToolStripButton buttonOpen;
        private ToolStripButton buttonSave;
        private ToolStripButton buttonSaveAs;
        private ToolStripButton buttonExecute;
        private ToolStripButton buttonHideOrVisibleLinNumber;
        private ToolStripButton buttonWarp;
        private ToolStripButton buttonFind;
        private ToolStripButton buttonFindAndReplace;
        private ToolStripLabel labelLimit;
        private ToolStripLabel labelMode;
        private ToolStripComboBox optionLimit;
        private ToolStripSeparator splitTS1;
        private ToolStripSeparator splitTS2;
        private ToolStrip statusEditor;
        private ToolStripProgressBar progressBar;
        private ToolStripSeparator splitSE1;
        private ToolStripLabel textLine;
        private ToolStripSeparator splitSE2;
        private ToolStripLabel textEncoding;
        private ToolStripSeparator splitSE3;
        private ToolStripLabel textLength;
        private FastColoredTextBox sqlText;
        private FileIO.ReadFromText readFromText;
        private string filePath;
        private Encoding encodingFile;
        private bool isLoaded;
        private BackgroundWorker textChangedAsync;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem contextMenuCopy;
        private ToolStripMenuItem contextMenuCut;
        private ToolStripMenuItem contextMenuPaste;
        private ToolStripLabel txtLineLabel;
        private ToolStripLabel txtLengthLabel;
        private ToolStripLabel txtEncodingLabel;
        private FastColoredTextBoxNS.AutocompleteMenu autoComlete;
        
        #endregion

        public Encoding EncodingFile {
            get {
                return encodingFile;
            }

            set {
                textEncoding.Text = FileIO.FileInfo.GetEncodingS(value);
                encodingFile = value;
            }
        }

        public string FilePath {
            get {
                return filePath; ;
            }
            set {
                openFile(value);
                this.LoadedFile = value;
                filePath = value;
            }
        }

        public bool ReadOnly {
            get {
                return sqlText.ReadOnly;
            }
            set {
                labelMode.Text = (value) ? LanguageApp.langSQLEditor["LBRead"] : LanguageApp.langSQLEditor["LBRead"] + "/" + LanguageApp.langSQLEditor["LBWrite"];
                sqlText.ReadOnly = value;
            }
        }

        public override void OnClosedTab() {
            if (readFromText.IsProgress()) {
                readFromText.CancelRead();
                readFromText.ThreadReadingText.Dispose();
            }

            if (textChangedAsync.IsBusy) {
                textChangedAsync.Dispose();
            }

            sqlText.Dispose();
            textLength.Dispose();
            textLine.Dispose();
            toolStripEditor.Dispose();
            buttonOpen.Dispose();
            buttonSave.Dispose();
            buttonExecute.Dispose();
            buttonWarp.Dispose();
            buttonHideOrVisibleLinNumber.Dispose();
            buttonFind.Dispose();
            buttonFindAndReplace.Dispose();
            splitTS1.Dispose();
            splitTS2.Dispose();
            optionLimit.Dispose();
            labelLimit.Dispose();
            labelMode.Dispose();
            statusEditor.Dispose();
            progressBar.Dispose();
            splitSE1.Dispose();
            splitSE2.Dispose();
            splitSE3.Dispose();
            textLine.Dispose();
        }
        
        private void InitializeControls() {
            this.PageType = TabPageType.SqlEditor;
            this.SuspendLayout();
            filePath = string.Empty;
            textChangedAsync = new BackgroundWorker();
            textChangedAsync.WorkerSupportsCancellation = true;
            textChangedAsync.DoWork += new System.ComponentModel.DoWorkEventHandler(sqlTextChanged_Async);
            textChangedAsync.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(sqlTextChanged_Complited);
            toolStripEditor = new ToolStrip();
            buttonOpen = new ToolStripButton();
            buttonSave = new ToolStripButton();
            buttonSaveAs = new ToolStripButton();
            buttonExecute = new ToolStripButton();
            buttonWarp = new ToolStripButton();
            buttonHideOrVisibleLinNumber = new ToolStripButton();
            buttonFind = new ToolStripButton();
            buttonFindAndReplace = new ToolStripButton();
            splitTS1 = new ToolStripSeparator();
            splitTS2 = new ToolStripSeparator();
            optionLimit = new ToolStripComboBox();
            labelLimit = new ToolStripLabel();
            labelMode = new ToolStripLabel();
            statusEditor = new ToolStrip();
            progressBar = new ToolStripProgressBar();
            splitSE1 = new ToolStripSeparator();
            splitSE2 = new ToolStripSeparator();
            splitSE3 = new ToolStripSeparator();
            textLine = new ToolStripLabel();
            textEncoding = new ToolStripLabel();
            textLength = new ToolStripLabel();
            sqlText = new FastColoredTextBox();
            readFromText = new FileIO.ReadFromText();
            contextMenu = new System.Windows.Forms.ContextMenuStrip();
            contextMenuCopy = new ToolStripMenuItem();
            contextMenuCut = new ToolStripMenuItem();
            contextMenuPaste = new ToolStripMenuItem();

            contextMenuCopy.Name = "contextMenuCopy";
            contextMenuCopy.Text = "&Copy";
            contextMenuCopy.Click += new EventHandler(contextMenuItems_Click);
            contextMenuCut.Name = "contextMenuCut";
            contextMenuCut.Text = "C&ut";
            contextMenuCut.Click += new EventHandler(contextMenuItems_Click);
            contextMenuPaste.Name = "contextMenuPaste";
            contextMenuPaste.Text = "&Paste";
            contextMenuPaste.Click += new EventHandler(contextMenuItems_Click);

            contextMenu.Items.AddRange(new ToolStripItem[]{
                contextMenuCopy,
                contextMenuCut, 
                contextMenuPaste
            });

            readFromText.ReportReadingTextProgress = true;
            readFromText.ThreadReadingText.WorkerSupportsCancellation = true;

            try {
                buttonOpen.Image = Image.FromFile(ResourcesPath.img_open_S);
                buttonSave.Image = Image.FromFile(ResourcesPath.img_save_S);
                buttonSaveAs.Image = Image.FromFile(ResourcesPath.img_saveAs_S);
                buttonExecute.Image = Image.FromFile(ResourcesPath.img_execute_S);
                buttonWarp.Image = Image.FromFile(ResourcesPath.img_warp_S);
                buttonHideOrVisibleLinNumber.Image = Image.FromFile(ResourcesPath.img_num_S);
                buttonFind.Image = Image.FromFile(ResourcesPath.img_find_S);
                buttonFindAndReplace.Image = Image.FromFile(ResourcesPath.img_findreplace_S);
            } catch { }

            buttonOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            buttonOpen.Name = "buttonOpen";
            buttonOpen.Size = new System.Drawing.Size(23, 22);
            buttonOpen.Click += new EventHandler(buttonOpenClick);

            buttonSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new System.Drawing.Size(23, 22);
            buttonSave.Click += new EventHandler(buttonSaveClick);

            buttonSaveAs.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            buttonSaveAs.Name = "buttonSaveAs";
            buttonSaveAs.Size = new System.Drawing.Size(23, 22);
            buttonSaveAs.Click += new EventHandler(buttonSaveAsClick);

            buttonExecute.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            buttonExecute.Name = "buttonExecute";
            buttonExecute.Size = new System.Drawing.Size(23, 22);
            buttonExecute.Click += new EventHandler(buttonExecuteSQLClick);

            buttonWarp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonWarp.ImageTransparentColor = System.Drawing.Color.Magenta;
            buttonWarp.Name = "buttonWarp";
            buttonWarp.Size = new System.Drawing.Size(23, 22);
            buttonWarp.Click += new EventHandler(buttonWarpClick);

            buttonHideOrVisibleLinNumber.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonHideOrVisibleLinNumber.ImageTransparentColor = System.Drawing.Color.Magenta;
            buttonHideOrVisibleLinNumber.Name = "buttonHideOrVisibleLinNumber";
            buttonHideOrVisibleLinNumber.Size = new System.Drawing.Size(23, 22);
            buttonHideOrVisibleLinNumber.Click += new EventHandler(buttonVisibleLineNumClick);

            buttonFind.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new System.Drawing.Size(23, 22);
            buttonFind.Click += new EventHandler(buttonFindClick);

            buttonFindAndReplace.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonFindAndReplace.ImageTransparentColor = System.Drawing.Color.Magenta;
            buttonFindAndReplace.Name = "buttonFindAndReplace";
            buttonFindAndReplace.Size = new System.Drawing.Size(23, 22);
            buttonFindAndReplace.Click += new EventHandler(buttonFindAndReplaceClick);

            
            
            IniParser.FileIniDataParser iniFile = new IniParser.FileIniDataParser();
            IniParser.Model.IniData iniData = iniFile.ReadFile(ResourcesPath.ini_file);
            string limit = iniData["app_config"]["sql_limit"];

            optionLimit.Name = "optionLimit";
            optionLimit.AutoSize = false;
            optionLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            optionLimit.Size = new System.Drawing.Size(100, 0);
            optionLimit.Items.AddRange(MySqlConfig.ListLimit);
            optionLimit.DropDownStyle = ComboBoxStyle.DropDownList;
            optionLimit.Size = new System.Drawing.Size(optionLimit.Size.Width, 18);
            optionLimit.SelectedItem = limit;

            toolStripEditor.GripStyle = ToolStripGripStyle.Hidden;
            toolStripEditor.Name = "toolStripEditor";
            toolStripEditor.AutoSize = false;
            toolStripEditor.TabIndex = 0;
            toolStripEditor.Text = "toolStripEditor";
            toolStripEditor.Size = new System.Drawing.Size(309, 29);
            toolStripEditor.Dock = DockStyle.Top;
            toolStripEditor.Items.AddRange(new ToolStripItem[] {
                buttonOpen, buttonSave, buttonSaveAs,
                splitTS1, buttonExecute,
                labelLimit, optionLimit,
                splitTS2, buttonWarp,
                buttonHideOrVisibleLinNumber,
                buttonFind, buttonFindAndReplace
            });

            labelLimit.Name = "lableLimit";

            sqlText.Dock = DockStyle.Fill;
            //sqlText.MouseDown
            sqlText.AutoCompleteBracketsList = new char[] {
            '(', ')',
            '{', '}',
            '[', ']',
            '\"', '\"',
            '\'', '\''};
            //sqlText.CharHeight = 14;
            //sqlText.CharWidth = 8;
            //sqlText.ContextMenuStrip = contextMenu;
            sqlText.MouseDown += new MouseEventHandler(sqlText_MouseDown);
            sqlText.Cursor = System.Windows.Forms.Cursors.IBeam;
            sqlText.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            sqlText.IndentBackColor = System.Drawing.SystemColors.Control;
            sqlText.IsReplaceMode = false;
            sqlText.Location = new System.Drawing.Point(0, 0);
            sqlText.Name = "textMessage";
            sqlText.Paddings = new System.Windows.Forms.Padding(0);
            sqlText.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            sqlText.TextChanged += new EventHandler<TextChangedEventArgs>(sqlText_TextChanged);
            sqlText.KeyDown += new KeyEventHandler(sqlText_KeyDown);
            sqlText.TextChangedDelayed += new EventHandler<TextChangedEventArgs>(sqlText_TextChangedDelayed);

            progressBar.Name = "progressBar";
            progressBar.AutoSize = false;
            progressBar.Size = new System.Drawing.Size(150, 14);
            progressBar.RightToLeft = new System.Windows.Forms.RightToLeft();
            progressBar.Visible = false;

            splitSE1.Alignment = ToolStripItemAlignment.Right;

            textLine.Name = "countLine";
            textLine.Text = "0";
            textLine.Alignment = ToolStripItemAlignment.Right;

            splitSE2.Alignment = ToolStripItemAlignment.Right;

            textLength.Name = "textLength";
            textLength.Alignment = ToolStripItemAlignment.Right;
            textLength.Text = "0";

            textEncoding.Name = "textEncoding";
            textEncoding.Alignment = ToolStripItemAlignment.Right;
            textEncoding.Text = "-";

            splitSE3.Alignment = ToolStripItemAlignment.Right;

            txtLineLabel = new ToolStripLabel();
            txtLengthLabel = new ToolStripLabel();
            txtEncodingLabel = new ToolStripLabel();

            
            txtEncodingLabel.Alignment = ToolStripItemAlignment.Right;

            txtLengthLabel.Alignment = ToolStripItemAlignment.Right;

            txtLineLabel.Alignment = ToolStripItemAlignment.Right;


            statusEditor.Name = "statusEditor";
            statusEditor.Items.AddRange(new ToolStripItem[] {
                progressBar, labelMode, textEncoding,
                txtEncodingLabel, 
                splitSE1, textLength,
                txtLengthLabel,
                splitSE2, textLine,
                txtLineLabel, splitSE3
            });
            statusEditor.TabIndex = 2;
            statusEditor.GripStyle = ToolStripGripStyle.Hidden;
            statusEditor.Size = new System.Drawing.Size(309, 10);
            statusEditor.Dock = DockStyle.Bottom;

            statusEditor.Items.Add(progressBar);

            autoComlete = new FastColoredTextBoxNS.AutocompleteMenu(sqlText);
            ICollection<string> icol = MySqlConfig.ListKeyword;
            autoComlete.Items.SetAutocompleteItems(icol);
            autoComlete.AppearInterval = 100;

            this.Controls.Add(sqlText);
            this.Controls.Add(toolStripEditor);
            this.Controls.Add(statusEditor);
            Language();
            this.ResumeLayout(false);
        }

        private void Language() {
            labelMode.Text = LanguageApp.langSQLEditor["LBRead"] + "/" + LanguageApp.langSQLEditor["LBWrite"]; ;
            txtLineLabel.Text = LanguageApp.langSQLEditor["LBLine"];
            txtLengthLabel.Text = LanguageApp.langSQLEditor["LBLength"];
            txtEncodingLabel.Text = LanguageApp.langSQLEditor["LBEncoding"];
            labelLimit.Text = LanguageApp.langSQLEditor["LBLimit"];
            buttonFindAndReplace.Text = LanguageApp.langSQLEditor["LBFindAndReplace"]; ;
            buttonFind.Text = LanguageApp.langSQLEditor["LBFindText"];
            buttonHideOrVisibleLinNumber.Text = LanguageApp.langSQLEditor["LBHideLineNum"];
            buttonWarp.Text = LanguageApp.langSQLEditor["LBDisWordWarp"];
            buttonExecute.Text = LanguageApp.langSQLEditor["LBExecuteSQL"];
            buttonSave.Text = LanguageApp.langSQLEditor["LBSaveSQL"];
            buttonSaveAs.Text = LanguageApp.langSQLEditor["LBSaveSQLAs"];
            LBOpenSQL = buttonOpen.Text = LanguageApp.langSQLEditor["LBOpenSQL"];
            
            MSGAskClosetab = LanguageApp.langSQLEditor["MSGAskClosetab"];
            MSGWarnFileIsOpen = LanguageApp.langSQLEditor["MSGWarnFileIsOpen"];
            MSGSave = LanguageApp.langSQLEditor["MSGSave"];
            MSGSaveAs = LanguageApp.langSQLEditor["MSGSaveAs"];
            MSGWarnFileNotExist = LanguageApp.langSQLEditor["MSGWarnFileNotExist"];
        }

        private string MSGAskClosetab;
        private string MSGWarnFileIsOpen;
        private string MSGSave;
        private string MSGSaveAs;
        private string LBOpenSQL;
        private string MSGWarnFileNotExist;

        void sqlText_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                contextMenuCut.Enabled = contextMenuCopy.Enabled = !String.IsNullOrEmpty(sqlText.SelectedText);
                contextMenuPaste.Enabled = !String.IsNullOrEmpty(System.Windows.Forms.Clipboard.GetText());
                contextMenu.Show(System.Windows.Forms.Cursor.Position);
            }
        }

        void contextMenuItems_Click(object sender, EventArgs e) {
            if (((ToolStripMenuItem)sender).Name.Equals("contextMenuCopy")) {
                if (!String.IsNullOrEmpty(sqlText.SelectedText))
                    System.Windows.Forms.Clipboard.SetText(sqlText.SelectedText);
            }
            if (((ToolStripMenuItem)sender).Name.Equals("contextMenuCut")) {
                if (!String.IsNullOrEmpty(sqlText.SelectedText)) { 
                    System.Windows.Forms.Clipboard.SetText(sqlText.SelectedText);
                    sqlText.SelectedText = String.Empty;
                }
            }
            if (((ToolStripMenuItem)sender).Name.Equals("contextMenuPaste")) {
                if (!String.IsNullOrEmpty(System.Windows.Forms.Clipboard.GetText()))
                    sqlText.InsertText(System.Windows.Forms.Clipboard.GetText());
            }
        }

        public SqlEditor() {
            InitializeControls();
            this.LoadedFile = "";
        }

        

        private void progressReadFile(object sender, System.ComponentModel.ProgressChangedEventArgs e) {
            if (!this.Disposing)
                progressBar.Value = e.ProgressPercentage;
        }

        private void complitedReadFile(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }

            if (e.Error != null) {
                Msg.Err(e.Error.Message);
                return;
            }
            progressBar.Visible = false;
            StringBuilder sb = (StringBuilder)e.Result;
            sqlText.Text = sb.ToString();
            isLoaded = false;
        }

        private void openFile(string path) {
            isLoaded = true;
            readFromText.TextPath = path;
            
            if (!FileIO.FileInfo.isWriteAble(path)) 
                this.ReadOnly = true;

            this.EncodingFile = FileIO.FileInfo.GetEncoding(path);

            try {
                progressBar.Maximum = FileIO.FileInfo.CountLines(path);
                readFromText.ThreadReadingText.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(progressReadFile);
                readFromText.ThreadReadingText.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(complitedReadFile);
                progressBar.Visible = true;
                readFromText.StartReading();
            } catch (Exception ex) {
                Msg.Err(ex.Message);
            }
        }

        private void WriteToFile(string path) {
            Encoding encode = FileIO.FileInfo.GetEncoding(path);
            using (StreamWriter streamW = new StreamWriter(path,
                                                           false,
                                                           encode,
                                                           FileIO.FileInfo.GetBuffSize(encode))) {
                streamW.Write(sqlText.Text);
            }
        }

        public override void SelectControls() {
            sqlText.Select();
        }

        public override bool CloseTabAnyway() {
            DialogResult dialogResult = Msg.WarrnQC(MSGAskClosetab);
            switch (dialogResult) {
                case DialogResult.Yes:
                    if (!OnSaveFile())
                        return false;
                    return true;
                case DialogResult.No:
                    return true;
            }
            return false;
        }

        public bool creatFile(string titleWindow) {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = FileIO.FileInfo.GetSQLFileExtension;
            saveFile.FileName = this.TabHeaderText;
            saveFile.Title = titleWindow;
            if (saveFile.ShowDialog() == DialogResult.OK) {
                if (this.IsDuplicateFileInTab(saveFile.FileName)) {
                    Msg.Warrn(MSGWarnFileIsOpen);
                    this.ForceCloseTabPage();
                    return false;
                }
                this.filePath = saveFile.FileName;
                this.TabHeaderText = System.IO.Path.GetFileName(saveFile.FileName);
                using (StreamWriter sw = new StreamWriter(File.Open(this.FilePath, FileMode.Create), this.EncodingFile)) {
                    sw.Write(string.Empty);
                }
                return true;
            }
            return false;
        }

        public override bool OnSaveFile() {
            if (this.ReadOnly)
                return true;
            if (filePath.Equals(string.Empty)) {
                if (!creatFile(MSGSave)) {
                    return false;
                }
            }

            if (!System.IO.File.Exists(this.filePath)) {
                DialogResult dResult = Msg.WarrnQ(MSGWarnFileNotExist);

                switch (dResult) {
                    case DialogResult.Yes :
                        this.filePath = "";
                        this.IsEdited = true;
                        break;
                    case DialogResult.No :
                        this.ForceCloseTabPage();
                        return false;
                }
                
                if (!creatFile("Save")) {
                    return false;
                }
            }

            this.LockControl = true;
            this.WriteToFile(this.filePath);
            this.LockControl = false;
            if (IsEdited)
                IsEdited = false;
            return true;
        }

        #region sqlTextchanged

        private void sqlText_TextChanged(object sendr, TextChangedEventArgs e) {
            if (isLoaded)
                return;
            if (!this.IsEdited)
                this.IsEdited = true;
        }

        Style color = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        Style color_string = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        Style color_name = new TextStyle(Brushes.Green, null, FontStyle.Regular);
        void sqlText_TextChangedDelayed(object sender, TextChangedEventArgs e) {
            if (textChangedAsync.IsBusy)
                textChangedAsync.CancelAsync();
            else {
                if (textChangedAsync != null)
                    textChangedAsync.Dispose();
                textChangedAsync = new BackgroundWorker();
                textChangedAsync.WorkerSupportsCancellation = true;
                textChangedAsync.DoWork += new System.ComponentModel.DoWorkEventHandler(sqlTextChanged_Async);
                textChangedAsync.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(sqlTextChanged_Complited);
                textChangedAsync.RunWorkerAsync();
            } 
            e.ChangedRange.ClearStyle(color_string, color_name, color);
            e.ChangedRange.SetStyle(color_string, @"""""|@""""|''|@"".*?""|(?<!@)(?<range>"".*?[^\\]"")|'.*?[^\\]'");
            e.ChangedRange.SetStyle(color_name, @"``|(?<!@)`.*?[^\\]`", System.Text.RegularExpressions.RegexOptions.Multiline);
            e.ChangedRange.SetStyle(color, MySqlConfig.syntaxSQL, System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

        private void sqlTextChanged_Async(object sender, System.ComponentModel.DoWorkEventArgs e) {
            int lc, l;
            lc = 1; l = 0;

            foreach (var c in sqlText.Text) {
                if (textChangedAsync.CancellationPending) {
                    e.Cancel = true;
                    return;
                }
                ++l;
                if (c == '\n') ++lc;
            }

            string[] res = new string[] {
                lc.ToString(),
                l.ToString()
            };
            e.Result = res;
        }

        private void sqlTextChanged_Complited(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e) {
            if (e.Cancelled)
                return;
            string[] res = (string[])e.Result;
            textLine.Text = res[0];
            textLength.Text = res[1];
        }

        #endregion

        private void sqlText_KeyDown(object sender, KeyEventArgs e) {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
                this.OnSaveFile();
        }

        private void buttonSaveClick(object sender, EventArgs e) {
            this.OnSaveFile();
        }

        private void buttonSaveAsClick(object sender, EventArgs e) {
            this.creatFile(MSGSaveAs);
        }

        private void buttonOpenClick(object sender, EventArgs e) {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = LBOpenSQL;
            if (openFile.ShowDialog() == DialogResult.OK) {
                if (this.IsEdited && sqlText.Text.Length != 0) {
                    DialogResult dResult = Msg.WarrnQC(MSGAskClosetab);
                    switch (dResult) {
                        case DialogResult.Yes:
                            this.OnSaveFile();
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.Cancel:
                            return;
                    }
                }

                if (this.IsDuplicateFileInTab(this.LoadedFile)) {
                    Msg.Warrn(MSGWarnFileIsOpen);
                    this.ForceCloseTabPage();
                    return;
                }

                sqlText.Text = string.Empty;
                this.TabHeaderText = System.IO.Path.GetFileName(openFile.FileName);
                this.FilePath = openFile.FileName;
                IsEdited = false;
            }
        }

        private void buttonExecuteSQLClick(object sender, EventArgs e) {
            SqlEditorExecuteEventArgs ex = new SqlEditorExecuteEventArgs();
            ex.UniqueId = this.UniqueId;
            ex.SqlScript = sqlText.Text;
            int tmp = 0;
            int.TryParse(optionLimit.SelectedItem.ToString(), out tmp);
            ex.LimitPage = tmp;
            if (ExcuteSQL != null)
                ExcuteSQL(this, ex);
        }

        private void buttonVisibleLineNumClick(object sender, EventArgs e) {
            sqlText.ShowLineNumbers = sqlText.ShowLineNumbers ? false : true;
            buttonHideOrVisibleLinNumber.Text = sqlText.ShowLineNumbers ? LanguageApp.langSQLEditor["LBHideLineNum"] : LanguageApp.langSQLEditor["LBShowLineNum"];
        }

        private void buttonWarpClick(object sender, EventArgs e) {
            sqlText.WordWrap = sqlText.WordWrap ? false : true;
            buttonWarp.Text = sqlText.WordWrap ? LanguageApp.langSQLEditor["LBDisWordWarp"] : LanguageApp.langSQLEditor["LBEnWordWarp"];
        }

        private void buttonFindClick(object sender, EventArgs e) {
            FindForm f = new FindForm(sqlText);
            f.ShowDialog();
        }

        private void buttonFindAndReplaceClick(object sender, EventArgs e) {
            FastColoredTextBoxNS.ReplaceForm f = new ReplaceForm(sqlText);
            f.ShowDialog();
        }

        public event EventHandler<SqlEditorExecuteEventArgs> ExcuteSQL;
    }
}