using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRUCKCOY.classes
{
    class DriverPosition
    {
        private double lat_src;
        private double lng_src;
        private string deg_src;

        public double Lat_src { get => lat_src; set => lat_src = value; }
        public double Lng_src { get => lng_src; set => lng_src = value; }
        public string Deg_src { get => deg_src; set => deg_src = value; }
    }
}
