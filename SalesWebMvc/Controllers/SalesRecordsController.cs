using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        public SalesRecordsController()
        {

        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        //GET: SalesRecords/SimpleSearch
        public async Task<IActionResult> SimpleSearch()
        {
            return View();
        }

        //GET: SalesRecords/GroupingSearch
        public async Task<IActionResult> GroupingSearch()
        {
            return View();
        }
    }
}