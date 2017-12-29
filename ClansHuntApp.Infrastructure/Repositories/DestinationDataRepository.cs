using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClansHuntApp.Core.Models;
using ClansHuntApp.Infrastructure.EF;

namespace ClansHuntApp.Infrastructure.Repositories
{
    public class DestinationDataRepository : IDestinationDataRepository
    {
        private ClansHuntAppDBContext Context;

        public DestinationDataRepository()
        {
            Context = new ClansHuntAppDBContext();
        }

        public void SaveAllMembersData(IList<Member> membersList)
        {
            foreach (var member in membersList)
            {
                MemberEntity memberEntity = Context.Member.FirstOrDefault(x => x.Tag == member.Tag);
                if (memberEntity == null)
                {
                    memberEntity = Context.Member.Add(new MemberEntity
                    {
                        Tag = member.Tag,
                        Name = member.Name
                    });
                    Context.SaveChanges();
                }

                Context.MemberStatus.Add(new MemberStatusEntity
                {
                    MemberID = memberEntity.ID,
                    DonationsGiven = member.Donations,
                    DonationsReceived = member.DonationsReceived,
                    StatusDate = DateTime.Now
                });
                Context.SaveChanges();
            }
        }

        public void SaveMemberData(Member member)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
