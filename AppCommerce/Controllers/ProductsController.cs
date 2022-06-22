using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BLL;
using DAL.Entities;
using AppCommerce.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AppCommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork<Products> _products;
        private readonly IUnitOfWork<Catogary> _catogary;
        private readonly IUnitOfWork<ProductImages> _productImages;
        private readonly IHostingEnvironment _hosting;

        public ProductsController(IUnitOfWork<Products> products, IUnitOfWork<Catogary> catogary, IUnitOfWork<ProductImages> productImages, IHostingEnvironment hosting)
        {
            _products = products;
            _catogary = catogary;
            _productImages = productImages;
            _hosting = hosting;
        }

        // GET: Products
        public IActionResult Index()
        {
            return View(_products.Entity.GetAll());
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = _products.Entity.GetById(id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {

        

            var GetAllCatogray = new ProductImagesViewModel
            {
                Catogary = _catogary.Entity.GetAll().ToList()
            };
            return View(GetAllCatogray);
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductImagesViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Products products = new Products();
                {
                    var CatogaryTypeID = _catogary.Entity.GetById(viewModel.CatogaryId);

                    products.ProductName = viewModel.ProductName;
                    products.ProductDescription = viewModel.ProductDescription;
                    products.ProductPrice = viewModel.ProductPrice;
                    products.Catogary = CatogaryTypeID;
                    _products.Entity.insert(products);
                    _products.save();
                };
                if (viewModel.File != null)
                {
                
                    string uploads, fullpath;
                    uploads = Path.Combine(_hosting.WebRootPath, @"ImageProductUplode");

                    foreach (IFormFile file in viewModel.File)
                    {
                        fullpath = Path.Combine(uploads, file.FileName);
                        file.CopyTo(new FileStream(fullpath, FileMode.Create));
                        ProductImages productImages = new ProductImages();
                        productImages.ImageUrl = file.FileName;

                        productImages.Products = products;

                        _productImages.Entity.insert(productImages);
                    }
                    _productImages.save();
                }
                
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = _products.Entity.GetById(id);
            ProductImagesViewModel GetAllProduct = new ProductImagesViewModel
            {
                 Id = products.Id,
                 ProductName= products.ProductName,
                 ProductDescription= products.ProductDescription,
                 ProductPrice= products.ProductPrice,
                 Catogary = _catogary.Entity.GetAll().ToList(),
                 CatogaryId =products.Catogary.Id,
            };

            return View(GetAllProduct);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductImagesViewModel viewModel)
        {
          
                try
                {
                    var products = _products.Entity.GetById(id);
                    products.ProductName = viewModel.ProductName;
                    products.ProductDescription = viewModel.ProductDescription;
                    products.ProductPrice = viewModel.ProductPrice;
                    products.Catogary = _catogary.Entity.GetById(viewModel.CatogaryId);
                    _products.Entity.Update(products);
                    _products.save();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
                
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = _products.Entity.GetById(id);
              
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            _products.Entity.Delete(id);
            _products.save();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _products.Entity.GetAll().Any(e => e.Id == id);
        }
    }
}
