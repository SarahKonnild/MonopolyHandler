using MonopolyHandler.Data_Access.Interfaces;
using MonopolyHandler.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyHandler.Data_Access.Query
{
    class PropertyQueries : IPropertyQueries
    {
        public PropertyQueries() { 
            //Connection to database
        }

        public async Task<List<Property>> LoadProperties() {
            List<Property> properties = new List<Property>();

            //FIXME should really take the file from current dir.
            using (var reader = new StreamReader(@"C:\Users\S_Pra\Documents\GitHub\Monopoly\MonopolyHandler\MonopolyHandler\Data Access\Query\Properties.csv")) {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    var values = line.Split(',');

                    Property property = new Property(values[0], values[1], int.Parse(values[2]), int.Parse(values[3]), int.Parse(values[4]));
                    properties.Add(property);
                }
            }
            return properties;
        }
    }
}
