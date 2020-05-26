using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBotTelegram.Model
{
    class Api
    {
        public int results { get; set; }
        public TopScorers[] topscorers { get; set; }
    }
}
