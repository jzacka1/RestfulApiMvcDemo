using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Models
{
    public class Repos
    {
        public string name { get; set; }
        public string description { get; set; }
        public string html_url { get; set; }
    }
}
