using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MySqlClientDotNET.FileIO {
    public class ReadFromText {

        public ReadFromText() {
            TextPath = "";
            ThreadReadingText = new BackgroundWorker();
            ThreadReadingText.WorkerSupportsCancellation = true;
            ThreadReadingText.DoWork += new System.ComponentModel.DoWorkEventHandler(ThreadReadingText_DoWork);
        }

        private const Int32 bufferSize = 128;

        public string TextPath { get; set; }
        public BackgroundWorker ThreadReadingText { get; set; }
        public bool ReportReadingTextProgress {
            get {
                return ThreadReadingText.WorkerReportsProgress;
            }
            set {
                ThreadReadingText.WorkerReportsProgress = value;
            }
        }

        public bool IsProgress() {
            return ThreadReadingText.IsBusy;
        }

        public void CancelRead() {
            ThreadReadingText.CancelAsync();
        }

        private void ThreadReadingText_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            StringBuilder strBulider = new StringBuilder("");
            using (System.IO.FileStream fileStream = System.IO.File.Open(TextPath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)) {
                using (System.IO.BufferedStream bufferStream = new System.IO.BufferedStream(fileStream)) {
                    using (System.IO.StreamReader srFile = new System.IO.StreamReader(bufferStream)) {
                        string lines;
                        int i = 0;
                        while ((lines = srFile.ReadLine()) != null) {
                            if (ThreadReadingText.CancellationPending) {
                                e.Cancel = true;
                                return;
                            }
                            if (ReportReadingTextProgress)
                                ThreadReadingText.ReportProgress(++i);
                            strBulider.AppendLine(lines);
                        }
                    }
                }
            }
            e.Result = strBulider;
        }

        public void Dispose() {
            ThreadReadingText.Dispose();
        }

        public void StartReading() {
            ThreadReadingText.RunWorkerAsync();
        }
    }
}
