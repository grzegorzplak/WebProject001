using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProject001.Models;

namespace WebProject001.Controllers
{
    public class ExpendituresController : Controller
    {
        private readonly Context _context;

        public ExpendituresController(Context context)
        {
            _context = context;
        }

        // GET: Expenditures
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchExpenditureName,
            int? pageNumber
        )
        {
            int pageSize = 50;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SortByExpenditureName"] = (sortOrder == "expenditureName_asc") ? "expenditureName_desc" : "expenditureName_asc";
            ViewData["CurrentExpenditureName"] = searchExpenditureName;
            if (searchExpenditureName != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchExpenditureName = currentFilter;
            }
            ViewData["CurrentFilter"] = searchExpenditureName;

            var result = from x in _context.Expenditures select x;
            result = result.Include(e => e.Category).Include(e => e.PaymentMethod).Include(e => e.Shop);
            if (!String.IsNullOrEmpty(searchExpenditureName))
            {
                result = result.Where(x => x.ExpenditureName.Contains(searchExpenditureName));
            }

            switch (sortOrder)
            {
                case "expenditureName_desc":
                    result = result.OrderByDescending(f => f.ExpenditureName);
                    break;
                default:
                    result = result.OrderBy(f => f.ExpenditureName);
                    break;
            }
            return View(await PaginatedList<Expenditure>.CreateAsync(result.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Expenditures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenditure = await _context.Expenditures
                .Include(e => e.Category)
                .Include(e => e.PaymentMethod)
                .Include(e => e.Shop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenditure == null)
            {
                return NotFound();
            }

            return View(expenditure);
        }

        // GET: Expenditures/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName");
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "Id", "Name");
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "ShopName");
            return View();
        }

        // POST: Expenditures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExpenditureDate,ExpenditureName,Price,Quantity,Description,CategoryId,ShopId,PaymentMethodId")] Expenditure expenditure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenditure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", expenditure.CategoryId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "Id", "Name", expenditure.PaymentMethodId);
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "ShopName", expenditure.ShopId);
            return View(expenditure);
        }

        // GET: Expenditures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenditure = await _context.Expenditures.FindAsync(id);
            if (expenditure == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", expenditure.CategoryId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "Id", "Name", expenditure.PaymentMethodId);
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "ShopName", expenditure.ShopId);
            return View(expenditure);
        }

        // POST: Expenditures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExpenditureDate,ExpenditureName,Price,Quantity,Description,CategoryId,ShopId,PaymentMethodId")] Expenditure expenditure)
        {
            if (id != expenditure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenditure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenditureExists(expenditure.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "CategoryName", expenditure.CategoryId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "Id", "Name", expenditure.PaymentMethodId);
            ViewData["ShopId"] = new SelectList(_context.Shops, "Id", "ShopName", expenditure.ShopId);
            return View(expenditure);
        }

        // GET: Expenditures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenditure = await _context.Expenditures
                .Include(e => e.Category)
                .Include(e => e.PaymentMethod)
                .Include(e => e.Shop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenditure == null)
            {
                return NotFound();
            }

            return View(expenditure);
        }

        // POST: Expenditures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenditure = await _context.Expenditures.FindAsync(id);
            if (expenditure != null)
            {
                _context.Expenditures.Remove(expenditure);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenditureExists(int id)
        {
            return _context.Expenditures.Any(e => e.Id == id);
        }
    }
}
