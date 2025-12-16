using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.DataModels
{
    public class StationaryStore
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        
        // Relacja 1:M z pracownikami
        public IList<Address> Addresses { get; set; } = new List<Address>();
        public IList<StationaryStoreEmployee> Employees { get; set; } = new List<StationaryStoreEmployee>();
    }
}