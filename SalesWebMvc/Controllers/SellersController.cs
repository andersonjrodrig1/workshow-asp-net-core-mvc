using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentsService _departmentsService;

        public SellersController(SellerService sellerService, DepartmentsService departmentsService)
        {
            _sellerService = sellerService;
            _departmentsService = departmentsService;
        }

        // GET: Sellers/Index
        public IActionResult Index()
        {
            IEnumerable<Seller> sellers = _sellerService.FindAll();

            return View(sellers);
        }

        // GET: Sellers/Create
        public IActionResult Create()
        {
            var departments = _departmentsService.FindAll();
            var viewModel = new SellerViewModel { Departments = departments.ToList() };

            return View(viewModel);
        }
         
        // POST: Seller/Insert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email,BaseSalary,BirthDate,Department")] Seller seller)
        {
            var result = _sellerService.InsertSeller(seller);

            return RedirectToAction("/Index");
        }
    }
}