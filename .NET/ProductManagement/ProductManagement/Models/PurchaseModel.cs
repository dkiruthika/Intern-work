using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    public class PurchaseModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string PurchaseDate { get; set; }
        public int Quantity { get; set; }
    }
}