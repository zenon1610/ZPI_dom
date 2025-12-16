using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.DataModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        
        public byte[] ImageBytes { get; set; } = default!;
        public decimal Price { get; set; }
        public float Weight { get; set; }

         // Klucz obcy do Category - product należy do jednej kategorii
        public int CategoryId { get; set; } = default!;
        public Category Category { get; set; } = default!;
        
        // Klucz obcy do Supplier - produkt ma jednego dostawcę
        public int SupplierId { get; set; } = default!;
        public Supplier Supplier { get; set; } = default!;

        //Relacja 1:M z ProductStock
        public IList<ProductStock> ProductStocks { get; set; } = new List<ProductStock>();        
        
        // Relacja M:N z Order przez OrderProduct
        public IList<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}