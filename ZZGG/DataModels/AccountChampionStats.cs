using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AccountChampionStats
    {
        public int ChampionId { get; set; }
        public int ChampionLevel { get; set; }
        public Int64 ChampionPoints { get; set; }
        public Int64 LastPlayTime { get; set; }
        public Int64 ChampionPointsSinceLastLevel { get; set; }
        public int ChampionPointsUntilNextLevel { get; set; }
        public bool ChestGranted { get; set; }
        public int TokensEarned { get; set; }
        public string SummonerId { get; set; }

    }
}
