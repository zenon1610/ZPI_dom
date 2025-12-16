using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels.VM
{
    public class ProductVm
    {
        public string Description { get; set; } = default!; 
        public byte[] ImageBytes { get; set; } = default!; 
        public string Name { get; set; } = default!; 
        public decimal Price { get; set; } 
        public float Weight { get; set; } 
        public int Quantity { get; set; }
    }
}