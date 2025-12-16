using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.DataModels
{
    public class Supplier:User
    {
         // Relacja 1:M - jeden dostawca wiele produktów
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}