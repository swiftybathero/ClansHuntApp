using ClansHuntApp.Core.Models;
using ClansHuntApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClansHuntApp.Infrastructure.Services
{
    public class MembersDataActivityService : IMembersDataActivityService
    {
        private Func<IMembersDataRepository> MembersRepositoryFactory;
        private Func<IDestinationDataRepository> DestinationRepositoryFactory;
        public List<Member> MembersList { get; set; }

        private string _validationMessage;
        public string ValidationMessage { get => _validationMessage; }

        public MembersDataActivityService(Func<IMembersDataRepository> membersRepositoryFactory, Func<IDestinationDataRepository> destinationRepositoryFactory)
        {
            MembersRepositoryFactory = membersRepositoryFactory;
            DestinationRepositoryFactory = destinationRepositoryFactory;
        }

        public bool LoadMembersData()
        {
            bool result = true;
            try
            {
                using (var membersRepository = MembersRepositoryFactory())
                {
                    MembersList = membersRepository.GetAllMembers().ToList();
                }
            }
            catch (Exception ex)
            {
                result = false;
                _validationMessage = ex.ToString();
            }
            return result;
        }

        public bool SaveMembersData()
        {
            bool result = true;
            try
            {
                using (var destinationRepository = DestinationRepositoryFactory())
                {
                    if (MembersList == null)
                    {
                        throw new NullReferenceException("MemberList collection is not initialized!");
                    }
                    destinationRepository.SaveAllMembersData(MembersList);
                }
            }
            catch (Exception ex)
            {
                result = false;
                _validationMessage = ex.ToString();
            }
            return result;
        }
    }
}
