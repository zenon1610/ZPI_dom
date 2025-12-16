using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.DataModels
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; } = default!;
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        
        // Klucz obcy do Order
        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;
    }
}