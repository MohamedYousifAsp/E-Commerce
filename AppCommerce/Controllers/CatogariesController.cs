using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BLL;
using DAL.Entities;
using DAL.Interfaces;

namespace AppCommerce.Controllers
{
    public class CatogariesController : Controller
    {
        private readonly IUnitOfWork<Catogary> _catogary;

        public CatogariesController(IUnitOfWork<Catogary> catogary)
        {
            _catogary = catogary;
        }

        // GET: Catogaries
        public IActionResult Index()
        {
            return View(_catogary.Entity.GetAll());
        }

        // GET: Catogaries/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catogary = _catogary.Entity.GetById(id);
            if (catogary == null)
            {
                return NotFound();
            }

            return View(catogary);
        }

        // GET: Catogaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catogaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CatogaryName")] Catogary catogary)
        {
            if (ModelState.IsValid)
            {
                _catogary.Entity.insert(catogary);
                _catogary.save();
                return RedirectToAction(nameof(Index));
            }
            return View(catogary);
        }

        // GET: Catogaries/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catogary = _catogary.Entity.GetById(id);
            if (catogary == null)
            {
                return NotFound();
            }
            return View(catogary);
        }

        // POST: Catogaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("Id,CatogaryName")] Catogary catogary)
        {
            if (id != catogary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _catogary.Entity.Update(catogary);
                    _catogary.save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatogaryExists(catogary.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catogary);
        }

        // GET: Catogaries/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catogary = _catogary.Entity.GetById(id);
            if (catogary == null)
            {
                return NotFound();
            }

            return View(catogary);
        }

        // POST: Catogaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
             _catogary.Entity.Delete(id);
             _catogary.save();
            return RedirectToAction(nameof(Index));
        }

        private bool CatogaryExists(int id)
        {
            return _catogary.Entity.GetAll().Any(e => e.Id == id);
        }
    }
}
