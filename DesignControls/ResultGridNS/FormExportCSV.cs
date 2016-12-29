using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Threading;

namespace MySqlClientDotNET.DesignControls.ResultGridNS {
    public partial class FormExportCSV : Form {
        public FormExportCSV() {
            InitializeComponent();
            comboExportFrom.SelectedIndex = 0;
            comboSelectHead.SelectedIndex = 0;
            textPath.ReadOnly = true;
            IsLimit = false;
            bgCount = new BackgroundWorker();
            bgWriteData = new BackgroundWorker();
            _resetEvent =  new AutoResetEvent(false);
            language();
        }

        private void language() {
            this.Text = LanguageApp.langFormExportCSV["TFExportCSV"];

            comboSelectHead.Items.Clear();
            comboSelectHead.Items.AddRange(new[] {
                 LanguageApp.langFormExportCSV["CBHeaderCSV"],
                 LanguageApp.langFormExportCSV["CBNoHeaderCSV"]
            });
            comboSelectHead.SelectedIndex = 0;

            comboExportFrom.Items.Clear();
            comboExportFrom.Items.AddRange(new[]{
                LanguageApp.langFormExportCSV["CBExFromCurr"],
                LanguageApp.langFormExportCSV["CBExFromTb"]
            });
            comboExportFrom.SelectedIndex = 0;

            labelCount.Text = LanguageApp.langFormExportCSV["LBCount"];
            labelExportFrom.Text = LanguageApp.langFormExportCSV["LBExFrom"];
            labelPath.Text = LanguageApp.langFormExportCSV["LBPath"];

            buttonExport.Text = LanguageApp.langFormExportCSV["BTExport"];
            buttonCancel.Text = LanguageApp.langFormExportCSV["BTCancel"];
            buttonSave.Text = LanguageApp.langFormExportCSV["BTSave"];

            MSGWarnSelDir = LanguageApp.langFormExportCSV["MSGWarnSelDir"];
            MSGErrCount = LanguageApp.langFormExportCSV["MSGErrCount"];
            MSGErrWrite = LanguageApp.langFormExportCSV["MSGErrWrite"];
            MSGExportDB = LanguageApp.langFormExportCSV["MSGExportDB"];
            MSGConfrimCacel = LanguageApp.langFormExportCSV["MSGConfrimCacel"];
        }

        private string MSGWarnSelDir;
        private string MSGErrCount;
        private string MSGErrWrite;
        private string MSGExportDB;
        private string MSGConfrimCacel;

        public List<ResultGridColumnInfo> columnInfos { get; set; }
        public string SQL;
        public int SQLLimit;
        public int SQLPos;
        public bool IsLimit;
        private AutoResetEvent _resetEvent;
        private AutoResetEvent _resetEventCount;
        private BackgroundWorker bgCount;
        private BackgroundWorker bgWriteData;
        private string SQLExecute;

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

        private void buttonExport_Click(object sender, EventArgs e) {
            if (textPath.Text.Equals("")) {
                Msg.Warrn(MSGWarnSelDir);
            }

            if (comboExportFrom.SelectedIndex == 1)
                SQLExecute = SQL;
            else {
                if (IsLimit)
                    SQLExecute = SQL + "LIMIT " + SQLPos + ", " + SQLLimit;
                else
                    SQLExecute = SQL;
            }

            System.Diagnostics.Debug.WriteLine(SQLExecute);

            bgCount = new BackgroundWorker();
            bgCount.WorkerSupportsCancellation = true;
            _resetEventCount = new AutoResetEvent(false);
            bgCount.DoWork += new DoWorkEventHandler(bgCount_DoWork);
            bgCount.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgCount_RunWorkerCompleted);
            bgCount.RunWorkerAsync(comboSelectHead.SelectedIndex);
            labelCount.Visible = true;
        }

        #region count
        void bgCount_DoWork(object sender, DoWorkEventArgs e) {
            int selIndex = (int)e.Argument;
            MySqlCommand cmmd;
            MySqlDataReader dr = null;
            int cnt = 0;
            if (selIndex == 1)
                ++cnt;
            try {
                using (cmmd = new MySqlCommand(SQLExecute, AppConnection.Connection)) {
                    using (dr = cmmd.ExecuteReader()) {
                        while (dr.Read()) {
                            if (bgCount.CancellationPending) {
                                e.Cancel = true;
                                break;
                            }
                            ++cnt;
                        }
                    }
                }
            } catch (MySqlException ex) {
                _resetEventCount.Set();
                throw ex;
            }
            e.Result = cnt;
            _resetEventCount.Set();
        }

        void bgCount_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            labelCount.Visible = false;
            if (e.Error != null) {
                Msg.Err(MSGErrCount + e.Error.Message);
                this.Close();
                return;
            }
            if (e.Cancelled) {
                _resetEventCount.WaitOne();
                this.Close();
                return;
            }

            progressBar1.Visible = true;
            progressBar1.Maximum = (int)e.Result;
            bgWriteData = new BackgroundWorker();
            bgWriteData.WorkerSupportsCancellation = true;
            bgWriteData.WorkerReportsProgress = true;

            bgWriteData.DoWork += new DoWorkEventHandler(bgWriteData_DoWork);
            bgWriteData.ProgressChanged += new ProgressChangedEventHandler(bgWriteData_ProgressChanged);
            bgWriteData.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWriteData_RunWorkerCompleted);
            bgWriteData.RunWorkerAsync(comboSelectHead.SelectedIndex);
            _resetEvent = new AutoResetEvent(false);
        }
        #endregion

        #region Write Data
        void bgWriteData_DoWork(object sender, DoWorkEventArgs e) {
            int selIndex = (int)e.Argument;
            MySqlCommand cmmd;
            MySqlDataReader dr = null;
            StringBuilder res = new StringBuilder("");
            int cnt = 0;
            if (selIndex == 1) {
                for (int i = 0; i < columnInfos.Count; ++i) {
                    if (i != 0)
                        res.Append(",");
                    if (columnInfos[i].ColumnName.Contains(','))
                        res.Append("\"").Append(columnInfos[i].ColumnName).Append("\"");
                    else
                        res.Append(columnInfos[i].ColumnName);
                }
                res.Append("\n");
                bgWriteData.ReportProgress(++cnt);
            }
            try {
                using (cmmd = new MySqlCommand(SQLExecute, AppConnection.Connection)) {
                    using (dr = cmmd.ExecuteReader()) {
                        string tmpStr = string.Empty;
                        while (dr.Read()) {
                            if (bgWriteData.CancellationPending) {
                                e.Cancel = true;
                                break;
                            }
                            for (int i = 0; i < dr.FieldCount; ++i) {
                                if (i != 0)
                                    res.Append(",");
                                if (!dr.IsDBNull(i)) {
                                    switch (dr.GetDbType(i)) {
                                        case MySqlDbType.VarBinary :
                                        case MySqlDbType.Binary :
                                            tmpStr = Encoding.UTF8.GetString((byte[])dr[i]);
                                            tmpStr = tmpStr.Replace("\"", "\"\"");
                                            break;
                                        case MySqlDbType.TinyBlob :
                                        case MySqlDbType.Blob :
                                        case MySqlDbType.MediumBlob :
                                        case MySqlDbType.LongBlob :
                                            Byte[] ba = (Byte[])dr[i];
                                            StringBuilder hex = new StringBuilder((ba.Length * 2) + 2);
                                            hex.Append("0x");
                                            foreach (byte b in ba)
                                                hex.AppendFormat("{0:x2}".ToUpper(), b);
                                            tmpStr = hex.ToString();
                                            break;
                                        case MySqlDbType.DateTime :
                                        case MySqlDbType.Timestamp :
                                            try {
                                                var valueDate = (DateTime)dr[i];
                                                tmpStr = valueDate.ToString(MySqlConfig.MySqlDateTimeToDotNetDateTime());
                                            } catch { tmpStr = ""; }
                                            break;
                                        case MySqlDbType.Date :
                                            try {
                                                var valueDate = (DateTime)dr[i];
                                                tmpStr = valueDate.ToString(MySqlConfig.MySqlDateToDotNetDate());
                                            } catch { tmpStr = ""; }
                                            break;
                                        case MySqlDbType.Time :
                                            try {
                                                var valueTime = (TimeSpan)dr[i];
                                                tmpStr = valueTime.ToString(MySqlConfig.MySqlTimeToDotNetTime());
                                            } catch { tmpStr = ""; }
                                            break;
                                        default :
                                            tmpStr = dr[i].ToString().Replace("\"", "\"\"");
                                            break;
                                    }
                                    if (tmpStr.Contains(","))
                                        res.Append("\"").Append(tmpStr).Append("\"");
                                    else
                                        res.Append(tmpStr);
                                } else
                                    res.Append("NULL");
                                
                            }
                            res.Append("\n");
                            bgWriteData.ReportProgress(++cnt);
                        }
                    }
                }
            } catch (MySqlException ex) {
                _resetEvent.Set();
                throw ex;
            }
            try {
                using (StreamWriter streamW = new StreamWriter(textPath.Text,
                                                               false,
                                                               Encoding.ASCII,
                                                               FileIO.FileInfo.GetBuffSize(Encoding.ASCII))) {
                    streamW.Write(res.ToString());
                }
            } catch (Exception ex) {
                _resetEvent.Set();
                throw ex;
            }
            _resetEvent.Set();
        }

        void bgWriteData_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            progressBar1.Value = e.ProgressPercentage;
            if (progressBar1.Value == progressBar1.Maximum)
                buttonCancel.Enabled = false;
        }

        void bgWriteData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null) {
                Msg.Err(MSGErrWrite + e.Error.Message);
                this.Close();
                return;
            }
            if (e.Cancelled) {
                return;
            }
            Msg.Info("Export completed");
            this.Close();
        }
        #endregion

        private void buttonSave_Click(object sender, EventArgs e) {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = FileIO.FileInfo.GetCSVFileExtension;
            saveFile.Title = MSGExportDB;
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                textPath.Text = saveFile.FileName;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            if (bgCount.IsBusy) {
                DialogResult dResult = Msg.WarrnQ(MSGConfrimCacel);
                if (dResult == System.Windows.Forms.DialogResult.No)
                    return;
                bgCount.CancelAsync();
                _resetEventCount.WaitOne();
            }
            if (bgWriteData.IsBusy) {
                DialogResult dResult = Msg.WarrnQ(MSGConfrimCacel);
                if (dResult == System.Windows.Forms.DialogResult.No) 
                    return;
                bgWriteData.CancelAsync();
                _resetEvent.WaitOne();
                    
            }
            this.Close();
        }
    }
}
