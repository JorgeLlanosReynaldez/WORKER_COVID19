using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace MODEL.MODEL
{
    [DelimitedRecord(",")]
    public class Report
    {
        public string Casos { get; set; }
        public string Macrodistrito { get; set; }
        public string Distrito { get; set; }
        public string Estado { get; set; }
        public string Zona { get; set; }
        public string Fuente { get; set; }
    }
}
