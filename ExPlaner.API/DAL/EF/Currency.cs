using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExPlaner.API.DAL.EF
{
    public class Currency : IEntity
    {
        public Guid Id { get; set; }
        public string CurrencyCode { get; set; }
    }
}
