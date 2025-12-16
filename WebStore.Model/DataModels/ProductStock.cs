using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.DataModels
{
    public class ProductStock
    {   
        public int Id { get; set; }
        public int Quantity { get; set; }
       
        //Klucz obcy do Product
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
    }
}