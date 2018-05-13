using System;
using System.Collections.Generic;
using System.Text;

namespace SwapiCL.Model
{
    public partial class BaseModel
    {
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }
}
