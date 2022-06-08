using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ProductImages
    {
        public int ImageID { get; set; }
        public int ImageName { get; set; }
        public int ProducrNo { get; set; }
        public Products Products { get; set; }
    }
}
