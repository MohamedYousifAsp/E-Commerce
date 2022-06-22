using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCommerce.ViewModels
{
    public class ProductImagesViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float ProductPrice { get; set; }
        public int CatogaryId { get; set; }
        public string CatogaryName { get; set; }
        public List<Catogary> Catogary { get; set; }
        public string ImageURL { get; set; }
        public List<IFormFile> File { get; set; }
    }
}
