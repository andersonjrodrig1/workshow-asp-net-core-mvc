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

        public IActionResult Index()
        {
            IEnumerable<Seller> sellers = new SellerService(_context).FindAll();

            return View(sellers);
        }
    }
}