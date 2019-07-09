using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTP
{
    public delegate void ProgressDelegate(int progress, TimeSpan estimateTimeLeft, long bytesDownloaded, long fileSize);

    public interface IDownloader
    {                
        event ProgressDelegate DownloadingProgress;
        event EventHandler<long> DownloadingFileSize;
        bool IsStarted { get; }

        void SaveToFile(string path, IEnumerable<byte> content);
        IEnumerable<byte> Download(string uri);
    }
}
