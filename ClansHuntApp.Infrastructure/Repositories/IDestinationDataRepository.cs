using ClansHuntApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClansHuntApp.Infrastructure.Repositories
{
    public interface IDestinationDataRepository : IDisposable
    {
        void SaveAllMembersData(IList<Member> membersList);
        void SaveMemberData(Member member);
    }
}
