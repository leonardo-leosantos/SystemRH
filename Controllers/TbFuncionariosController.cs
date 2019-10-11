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
    public class TbFuncionariosController : Controller
    {
        private readonly SYSTEMRHContext _context;

        public TbFuncionariosController(SYSTEMRHContext context)
        {
            _context = context;
        }

        // GET: TbFuncionarios
        public async Task<IActionResult> Index()
        {
            var sYSTEMRHContext = _context.TbFuncionario.Include(t => t.Cargo);
            return View(await sYSTEMRHContext.ToListAsync());
        }

        // GET: TbFuncionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbFuncionario = await _context.TbFuncionario
                .Include(t => t.Cargo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbFuncionario == null)
            {
                return NotFound();
            }

            return View(tbFuncionario);
        }

        // GET: TbFuncionarios/Create
        public IActionResult Create()
        {
            ViewData["Cargoid"] = new SelectList(_context.TbCargo, "Id", "Descricao");
            return View();
        }

        // POST: TbFuncionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,Email,Salario,Cargoid")] TbFuncionario tbFuncionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbFuncionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cargoid"] = new SelectList(_context.TbCargo, "Id", "Descricao", tbFuncionario.Cargoid);
            return View(tbFuncionario);
        }

        // GET: TbFuncionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbFuncionario = await _context.TbFuncionario.FindAsync(id);
            if (tbFuncionario == null)
            {
                return NotFound();
            }
            ViewData["Cargoid"] = new SelectList(_context.TbCargo, "Id", "Descricao", tbFuncionario.Cargoid);
            return View(tbFuncionario);
        }

        // POST: TbFuncionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Telefone,Email,Salario,Cargoid")] TbFuncionario tbFuncionario)
        {
            if (id != tbFuncionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbFuncionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbFuncionarioExists(tbFuncionario.Id))
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
            ViewData["Cargoid"] = new SelectList(_context.TbCargo, "Id", "Descricao", tbFuncionario.Cargoid);
            return View(tbFuncionario);
        }

        // GET: TbFuncionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbFuncionario = await _context.TbFuncionario
                .Include(t => t.Cargo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbFuncionario == null)
            {
                return NotFound();
            }

            return View(tbFuncionario);
        }

        // POST: TbFuncionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbFuncionario = await _context.TbFuncionario.FindAsync(id);
            _context.TbFuncionario.Remove(tbFuncionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbFuncionarioExists(int id)
        {
            return _context.TbFuncionario.Any(e => e.Id == id);
        }
    }
}
