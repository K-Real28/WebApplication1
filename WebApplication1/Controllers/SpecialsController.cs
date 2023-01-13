using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Domain;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    public class SpecialsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISpecialService _specialService;

        public SpecialsController(AppDbContext context, ISpecialService specialService)
        {
            _context = context;
            _specialService = specialService;
        }

        // GET: Specials
        public async Task<IActionResult> Index()
        {
              return View(await _specialService.GetSpecials());
        }

        // GET: Specials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var special = _specialService.GetById(id);
            if (special == null)
            {
                return NotFound();
            }

            return View(special);
        }

        // GET: Specials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Special special)
        {
            if (ModelState.IsValid)
            {
                await _specialService.Create(special);
                return RedirectToAction(nameof(Index));
            }
            return View(special);
        }

        // GET: Specials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var special = _specialService.GetById(id);
            if (special == null)
            {
                return NotFound();
            }
            return View(special);
        }

        // POST: Specials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Special special)
        {
            if (id != special.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _specialService.Update(special);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialExists(special.Id))
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
            return View(special);
        }

        // GET: Specials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var special = _specialService.GetById(id);
            if (special == null)
            {
                return NotFound();
            }

            return View(special);
        }

        // POST: Specials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _specialService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialExists(int id)
        {
          return _specialService.SpecialExists(id);
        }
    }
}
