using MonopolyHandler.Data_Access.Interfaces;
using MonopolyHandler.Data_Access.Query;
using MonopolyHandler.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyHandler.Command
{
    class PropertyCommand
    {
        private readonly IPropertyQueries propertyQueries;
        public List<Property> properties;
        public PropertyCommand() {
            propertyQueries = new PropertyQueries();
        }

        public async void LoadProperties() {
            properties = await propertyQueries.LoadProperties();
        }

        public async void SellProperty(Property property) {
            properties.Remove(property);
        }

        public async void AddProperty(Property property) {
            properties.Add(property);
        }
    }
}
