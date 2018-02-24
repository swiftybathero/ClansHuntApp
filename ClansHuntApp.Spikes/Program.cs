using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClansHuntApp.Core;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ClansHuntApp.Spikes
{
    static class Program
    {
        static void Main(string[] args)
        {
            GetClanMembers();
            Console.ReadKey();
        }

        private static void GetClanMembers()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://api.clashofclans.com/");
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6IjZlMjZhMjVmLTJiNjEtNGZmNi1hYjc5LTE1ZTJjMGQyYWQyNiIsImlhdCI6MTUxNDQxNTU1MSwic3ViIjoiZGV2ZWxvcGVyL2JmMzM3YjFkLWY4NDQtYjAyYy0zYTMyLTA4ZjUxYjY0ODdjOSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjgwLjIzOC4xMjEuMTY3Il0sInR5cGUiOiJjbGllbnQifV19.92RFmCGMXuo1-lfEgoo0sfuK9Wey-tU_dZ3CqvqvzczrsUsgMPRocU9Wau9jEywDCKNWJBfz_XKwQPAh60p9Dg");

                var result = httpClient.GetAsync("v1/clans/%23P89V02CG/members").Result;

                try
                {
                    result.EnsureSuccessStatusCode();
                    var stringResult = result.Content.ReadAsStringAsync().Result;
                    var rootObject = JsonConvert.DeserializeObject<Rootobject>(stringResult);

                    foreach (var clanMember in rootObject.Items)
                    {
                        Console.WriteLine($"{clanMember.Name}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format($"ERROR: {ex.Message}"));
                }
            }
        }
    }

    public class Rootobject
    {
        public Item[] Items { get; set; }
        public Paging Paging { get; set; }
    }

    public class Paging
    {
        public Cursors Cursors { get; set; }
    }

    public class Cursors
    {
    }

    public class Item
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int ExpLevel { get; set; }
        public League League { get; set; }
        public int Trophies { get; set; }
        public int VersusTrophies { get; set; }
        public int ClanRank { get; set; }
        public int PreviousClanRank { get; set; }
        public int Donations { get; set; }
        public int DonationsReceived { get; set; }
    }

    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Iconurls IconUrls { get; set; }
    }

    public class Iconurls
    {
        public string Small { get; set; }
        public string Tiny { get; set; }
        public string Medium { get; set; }
    }

}
