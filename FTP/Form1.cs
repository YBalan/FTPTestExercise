using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP
{
    public partial class Form1 : Form
    {
        private FTPDownloader downloader = new FTPDownloader();
        private CancellationTokenSource Cancellation { get; set; }

        public Form1()
        {
            InitializeComponent();
            Cancellation = new CancellationTokenSource();

            ClearForm();
        }

        private void ClearForm()
        {
            m_EstimationLabel.ResetText();
            m_BytesLabel.ResetText();
            Text = "FTP";            
            m_ProgressBarControl.Value = 0;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
            if (downloader.IsStarted)
            {
                Cancellation.Cancel();
                m_DownloadButton.Enabled = true;
            }
            else
            {
                try
                {
                    var uri = new Uri(m_FtpUri.Text, UriKind.Absolute);
                    if (uri.Scheme == "ftp")
                    {                        
                        m_DownloadButton.Enabled = false;
                        var content = await Task.Run(() => downloader.Download(m_FtpUri.Text), Cancellation.Token);                        
                        m_DownloadButton.Enabled = true;
                        var fileDialog = new SaveFileDialog
                        {
                            FileName = uri.AbsolutePath
                        };
                        fileDialog.ShowDialog(this);

                        downloader.SaveToFile(fileDialog.FileName, content);                        
                    }
                    else
                    {
                        MessageBox.Show(this, "Invalid Ftp Uri", "Error");
                    }
                }
                catch (FormatException fe)
                {
                    MessageBox.Show(this, fe.Message, "Error");
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            m_FtpUri.Text = "ftp://speedtest.tele2.net/50MB.zip";
            downloader.FtpDownloadingProgress += (progress, estimate, bytesDownloaded, fileSize) =>
            {
                m_BytesLabel.Invoke(new Action(() => m_BytesLabel.Text = string.Format("{0} bytes downloaded from {1}", bytesDownloaded.ToString(), fileSize)));
                m_EstimationLabel.Invoke(new Action(() => m_EstimationLabel.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", estimate.Hours, estimate.Minutes, estimate.Seconds)));
                m_ProgressBarControl.Invoke(new Action(() => m_ProgressBarControl.Value = progress));
                Invoke(new Action(() => Text = string.Format("{0:0}%", progress)));
            };
        }
    }
}
