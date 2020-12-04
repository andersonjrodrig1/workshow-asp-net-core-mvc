using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly DepartmentsService _departmentsService;

        public DepartmentsController(DepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        // GET: Departaments
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentsService.FindAll();

            return View(departments);
        }

        // GET: Departaments/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var department = await _departmentsService.Details(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        // GET: Departaments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                department = await _departmentsService.Create(department);
            }

            return View(department);
        }

        // GET: Departaments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _departmentsService.FindById(id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Department departament)
        {
            if (ModelState.IsValid)
            {
                departament = await _departmentsService.Update(departament);

                return RedirectToAction(nameof(Index));
            }

            return View(departament);
        }

        // GET: Departaments/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentsService.FindById(id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _departmentsService.FindById(id);

            if (department == null)
            {
                return NotFound();
            }

            await _departmentsService.Remove(department);

            return RedirectToAction(nameof(Index));
        }
    }
}
