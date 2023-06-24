using ControlBox.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlBox.Models
{
    public class DtGiros
    {
        public int Giro_id { get; set; }
        public int Ciudad_id { get; set; }
        public string Recibo { get; set; }
    }
}