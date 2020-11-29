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
            var viewModel = new SellerFormViewModel { Departments = departments.ToList() };

            return View(viewModel);
        }
         
        // POST: Seller/Insert
        public IActionResult Insert([Bind("Id,Name,Email,BaseSalary,BirthDate,DepartmentId")] Seller seller)
        {
            var result = _sellerService.InsertSeller(seller);

            return RedirectToAction("/Index");
        }

        //GET: Seller/Delete
        public IActionResult Delete([Bind("Id")] int id)
        {
            var result = _sellerService.FindById(id);

            return View(result);
        }

        // DELETE: Seller/Remove
        public IActionResult Remove([Bind("Id")] int id)
        {
            _sellerService.Remove(id);

            return RedirectToAction("/Index");
        }
    }
}