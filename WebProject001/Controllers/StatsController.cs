using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebProject001.Models;
using WebProject001.ViewModels;

namespace WebProject001.Controllers
{
    public class StatsController : Controller
    {
        private readonly Context _context;

        public StatsController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExpendituresByYearMonth()
        {
            var result = _context.Expenditures
                .GroupBy(x => _context.GetYearMonth(x.ExpenditureDate))
                .Select(
                    y => new ExpenditureByYearMonth
                    {
                        YearMonth = _context.GetYearMonth(y.First().ExpenditureDate),
                        Total = y.Sum(c => Math.Round(c.Price * c.Quantity, 2))
                    }
                );
            return View(result);
        }

        [HttpGet]
        public IActionResult ExpendituresByExpeditureFilterByYearMonth()
        {
            var listYearMonth = _context.Expenditures
                .GroupBy(a => _context.GetYearMonth(a.ExpenditureDate))
                .Select(
                    b => new YearMonthVM
                    {
                        YearMonth = _context.GetYearMonth(b.First().ExpenditureDate)
                    }
                );
            ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth");

            string criteria = (listYearMonth.ToList())[0].YearMonth;

            ViewData["Criteria"] = criteria;

            var result = _context.Expenditures
                .Where(o => _context.GetYearMonth(o.ExpenditureDate) == criteria)
                .GroupBy(p => p.ExpenditureName)
                .Select(
                    q => new ExpenditureByExpenditure
                    {
                        ExpenditureName = q.First().ExpenditureName,
                        Total = q.Sum(r => Math.Round(r.Price * r.Quantity, 2))
                    }
                );
            return View(result);
        }

        [HttpPost]
        public IActionResult ExpendituresByExpeditureFilterByYearMonth(string yearMonth)
        {
            var listYearMonth = _context.Expenditures
                .GroupBy(a => _context.GetYearMonth(a.ExpenditureDate))
                .Select(
                    b => new YearMonthVM
                    {
                        YearMonth = _context.GetYearMonth(b.First().ExpenditureDate)
                    }
                );
            ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth", yearMonth);

            string criteria = yearMonth;

            ViewData["Criteria"] = criteria;

            var result = _context.Expenditures
                .Where(o => _context.GetYearMonth(o.ExpenditureDate) == criteria)
                .GroupBy(p => p.ExpenditureName)
                .Select(
                    q => new ExpenditureByExpenditure
                    {
                        ExpenditureName = q.First().ExpenditureName,
                        Total = q.Sum(r => Math.Round(r.Price * r.Quantity, 2))
                    }
                );
            return View(result);
        }

        [HttpGet]
        public IActionResult ExpendituresByCategoryFilterByYearMonth()
        {
            var listYearMonth = _context.Expenditures
                .GroupBy(a => _context.GetYearMonth(a.ExpenditureDate))
                .Select(
                    b => new YearMonthVM
                    {
                        YearMonth = _context.GetYearMonth(b.First().ExpenditureDate)
                    }
                );
            ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth");

            string criteria = (listYearMonth.ToList())[0].YearMonth;

            ViewData["Criteria"] = criteria;

            var result = _context.Expenditures.Include(n => n.Category)
                .Where(o => _context.GetYearMonth(o.ExpenditureDate) == criteria)
                .GroupBy(p => p.Category.CategoryName)
                .Select(
                    q => new ExpenditureByCategory
                    {
                        CategoryName = q.First().Category.CategoryName,
                        Total = q.Sum(r => Math.Round(r.Price * r.Quantity, 2))
                    }
                );
            return View(result);
        }

        [HttpPost]
        public IActionResult ExpendituresByCategoryFilterByYearMonth(string yearMonth)
        {
            var listYearMonth = _context.Expenditures
                .GroupBy(a => _context.GetYearMonth(a.ExpenditureDate))
                .Select(
                    b => new YearMonthVM
                    {
                        YearMonth = _context.GetYearMonth(b.First().ExpenditureDate)
                    }
                );
            ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth", yearMonth);

            string criteria = yearMonth;

            ViewData["Criteria"] = criteria;

            var result = _context.Expenditures.Include(n => n.Category)
                .Where(o => _context.GetYearMonth(o.ExpenditureDate) == criteria)
                .GroupBy(p => p.Category.CategoryName)
                .Select(
                    q => new ExpenditureByCategory
                    {
                        CategoryName = q.First().Category.CategoryName,
                        Total = q.Sum(r => Math.Round(r.Price * r.Quantity, 2))
                    }
                );
            return View(result);
        }

        [HttpGet]
        public IActionResult ExpendituresByShopFilterByYearMonth()
        {
            var listYearMonth = _context.Expenditures
                .GroupBy(a => _context.GetYearMonth(a.ExpenditureDate))
                .Select(
                    b => new YearMonthVM
                    {
                        YearMonth = _context.GetYearMonth(b.First().ExpenditureDate)
                    }
                );
            ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth");

            string criteria = (listYearMonth.ToList())[0].YearMonth;

            ViewData["Criteria"] = criteria;

            var result = _context.Expenditures.Include(n => n.Category)
                .Where(o => _context.GetYearMonth(o.ExpenditureDate) == criteria)
                .GroupBy(p => p.Shop.ShopName)
                .Select(
                    q => new ExpenditureByShop
                    {
                        ShopName = q.First().Shop.ShopName,
                        Total = q.Sum(r => Math.Round(r.Price * r.Quantity, 2))
                    }
                );
            return View(result);
        }

        [HttpPost]
        public IActionResult ExpendituresByShopFilterByYearMonth(string yearMonth)
        {
            var listYearMonth = _context.Expenditures
                .GroupBy(a => _context.GetYearMonth(a.ExpenditureDate))
                .Select(
                    b => new YearMonthVM
                    {
                        YearMonth = _context.GetYearMonth(b.First().ExpenditureDate)
                    }
                );
            ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth", yearMonth);

            string criteria = yearMonth;

            ViewData["Criteria"] = criteria;

            var result = _context.Expenditures.Include(n => n.Category)
                .Where(o => _context.GetYearMonth(o.ExpenditureDate) == criteria)
                .GroupBy(p => p.Shop.ShopName)
                .Select(
                    q => new ExpenditureByShop
                    {
                        ShopName = q.First().Shop.ShopName,
                        Total = q.Sum(r => Math.Round(r.Price * r.Quantity, 2))
                    }
                );
            return View(result);
        }

        // ====
        [HttpGet]
        public IActionResult ExpendituresByPaymentMethodFilterByYearMonth()
        {
            var listYearMonth = _context.Expenditures
                .GroupBy(a => _context.GetYearMonth(a.ExpenditureDate))
                .Select(
                    b => new YearMonthVM
                    {
                        YearMonth = _context.GetYearMonth(b.First().ExpenditureDate)
                    }
                );
            ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth");

            string criteria = (listYearMonth.ToList())[0].YearMonth;

            ViewData["Criteria"] = criteria;

            var result = _context.Expenditures.Include(n => n.Category)
                .Where(o => _context.GetYearMonth(o.ExpenditureDate) == criteria)
                .GroupBy(p => p.PaymentMethod.Name)
                .Select(
                    q => new ExpenditureByPaymentMethod
                    {
                        PaymentMethodName = q.First().PaymentMethod.Name,
                        Total = q.Sum(r => Math.Round(r.Price * r.Quantity, 2))
                    }
                );
            return View(result);
        }

        [HttpPost]
        public IActionResult ExpendituresByPaymentMethodFilterByYearMonth(string yearMonth)
        {
            var listYearMonth = _context.Expenditures
                .GroupBy(a => _context.GetYearMonth(a.ExpenditureDate))
                .Select(
                    b => new YearMonthVM
                    {
                        YearMonth = _context.GetYearMonth(b.First().ExpenditureDate)
                    }
                );
            ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth", yearMonth);

            string criteria = yearMonth;

            ViewData["Criteria"] = criteria;

            var result = _context.Expenditures.Include(n => n.Category)
                .Where(o => _context.GetYearMonth(o.ExpenditureDate) == criteria)
                .GroupBy(p => p.PaymentMethod.Name)
                .Select(
                    q => new ExpenditureByPaymentMethod
                    {
                        PaymentMethodName = q.First().PaymentMethod.Name,
                        Total = q.Sum(r => Math.Round(r.Price * r.Quantity, 2))
                    }
                );
            return View(result);
        }

        public List<object> GetDataForExpendituresByYearMonthChart()
        {
            var result = _context.Expenditures
                .GroupBy(x => _context.GetYearMonth(x.ExpenditureDate))
                .Select(
                    y => new ExpenditureByYearMonth()
                    {
                        YearMonth = _context.GetYearMonth(y.First().ExpenditureDate),
                        Total = y.Sum(c => Math.Round(c.Price * c.Quantity, 2))
                    }
                );
            List<object> data = new List<object>();
            List<string> labels = result.Select(p => p.YearMonth).ToList();
            data.Add(labels);
            List<decimal> series = result.Select(p => p.Total).ToList();
            data.Add(series);

            return data;
        }

        public IActionResult ExpendituresByYearMonthChart()
        {
            return View();
        }

        public List<object> GetDataForExpendituresByCategoryFilterByYearMonthChart(string criteria)
        {
            if(criteria == null)
            {
                criteria = "";
            }
            var result = _context.Expenditures
                .Where(o => _context.GetYearMonth(o.ExpenditureDate).Contains(criteria))
                .GroupBy(p => p.Category.CategoryName)
                .Select(
                    y => new ExpenditureByCategory()
                    {
                        CategoryName = y.First().Category.CategoryName,
                        Total = y.Sum(c => Math.Round(c.Price * c.Quantity, 2))
                    }
                );
            List<object> data = new List<object>();
            List<string> labels = result.Select(p => p.CategoryName).ToList();
            data.Add(labels);
            List<decimal> series = result.Select(p => p.Total).ToList();
            data.Add(series);

            return data;
        }

        public IActionResult ExpendituresByCategoryFilterByYearMonthChart()
        {
            var listYearMonth = _context.Expenditures
                .GroupBy(a => _context.GetYearMonth(a.ExpenditureDate))
                .Select(
                    b => new YearMonthVM
                    {
                        YearMonth = _context.GetYearMonth(b.First().ExpenditureDate)
                    }
                );
            ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth");

            return View();
        }

        [HttpPost]
        public IActionResult ExpendituresByCategoryFilterByYearMonthChart(string criteria)
        {
            var listYearMonth = _context.Expenditures
                .GroupBy(a => _context.GetYearMonth(a.ExpenditureDate))
                .Select(
                    b => new YearMonthVM
                    {
                        YearMonth = _context.GetYearMonth(b.First().ExpenditureDate)
                    }
                );
            ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth", criteria);

            return View();
        }

        public List<object> GetDataForExpendituresByExpeditureFilterByYearMonthChart(string criteria)
        {
            if (criteria == null)
            {
                criteria = "";
            }
            var result = _context.Expenditures
                .Where(o => _context.GetYearMonth(o.ExpenditureDate).Contains(criteria))
                .GroupBy(p => p.ExpenditureName)
                .Select(
                    y => new ExpenditureByExpenditure()
                    {
                        ExpenditureName = y.First().ExpenditureName,
                        Total = y.Sum(c => Math.Round(c.Price * c.Quantity, 2))
                    }
                );
            List<object> data = new List<object>();
            List<string> labels = result.Select(p => p.ExpenditureName).ToList();
            data.Add(labels);
            List<decimal> series = result.Select(p => p.Total).ToList();
            data.Add(series);

            return data;
        }

        [HttpGet, HttpPost]
        public IActionResult ExpendituresByExpeditureFilterByYearMonthChart(string criteria)
        {
            var listYearMonth = _context.Expenditures
                .GroupBy(a => _context.GetYearMonth(a.ExpenditureDate))
                .Select(
                    b => new YearMonthVM
                    {
                        YearMonth = _context.GetYearMonth(b.First().ExpenditureDate)
                    }
                );
            if (criteria == null)
            {
                ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth");
            }
            else
            {
                ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth", criteria);
            }

            return View();
        }

        public List<object> GetDataForExpendituresByPaymentMethodFilterByYearMonthChart(string criteria)
        {
            if (criteria == null)
            {
                criteria = "";
            }
            var result = _context.Expenditures
                .Where(o => _context.GetYearMonth(o.ExpenditureDate).Contains(criteria))
                .GroupBy(p => p.PaymentMethod.Name)
                .Select(
                    y => new ExpenditureByPaymentMethod()
                    {
                        PaymentMethodName = y.First().PaymentMethod.Name,
                        Total = y.Sum(c => Math.Round(c.Price * c.Quantity, 2))
                    }
                );
            List<object> data = new List<object>();
            List<string> labels = result.Select(p => p.PaymentMethodName).ToList();
            data.Add(labels);
            List<decimal> series = result.Select(p => p.Total).ToList();
            data.Add(series);

            return data;
        }

        [HttpGet, HttpPost]
        public IActionResult ExpendituresByPaymentMethodFilterByYearMonthChart(string? criteria)
        {
            var listYearMonth = _context.Expenditures
                .GroupBy(a => _context.GetYearMonth(a.ExpenditureDate))
                .Select(
                    b => new YearMonthVM
                    {
                        YearMonth = _context.GetYearMonth(b.First().ExpenditureDate)
                    }
                );
            if (criteria == null)
            {
                ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth");
            }
            else
            {
                ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth", criteria);
            }

            return View();
        }

        public List<object> GetDataForExpendituresByShopFilterByYearMonthChart(string criteria)
        {
            if (criteria == null)
            {
                criteria = "";
            }
            var result = _context.Expenditures
                .Where(o => _context.GetYearMonth(o.ExpenditureDate).Contains(criteria))
                .GroupBy(p => p.Shop.ShopName)
                .Select(
                    y => new ExpenditureByShop()
                    {
                        ShopName = y.First().Shop.ShopName,
                        Total = y.Sum(c => Math.Round(c.Price * c.Quantity, 2))
                    }
                );
            List<object> data = new List<object>();
            List<string> labels = result.Select(p => p.ShopName).ToList();
            data.Add(labels);
            List<decimal> series = result.Select(p => p.Total).ToList();
            data.Add(series);

            return data;
        }

        [HttpGet, HttpPost]
        public IActionResult ExpendituresByShopFilterByYearMonthChart(string? criteria)
        {
            var listYearMonth = _context.Expenditures
                .GroupBy(a => _context.GetYearMonth(a.ExpenditureDate))
                .Select(
                    b => new YearMonthVM
                    {
                        YearMonth = _context.GetYearMonth(b.First().ExpenditureDate)
                    }
                );
            if (criteria == null)
            {
                ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth");
            }
            else
            {
                ViewData["YearMonth"] = new SelectList(listYearMonth, "YearMonth", "YearMonth", criteria);
            }

            return View();
        }
    }
}
