using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClansHuntApp.Infrastructure.Services
{
    public interface IMembersDataActivityService
    {
        bool LoadMembersData();
        bool SaveMembersData();
        string ValidationMessage { get; }
    }
}
