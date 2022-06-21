using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    public class ResponseOrder
    {
        public string actorname { get; set; }
        public string taskname { get; set; }
        public string stepname { get; set; }
        public List<Parameter> parameters { get; set; }
    }

    public class Parameter
    {
        public string name { get; set; }
        public decimal value { get; set; }
    }
}
