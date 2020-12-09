using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesRecord>> FindByDate(DateTime? initial, DateTime? final)
        {
            IQueryable<SalesRecord> query = _context.Set<SalesRecord>().AsQueryable().AsNoTracking();

            if (initial.HasValue && initial.Value != DateTime.MinValue)
            {
                query = query.Where(x => x.Date >= initial.Value);
            }

            if (final.HasValue && initial.Value != DateTime.MinValue && initial.Value != DateTime.MaxValue)
            {
                query = query.Where(x => x.Date <= final.Value);
            }

            return await query.Include(x => x.Seller)
                              .ThenInclude(x => x.Department)
                              .ToListAsync();
        }

        public async Task<IEnumerable<IGrouping<Department, SalesRecord>>> FindByDateGrouping(DateTime? initial, DateTime? final)
        {
            var query = await FindByDate(initial, final);

            IEnumerable<IGrouping<Department, SalesRecord>> salesRecords = query.GroupBy(p => p.Seller.Department).ToList();

            return salesRecords;
        }
    }
}
