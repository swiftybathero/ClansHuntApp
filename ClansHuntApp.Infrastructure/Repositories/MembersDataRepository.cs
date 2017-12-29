using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClansHuntApp.Core.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using ClansHuntApp.Infrastructure.Services;
using ClansHuntApp.Infrastructure.Repositories.RestModels;
using Newtonsoft.Json;

namespace ClansHuntApp.Infrastructure.Repositories
{
    public class MembersDataRepository : IMembersDataRepository
    {
        private HttpClient HttpClient;

        private const string BaseRepositoryAddress = "https://api.clashofclans.com/";
        private const string RequestUri = "v1/clans/%23P89V02CG/members";

        private MembersDataRepository() { }

        public MembersDataRepository(IConfigurationReader configurationReader) : base()
        {
            HttpClient = CreateHttpClient(configurationReader.ReadAPIKey());
        }

        private static HttpClient CreateHttpClient(string apiKey)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseRepositoryAddress);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            return client;
        }

        public IList<Member> GetAllMembers()
        {
            return GetRequestRootObject().Items.Select(x => new Member
            {
                Tag = x.Tag,
                Name = x.Name,
                Role = x.Role,
                ExpLevel = x.ExpLevel,
                Trophies = x.Trophies,
                VersusTrophies = x.VersusTrophies,
                Donations = x.Donations,
                DonationsReceived = x.DonationsReceived
            })
            .ToList<Member>();
        }

        public Member GetMemberByTag(string memberTag)
        {
            return GetAllMembers().Where(x => x.Tag == memberTag).FirstOrDefault();
        }

        private RootObject GetRequestRootObject()
        {
            var httpResponse = HttpClient.GetAsync(RequestUri).Result;
            httpResponse.EnsureSuccessStatusCode();

            var stringResult = httpResponse.Content.ReadAsStringAsync().Result;
            var rootObject = JsonConvert.DeserializeObject<RootObject>(stringResult);

            return rootObject;
        }

        public void Dispose()
        {
            HttpClient.Dispose();
        }
    }
}
