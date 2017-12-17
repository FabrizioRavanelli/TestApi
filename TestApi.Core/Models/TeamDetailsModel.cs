using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Core.Models
{
    public class TeamDetailsModel
    {
        public string TeamId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public List<string> Nicknames { get; set; }
        public string Country { get; set; }
        public DateTime Foundation { get; set; }
        public List<PlayerTeamModel> Players { get; set; }
        public string Coach { get; set; }
        public string President { get; set; }
        public string League { get; set; }
        public string Stadium { get; set; }
        public string Website { get; set; }
        public List<HonourModel> Honours { get; set; }
        public string Description { get; set; }
    }
}
