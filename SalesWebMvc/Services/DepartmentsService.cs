using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class DepartmentsService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentsService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<Department> FindById(int id) => await _context.Set<Department>().AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Department>> FindAll() => await _context.Set<Department>().AsQueryable().AsNoTracking().ToListAsync();

        public async Task<Department> Details(int id)
        {
            var departament = await _context.Departament.FirstOrDefaultAsync(x => x.Id == id);

            if (departament == null)
                return null;

            return departament;
        }

        public async Task<Department> Create(Department department)
        {
            _context.Set<Department>().Add(department);
            await SaveChangesAsync();

            return department;
        }

        public async Task<Department> Update(Department department)
        {
            _context.Set<Department>().Update(department);
            await SaveChangesAsync();

            return department;
        }

        public async Task Remove(Department department)
        {
            _context.Set<Department>().Remove(department);
            await SaveChangesAsync();
        }

        private async Task SaveChangesAsync() => await _context.SaveChangesAsync(true);
    }
}
