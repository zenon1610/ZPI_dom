using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.DataModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Tag { get; set; } = default!;
        
        // Relacja 1:M z produktami
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}