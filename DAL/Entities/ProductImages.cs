using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ProductImages 
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public Products Products { get; set; }
  
    }
}
