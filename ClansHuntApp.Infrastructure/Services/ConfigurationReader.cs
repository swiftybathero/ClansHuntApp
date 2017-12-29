using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClansHuntApp.Infrastructure.Services
{
    public class ConfigurationReader : IConfigurationReader
    {
        public string ReadAPIKey()
        {
            return ConfigurationManager.AppSettings["APIKey"];
        }
    }
}
