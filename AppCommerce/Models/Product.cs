using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Http;

namespace AppCommerce.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float ProductPrice { get; set; }
        public int CatogaryId { get; set; }
        public List<Catogary> Catogary { get; set; }
        public string ImageURL { get; set; }
        public List<IFormFile> File { get; set; }
    }
}
