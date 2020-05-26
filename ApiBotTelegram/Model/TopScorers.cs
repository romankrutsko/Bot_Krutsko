using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBotTelegram.Model
{
    class TopScorers
    {
        public int player_id { get; set; }
        public string player_name { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string position { get; set; }
        public string nationality { get; set; }
        public int team_id { get; set; }
        public string team_name { get; set; }
        public Games games { get; set; }
        public Goals goals { get; set; }
        public Shots shots { get; set; }
        public Penalty penalty { get; set; }
        public Cards cards { get; set; }
    }
}
