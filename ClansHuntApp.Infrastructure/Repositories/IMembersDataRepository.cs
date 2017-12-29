using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClansHuntApp.Core.Models;

namespace ClansHuntApp.Infrastructure.Repositories
{
    public interface IMembersDataRepository : IDisposable
    {
        IList<Member> GetAllMembers();
        Member GetMemberByTag(string memberTag);
    }
}
