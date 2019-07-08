using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FTP
{
    public sealed class FTPDownloader
    {
        public delegate void ProgressDelegate(int progress, TimeSpan estimateTimeLeft, long bytesDownloaded, long fileSize);
        public event ProgressDelegate FtpDownloadingProgress;
        public event EventHandler<long> FtpDownloadingFileSize;
        public bool IsStarted { get; private set; }

        public async void SaveToFile(string path, IEnumerable<byte> content)
        {
            await Task.Run(() => File.WriteAllBytes(path, content.ToArray()));
        }

        public IEnumerable<byte> Download(string ftpLink)
        {
            if (string.IsNullOrWhiteSpace(ftpLink)) throw new ArgumentNullException(nameof(ftpLink));

            IsStarted = true;

            var credentials = new NetworkCredential("anonymous", "");

            var sizeRequest = WebRequest.Create(ftpLink);

            sizeRequest.Credentials = credentials;
            sizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
            var fileSize = sizeRequest.GetResponse().ContentLength;

            FtpDownloadingFileSize?.Invoke(this, fileSize);


            var request = (FtpWebRequest)WebRequest.Create(ftpLink);

            request.KeepAlive = true;
            request.UsePassive = true;
            request.UseBinary = true;

            request.Method = WebRequestMethods.Ftp.DownloadFile;

            request.Credentials = credentials;

            using (var responseStream = request.GetResponse().GetResponseStream())
            {
                var buffer = new byte[4096];
                var read = 0;
                long bytesReceived = 0;

                var stopwatch = new Stopwatch();

                stopwatch.Start();                
                var timeToDownload = TimeSpan.FromSeconds(0);

                while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bytesReceived += read;

                    long seconds = stopwatch.ElapsedMilliseconds / 1000;
                    if (seconds > 0)
                    {
                        double currentSpeed = bytesReceived / seconds;
                        if (currentSpeed > 0)
                            timeToDownload = TimeSpan.FromSeconds((fileSize - bytesReceived) / Math.Round(currentSpeed, 2));
                    }


                    var progress = (bytesReceived / (double)fileSize) * 100.0;

                    FtpDownloadingProgress?.Invoke((int)progress, timeToDownload, bytesReceived, fileSize);

                    for (int i = 0; i < read; i++)
                    {
                        yield return buffer[i];
                    }
                }
            }
            IsStarted = false;
        }
    }
}
