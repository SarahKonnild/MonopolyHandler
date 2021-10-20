using Monopoly.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json; 

namespace Monopoly.DataAccess
{
    class PropertiesDataAccess
    {
        string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Database\Properties.json");
        private PropertiesDataAccess() { 
        
        }

        public List<Property> InitializeProperties() {
            string json = File.ReadAllText(path);
            List<Property> properties = JsonSerializer.Deserialize<List<Property>>(json);

            return properties;
        }
    }
}
