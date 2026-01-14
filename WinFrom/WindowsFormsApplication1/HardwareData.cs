using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class HardwareData
    {
        public DateTime Datetime { get; set; }
        public double Light { get; set; }
        public double Distance { get; set; }
        public double Water { get; set; }
        public string RFID { get; set; }
        public double Temperature { get; set; }
        public bool LED_Red { get; set; }
        public bool LED_Green { get; set; }
    }
}
