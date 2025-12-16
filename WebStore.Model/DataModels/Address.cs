using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.DataModels
{
    public class Address
    {
         public int Id { get; set; }
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string Country { get; set; } = default!;

        public int CustomerId { get; set; }  
        public Customer Customer { get; set; } = default!;    
        
    }
}