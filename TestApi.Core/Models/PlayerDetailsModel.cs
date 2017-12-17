using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Core.Models
{
    public class PlayerDetailsModel
    {
        public string FullName { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Nationality { get; set; }
        public decimal Height { get; set; }
        public string Position { get; set; }
        public string CurrentTeam { get; set; }
        public int CurrentNumber { get; set; }
        public List<HonourModel> Honours { get; set; }
        public string Description { get; set; }
    }
}
