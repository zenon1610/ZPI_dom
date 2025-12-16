using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.DataModels
{
    public class StationaryStoreEmployee:User
    {
        public string EmployeeNumber { get; set; } = default!;
        public string Position { get; set; } = default!;
        public DateTime HireDate { get; set; }
        
        // Klucz obcy do StationaryStore
        public int StationaryStoreId { get; set; }
        public StationaryStore StationaryStore { get; set; } = default!;
    }
}