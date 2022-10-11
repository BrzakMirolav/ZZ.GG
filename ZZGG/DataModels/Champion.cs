using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Champion
    {
        public string Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public ChampionImage Image { get; set; }
    }


    public class ChampionImage
    {
        public string Full { get; set; }
    }
}
