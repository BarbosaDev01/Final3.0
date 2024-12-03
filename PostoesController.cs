using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aplicacaoFinal.Data;
using aplicacaoFinal.Models;

namespace aplicacaoFinal.Controllers
{
    public class PostoesController : Controller
    {
        private readonly aplicacaoFinalContext _context;

        public PostoesController(aplicacaoFinalContext context)
        {
            _context = context;
        }

        // GET: Postoes
        public async Task<IActionResult> Index()
        {
              return _context.Posto != null ? 
                          View(await _context.Posto.ToListAsync()) :
                          Problem("Entity set 'aplicacaoFinalContext.Posto'  is null.");
        }

        // GET: Postoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Posto == null)
            {
                return NotFound();
            }

            var posto = await _context.Posto
                .FirstOrDefaultAsync(m => m.IdPosto == id);
            if (posto == null)
            {
                return NotFound();
            }

            return View(posto);
        }

        // GET: Postoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Postoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPosto,NomePosto,TipoPino,PotenciaPosto,PrecoPorKwh,Rua,Bairro,IdUsuario")] Posto posto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(posto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(posto);
        }

        // GET: Postoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Posto == null)
            {
                return NotFound();
            }

            var posto = await _context.Posto.FindAsync(id);
            if (posto == null)
            {
                return NotFound();
            }
            return View(posto);
        }

        // POST: Postoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPosto,NomePosto,TipoPino,PotenciaPosto,PrecoPorKwh,Rua,Bairro,IdUsuario")] Posto posto)
        {
            if (id != posto.IdPosto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostoExists(posto.IdPosto))
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
            return View(posto);
        }

        // GET: Postoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Posto == null)
            {
                return NotFound();
            }

            var posto = await _context.Posto
                .FirstOrDefaultAsync(m => m.IdPosto == id);
            if (posto == null)
            {
                return NotFound();
            }

            return View(posto);
        }

        // POST: Postoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Posto == null)
            {
                return Problem("Entity set 'aplicacaoFinalContext.Posto'  is null.");
            }
            var posto = await _context.Posto.FindAsync(id);
            if (posto != null)
            {
                _context.Posto.Remove(posto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostoExists(int id)
        {
          return (_context.Posto?.Any(e => e.IdPosto == id)).GetValueOrDefault();
        }
    }
}
