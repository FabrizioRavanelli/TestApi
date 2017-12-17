using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Core.Models
{
    public class LeagueModel
    {
        public int LeagueId { get; set; }

        public string LeagueName { get; set; }

        public int SortIndex { get; set; }

        public int CountryId { get; set; }

        public string Country { get; set; }

        public bool IsTopLeague { get; set; }
    }
}
