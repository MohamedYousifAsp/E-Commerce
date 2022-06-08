using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float ProductPrice { get; set; }
        public int CatogaryNo { get; set; }
        public Catogary Catogary { get; set; }
        public ICollection<ProductImages> ProductImages { get; set; }


    }
}
