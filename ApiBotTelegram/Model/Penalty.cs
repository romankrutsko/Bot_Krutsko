using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBotTelegram.Model
{
    class Penalty
    {
        public int? won { get; set; }
        public int? commited { get; set; }
        public int sucsess { get; set; }
        public int missed { get; set; }
        public int? saved { get; set; }
    }
}
