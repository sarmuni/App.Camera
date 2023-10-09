using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APP.Camera.Domain
{
    public class ResultApi
    {
    }
    public class ResultCapture
    {
        public bool success { get; set; }
        public Int32 code { get; set; }
        public String message { get; set; }
    }

    public class JsonCapture
    {
        public String foto { get; set; }
        public String userid { get; set; }
        public String dirname { get; set; }
    }

}
