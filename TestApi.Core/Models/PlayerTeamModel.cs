using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Core.Models
{
    public class PlayerTeamModel
    {
        public int Number { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public bool IsCaptain { get; set; }
    }
}
