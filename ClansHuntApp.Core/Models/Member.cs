using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClansHuntApp.Core.Models
{
    public class Member
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int ExpLevel { get; set; }
        public int Trophies { get; set; }
        public int VersusTrophies { get; set; }
        public int Donations { get; set; }
        public int DonationsReceived { get; set; }
    }
}
