using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Models
{
    public class ImagesGitHub
    {
        public string name { get; set; }
        public string path { get; set; }
        public string sha { get; set; }
        public string download_url { get; set; }
    }
}
