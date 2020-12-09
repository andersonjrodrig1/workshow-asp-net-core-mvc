using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET: SalesRecords/SimpleSearch
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            try
            {
                var result = await _salesRecordService.FindByDate(minDate, maxDate);

                return View(result);
            }
            catch (ApplicationException app)
            {
                return RedirectToAction(nameof(Error), new { message = app.Message });
            }
        }

        //GET: SalesRecords/GroupingSearch
        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            var result = await _salesRecordService.FindByDateGrouping(minDate, maxDate);

            return View(result);
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