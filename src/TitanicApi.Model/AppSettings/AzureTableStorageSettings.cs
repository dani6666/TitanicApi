using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanicApi.Core.AppSettings
{
    public class AzureTableStorageSettings
    {
        public string Uri { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public Dictionary<string, string> TableNames { get; set; }
    }
}
