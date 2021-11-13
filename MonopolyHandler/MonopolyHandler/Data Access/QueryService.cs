using MonopolyHandler.Data_Access.Interfaces;
using MonopolyHandler.Data_Access.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyHandler.Data_Access
{
    class QueryService
    {
        private readonly IPropertyQueries propertyQueries;
        public QueryService(PropertyQueries propertyQueries)
        {
            this.propertyQueries = propertyQueries;
        }
    }
}
