using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Mehak_6th.BussLayer
{
    public class ProductManager
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
    }
}
