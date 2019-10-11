using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SystemRH.Models;

namespace SystemRH.Controllers
{
    public class TbCargoesController : Controller
    {
        private readonly SYSTEMRHContext _context;

        public TbCargoesController(SYSTEMRHContext context)
        {
            _context = context;
        }

        // GET: TbCargoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbCargo.ToListAsync());
        }

        // GET: TbCargoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCargo = await _context.TbCargo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbCargo == null)
            {
                return NotFound();
            }

            return View(tbCargo);
        }

        // GET: TbCargoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbCargoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] TbCargo tbCargo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCargo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbCargo);
        }

        // GET: TbCargoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCargo = await _context.TbCargo.FindAsync(id);
            if (tbCargo == null)
            {
                return NotFound();
            }
            return View(tbCargo);
        }

        // POST: TbCargoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] TbCargo tbCargo)
        {
            if (id != tbCargo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCargo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbCargoExists(tbCargo.Id))
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
            return View(tbCargo);
        }

        // GET: TbCargoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCargo = await _context.TbCargo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbCargo == null)
            {
                return NotFound();
            }

            return View(tbCargo);
        }

        // POST: TbCargoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCargo = await _context.TbCargo.FindAsync(id);
            _context.TbCargo.Remove(tbCargo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbCargoExists(int id)
        {
            return _context.TbCargo.Any(e => e.Id == id);
        }
    }
}
