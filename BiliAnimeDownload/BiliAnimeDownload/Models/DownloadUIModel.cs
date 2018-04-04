using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliAnimeDownload.Models
{
    public class DownloadUIModel
    {
        public string title { get; set; }
        public string url { get; set; }
        public string status { get; set; }
        public string progress { get; set; }
    }
}
