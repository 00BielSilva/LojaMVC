
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaMVC.Models;
using LojaMVC.Data;

public class ProdutoController : Controller
{
    private readonly LojaMVCContext _context;

    public ProdutoController(LojaMVCContext context)
    {
        _context = context;
    }

    // GET: PRODUTOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Produtos.ToListAsync());
    }

    // GET: PRODUTOS/Details/5
    public async Task<IActionResult> Details(int? id_produto)
    {
        if (id_produto == null)
        {
            return NotFound();
        }

        var produto = await _context.Produtos
            .FirstOrDefaultAsync(m => m.Id_produto == id_produto);
        if (produto == null)
        {
            return NotFound();
        }

        return View(produto);
    }

    // GET: PRODUTOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PRODUTOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id_produto,Nome,Preco,Estoque")] Produto produto)
    {
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(produto);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(produto);
        //}
        if (!produto.Validation())
        {
            ModelState.AddModelError("", "Produto inválido, tente novamente");
            return View(produto);
        }
        _context.Add(produto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: PRODUTOS/Edit/5
    public async Task<IActionResult> Edit(int? id_produto)
    {
        if (id_produto == null)
        {
            return NotFound();
        }

        var produto = await _context.Produtos.FindAsync(id_produto);
        if (produto == null)
        {
            return NotFound();
        }
        return View(produto);
    }

    // POST: PRODUTOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id_produto, [Bind("Id_produto,Nome,Preco,Estoque")] Produto produto)
    {
        if (id_produto != produto.Id_produto)
        {
            return NotFound();
        }

        //if (ModelState.IsValid)
        //{
        //    try
        //    {
        //        _context.Update(produto);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProdutoExists(produto.Id_produto))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
        if (!produto.Validation())
        {
            ModelState.AddModelError("", "Cliente inválido, tente novamente");
            return View(produto);
        }
        _context.Add(produto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
       
    }

    // GET: PRODUTOS/Delete/5
    public async Task<IActionResult> Delete(int? id_produto)
    {
        if (id_produto == null)
        {
            return NotFound();
        }

        var produto = await _context.Produtos
            .FirstOrDefaultAsync(m => m.Id_produto == id_produto);
        if (produto == null)
        {
            return NotFound();
        }

        return View(produto);
    }

    // POST: PRODUTOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id_produto)
    {
        var produto = await _context.Produtos.FindAsync(id_produto);
        if (produto != null)
        {
            _context.Produtos.Remove(produto);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProdutoExists(int? id_produto)
    {
        return _context.Produtos.Any(e => e.Id_produto == id_produto);
    }
}
