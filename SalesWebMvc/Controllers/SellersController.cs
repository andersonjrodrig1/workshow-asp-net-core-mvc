using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SalesWebMvcContext _context;
        private SellerService _sellerService;

        public SellersController(SalesWebMvcContext context)
        {
            _context = context;
        }

        // GET: Sellers/Index
        public IActionResult Index()
        {
            IEnumerable<Seller> sellers = new SellerService(_context).FindAll();

            return View(sellers);
        }

        // GET: Sellers/Create
        public IActionResult Create()
        {
            return View();
        }
         
        // POST: Seller/Insert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email,BaseSalary,BirthDate,Department")] Seller seller)
        {
            _sellerService = new SellerService(_context);
            var result = _sellerService.InsertSeller(seller);

            return RedirectToAction("/Index");
        }
    }
}