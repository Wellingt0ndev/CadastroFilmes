using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroFilmes.Domain.Dtos;
using CadastroFilmes.Web.Context;

namespace CadastroFilmes.Web.Controllers
{
    public class FilmeController : Controller
    {
        private readonly FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        // GET: Filme
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filmes.ToListAsync());
                          
        }

        // GET: Filme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Filmes == null)
            {
                return NotFound();
            }

            var filmeDto = await _context.Filmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmeDto == null)
            {
                return NotFound();
            }

            return View(filmeDto);
        }

        // GET: Filme/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Genero,Duracao")] FilmeDto filmeDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmeDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmeDto);
        }

        // GET: Filme/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Filmes == null)
            {
                return NotFound();
            }

            var filmeDto = await _context.Filmes.FindAsync(id);
            if (filmeDto == null)
            {
                return NotFound();
            }
            return View(filmeDto);
        }

        // POST: Filme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Genero,Duracao")] FilmeDto filmeDto)
        {
            if (id != filmeDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmeDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeDtoExists(filmeDto.Id))
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
            return View(filmeDto);
        }

        // GET: Filme/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Filmes == null)
            {
                return NotFound();
            }

            var filmeDto = await _context.Filmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmeDto == null)
            {
                return NotFound();
            }

            return View(filmeDto);
        }

        // POST: Filme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Filmes == null)
            {
                return Problem("Entity set 'FilmeContext.Filmes'  is null.");
            }
            var filmeDto = await _context.Filmes.FindAsync(id);
            if (filmeDto != null)
            {
                _context.Filmes.Remove(filmeDto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeDtoExists(int id)
        {
          return (_context.Filmes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
