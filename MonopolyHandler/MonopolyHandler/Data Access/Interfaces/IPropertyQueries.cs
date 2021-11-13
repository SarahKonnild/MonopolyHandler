using MonopolyHandler.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyHandler.Data_Access.Interfaces
{
    interface IPropertyQueries
    {
        public Task<List<Property>> LoadProperties();
    }
}
