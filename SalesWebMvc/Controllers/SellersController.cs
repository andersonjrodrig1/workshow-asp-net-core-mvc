using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            try
            {
                IEnumerable<Seller> sellers = _sellerService.FindAll();

                return View(sellers);
            }
            catch (ApplicationException app)
            {
                return RedirectToAction(nameof(Error), new { message = app.Message });
            }
        }

        // GET: Sellers/Create
        public IActionResult Create()
        {
            try
            {
                var departments = _departmentsService.FindAll().GetAwaiter().GetResult();
                var viewModel = new SellerFormViewModel { Departments = departments.ToList() };

                return View(viewModel);
            }
            catch (ApplicationException app)
            {
                return RedirectToAction(nameof(Error), new { message = app.Message });
            }
        }
         
        // POST: Seller/Insert
        public IActionResult Insert([Bind("Id,Name,Email,BaseSalary,BirthDate,DepartmentId")] Seller seller)
        {
            try
            {
                var result = _sellerService.InsertSeller(seller);

                return RedirectToAction("/Index");
            }
            catch (ApplicationException app)
            {
                return RedirectToAction(nameof(Error), new { message = app.Message });
            }
        }

        //GET: Seller/Delete
        public IActionResult Delete([Bind("Id")] int id)
        {
            try
            {
                var result = _sellerService.FindById(id);

                return View(result);
            }
            catch (Exception app)
            {
                return RedirectToAction(nameof(Error), new { message = app.Message });
            }
        }

        // DELETE: Seller/Remove
        public IActionResult Remove([Bind("Id")] int id)
        {
            try
            {
                _sellerService.Remove(id);

                return RedirectToAction("/Index");
            }
            catch (ApplicationException app)
            {
                return RedirectToAction(nameof(Error), new { message = app.Message });
            }
        }

        // GET: Seller/Details
        public IActionResult Details([Bind("Id")] int id)
        {
            try
            {
                var seller = _sellerService.FindById(id);

                return View(seller);
            }
            catch (ApplicationException app)
            {
                return RedirectToAction(nameof(Error), new { message = app.Message });
            }
        }

        // GET: Seller/Edit
        public IActionResult Edit([Bind("Id")] int id)
        {
            try
            {
                var seller = _sellerService.GetSellerById(id);

                return View(seller);
            }
            catch (ApplicationException app)
            {
                return RedirectToAction(nameof(Error), new { message = app.Message });
            }
        }

        //UPDATE: Seller/Update
        public IActionResult Update([Bind("Id,Name,Email,BaseSalary,BirthDate,DepartmentId")] Seller seller)
        {
            try
            {
                _sellerService.UpdateSeller(seller);

                return RedirectToAction("/Index");
            }
            catch (ApplicationException app)
            {
                return RedirectToAction(nameof(Error), new { message = app.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var error = new ErrorViewModel()
            {
                MessageError = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(error);
        }
    }
}