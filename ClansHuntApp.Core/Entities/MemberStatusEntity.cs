using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClansHuntApp.Core.Entities
{
    public class MemberStatusEntity
    {
        public int MemberID { get; set; }
        public int DonationsGiven { get; set; }
        public int DonationsReceived { get; set; }
        public DateTime StatusDate { get; set; }
    }
}
