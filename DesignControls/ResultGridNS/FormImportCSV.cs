using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using MySql.Data.MySqlClient;
using System.Threading;

namespace MySqlClientDotNET.DesignControls.ResultGridNS {
    public partial class FormImportCSV : Form {
        public FormImportCSV() {
            InitializeComponent();
            isAborted = true;
            _resetEvent = new AutoResetEvent(false);
            language();
        }

        private void language() {
            this.Text = LanguageApp.langFormImportCSV["FTImportCSV"];

            labelCSVFile.Text = LanguageApp.langFormImportCSV["LBCSVFile"];
            labelStaus.Text = LanguageApp.langFormImportCSV["LBStatus"];

            checkContinHeader.Text = LanguageApp.langFormImportCSV["CBContainHeader"];

            buttonOpen.Text = LanguageApp.langFormImportCSV["BTOpen"];
            buttonApply.Text = LanguageApp.langFormImportCSV["BTImport"];
            buttonDiscard.Text = LanguageApp.langFormImportCSV["BTCancel"];

            MSGWarnOpenFile = LanguageApp.langFormImportCSV["MSGWarnOpenFile"];
            MSGLinseIsEmpety = LanguageApp.langFormImportCSV["MSGLinseIsEmpety"];
            MSGFieldIsEmpety = LanguageApp.langFormImportCSV["MSGFieldIsEmpety"];
            MSGErrRead = LanguageApp.langFormImportCSV["MSGErrRead"];
            MSGWarnNumField = LanguageApp.langFormImportCSV["MSGWarnNumField"];
            MSGImportSucc = LanguageApp.langFormImportCSV["MSGImportSucc"];
            MSGConfrimCancel = LanguageApp.langFormImportCSV["MSGConfrimCancel"];
        }

        private string MSGWarnOpenFile;
        private string MSGLinseIsEmpety;
        private string MSGFieldIsEmpety;
        private string MSGErrRead;
        private string MSGWarnNumField;
        private string MSGImportSucc;
        private string MSGConfrimCancel;

        #region diable close button
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams {
            get {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        #endregion

        private BackgroundWorker processExecute;
        private BackgroundWorker countProc;
        private AutoResetEvent _resetEvent;
        private List<ResultGridColumnInfo> columnInfos;

        public List<ResultGridColumnInfo> ColumnInfos { 
            get { 
                return columnInfos; 
            } 
            set {
                columnInfos = value;
                ColMode = new List<string>();
                for (int i = 0; i < columnInfos.Count; ++i) {
                    switch (columnInfos[i].DbType) {
                        case MySqlDbType.TinyText:
                        case MySqlDbType.Text:
                        case MySqlDbType.MediumText:
                        case MySqlDbType.LongText:
                        case MySqlDbType.VarChar:
                        case MySqlDbType.VarBinary:
                        case MySqlDbType.Binary:
                        case MySqlDbType.Date:
                        case MySqlDbType.DateTime:
                        case MySqlDbType.Timestamp:
                        case MySqlDbType.Time:
                        case MySqlDbType.Year:
                            ColMode.Add("'");
                            break;
                        default :
                            ColMode.Add("");
                            break;

                    }
                }
            } 
        }
        private List<string> ColMode;

        public string DatabaseAndTableName { get; set; }

        private bool isAborted;
        public bool IsAborted {
            get {
                return isAborted;
            }
        }

        public bool isContainHeaderField {
            get {
                return checkContinHeader.Checked;
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e) {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = FileIO.FileInfo.GetCSVFileExtension;
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                textPath.Text = openFile.FileName;
            }
            
        }

        private void buttonApply_Click(object sender, EventArgs e) {
            if (textPath.Text.Equals(string.Empty)) {
                Msg.Warrn(MSGWarnOpenFile);
                return;
            }
            labelStaus.Visible = true;
            countProc = new BackgroundWorker();
            countProc.WorkerSupportsCancellation = true;
            countProc.DoWork += new DoWorkEventHandler(countProc_DoWork);
            countProc.RunWorkerCompleted += new RunWorkerCompletedEventHandler(countProc_RunWorkerCompleted);
            countProc.RunWorkerAsync();
        }

        void countProc_DoWork(object sender, DoWorkEventArgs e) {
            int csvField = 0;
            ulong csvLine = 0;
            bool firstLine = true;
            try {
                using (TextFieldParser csv = new TextFieldParser(textPath.Text)) {
                    csv.TextFieldType = FieldType.Delimited;
                    csv.SetDelimiters(",");
                    while (!csv.EndOfData) {
                        if (countProc.CancellationPending) {
                            e.Cancel = true;
                            break;
                        }
                        string[] fields = csv.ReadFields();
                        foreach (string field in fields) {
                            if (firstLine)
                                ++csvField;
                        }
                        ++csvLine;
                        if (firstLine)
                            firstLine = false;
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }

            if (csvLine == 0)
                throw new Exception(MSGLinseIsEmpety);
            if (csvField == 0)
                throw new Exception(MSGFieldIsEmpety);

            object[] result = { csvField, csvLine };
            e.Result = result;
        }

        void countProc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            labelStaus.Visible = false;
            if (e.Error != null) {
                Msg.Err(MSGErrRead + e.Error.Message);
            } else {
                int field = (int)((object[])e.Result)[0];
                ulong line = (ulong)((object[])e.Result)[1];

                if (field != ColumnInfos.Count) {
                    Msg.Warrn(MSGWarnNumField);
                    isAborted = true;
                    return;
                }
                if (line < (ulong)2147483) {
                    progressBar.Visible = true;
                    progressBar.Maximum = (int)line;
                }
                buttonApply.Enabled = false;
                processExecute = new BackgroundWorker();
                processExecute.WorkerSupportsCancellation = true;
                processExecute.WorkerReportsProgress = true;
                processExecute.DoWork += new DoWorkEventHandler(processExecute_DoWork);
                processExecute.ProgressChanged += new ProgressChangedEventHandler(processExecute_ProgressChanged);
                processExecute.RunWorkerCompleted += new RunWorkerCompletedEventHandler(processExecute_RunWorkerCompleted);
                processExecute.RunWorkerAsync(new TextFieldParser(textPath.Text));
            }
        }

        void processExecute_DoWork(object sender, DoWorkEventArgs e) {
            StringBuilder sql = new StringBuilder("");
            MySqlCommand cmmd;
            int count = 0;
            try {
                using (TextFieldParser csv = (TextFieldParser)e.Argument) {
                    csv.TextFieldType = FieldType.Delimited;
                    csv.SetDelimiters(",");
                    bool header = isContainHeaderField;
                    while (!csv.EndOfData) {
                        if (header) {
                            header = false;
                            processExecute.ReportProgress(++count);
                            continue;
                        }
                        if (e.Cancel) {
                            break;
                        }
                        string[] fields = csv.ReadFields();
                        sql.Append("INSERT INTO `").Append(DatabaseAndTableName).Append("`(");
                        for (int i = 0; i < ColumnInfos.Count; ++i) {
                            if (i == 0)
                                sql.Append(ColumnInfos[i].ColumnName);
                            else
                                sql.Append(",").Append(ColumnInfos[i].ColumnName);
                        }
                        sql.Append(") VALUES(");
                        for (int i = 0; i < fields.Length; ++i) {
                            if (i == 0)
                                sql.Append(ColMode[i]).Append(fields[i]).Append(ColMode[i]);
                            else
                                sql.Append(",").Append(ColMode[i]).Append(fields[i]).Append(ColMode[i]);
                        }
                        sql.Append(");\n");
                        try {
                            using (cmmd = new MySqlCommand(sql.ToString(), AppConnection.Connection)) {
                                cmmd.ExecuteNonQuery();
                            }
                        } catch (MySqlException myEx) {
                            throw new Exception(myEx.Message);
                        }
                        sql.Clear();
                        sql.Append("");
                        processExecute.ReportProgress(++count);
                    }
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        void processExecute_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (progressBar.Visible)
                progressBar.Value = e.ProgressPercentage;
        }

        void processExecute_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null) {
                Msg.Err("Error : " + e.Error.Message);
                isAborted = true;
            } else {
                Msg.Succ(MSGImportSucc);
                isAborted = false;
                this.Close();
            }
            buttonApply.Enabled = true;
            progressBar.Visible = false;
        }

        private void buttonDiscard_Click(object sender, EventArgs e) {
            isAborted = true;
            DialogResult dResult;
            if (countProc != null) {
                if (countProc.IsBusy) 
                    return;
            }

            if (processExecute != null) {
                if (processExecute.IsBusy) {
                    dResult = Msg.WarrnQ(MSGConfrimCancel);
                    if (dResult == System.Windows.Forms.DialogResult.Yes) {
                        processExecute.CancelAsync();
                        _resetEvent.WaitOne();
                    } else
                        return;
                }
                processExecute.Dispose();
            }
            isAborted = true;
            this.Close();
        }

    }
}
