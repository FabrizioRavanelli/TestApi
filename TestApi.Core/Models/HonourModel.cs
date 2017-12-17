using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Core.Models
{
    public class HonourModel
    {
        public int HounourId { get; set; }
        public string HonourName { get; set; }
        public string Season { get; set; }
        public string TypeOfHonour { get; set; }//cup, league....
        public string TeamName { get; set; }
    }
}
