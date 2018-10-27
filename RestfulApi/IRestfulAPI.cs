using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi
{
    public interface IRestfulAPI
    {
        string baseURL { get; set; }
        string widget { get; set; }
    }
}
