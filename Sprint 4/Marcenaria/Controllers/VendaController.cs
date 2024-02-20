using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Marcenaria.Models;

namespace Marcenaria.Controllers
{
    public class VendaController : Controller
    {
        private readonly Contexto _context;

        public VendaController(Contexto context)
        {
            _context = context;
        }

        // GET: Venda
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Venda.Include(v => v.Cliente).Include(v => v.Pagamento).Include(v => v.Vendedor);
            return View(await contexto.ToListAsync());
        }

        // GET: Venda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Pagamento)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.VendaId == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Venda/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteNome");
            ViewData["PagamentoId"] = new SelectList(_context.Pagamento, "PagamentoId", "PagamentoForma");
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "VendedorId", "VendedorNome");
            return View();
        }

        // POST: Venda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VendaId,VendaNome,VendaValor,VendaData,ClienteId,VendedorId,PagamentoId")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteNome", venda.ClienteId);
            ViewData["PagamentoId"] = new SelectList(_context.Pagamento, "PagamentoId", "PagamentoForma", venda.PagamentoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "VendedorId", "VendedorNome", venda.VendedorId);
            return View(venda);
        }

        // GET: Venda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteNome", venda.ClienteId);
            ViewData["PagamentoId"] = new SelectList(_context.Pagamento, "PagamentoId", "PagamentoForma", venda.PagamentoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "VendedorId", "VendedorNome", venda.VendedorId);
            return View(venda);
        }

        // POST: Venda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendaId,VendaNome,VendaValor,VendaData,ClienteId,VendedorId,PagamentoId")] Venda venda)
        {
            if (id != venda.VendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.VendaId))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteNome", venda.ClienteId);
            ViewData["PagamentoId"] = new SelectList(_context.Pagamento, "PagamentoId", "PagamentoForma", venda.PagamentoId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "VendedorId", "VendedorNome", venda.VendedorId);
            return View(venda);
        }

        // GET: Venda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Pagamento)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.VendaId == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Venda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Venda == null)
            {
                return Problem("Entity set 'Contexto.Venda'  is null.");
            }
            var venda = await _context.Venda.FindAsync(id);
            if (venda != null)
            {
                _context.Venda.Remove(venda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool VendaExists(int id)
        {
          return (_context.Venda?.Any(e => e.VendaId == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Imprimir(int? id)
        {
            if (id == null || _context.Venda == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Pagamento)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.VendaId == id);

            venda.ProdutoList = await _context.VendaHasProduto

                //Busca os dados de outra tabela (INNER JOIN)
                .Include(x => x.Produto)
                //Seleciona apenas os produtos daquela venda
                .Where(x => x.ProdutoId == id)
                //Agrupa todos os produtos iguais
                .GroupBy(x => new { x.ProdutoId })
                //Seleciona os dados do agrupamento
                .Select(vp => vp.OrderByDescending(x => x.ProdutoId).First())
                //Converte tudo isso em uma lista
                .ToListAsync();

            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }
    }
}
