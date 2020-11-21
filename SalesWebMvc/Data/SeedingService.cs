using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Set<Department>().Any())
            {
                var departments = new List<Department>()
                {
                    new Department() { Name = "Eletronics" },
                    new Department() { Name = "Computer" },
                    new Department() { Name = "Books" }
                };

                _context.Set<Department>().AddRange(departments);
                _context.SaveChanges();
            }

            if (!_context.Set<Seller>().Any())
            {
                var sellers = new List<Seller>()
                {
                    new Seller() { Name = "Richard Marchel", Email = "richard.marchel@teste.com", BaseSalary = 3000, BirthDate = DateTime.Parse("1985-01-10"), Department = new Department() { Id = 2, Name = "Computer" } },
                    new Seller() { Name = "Marco Aurelio", Email = "marco.aurelio@teste.com", BaseSalary = 2500, BirthDate = DateTime.Parse("1989-07-11"), Department = new Department() { Id = 1, Name = "Eletronics" } },
                    new Seller() { Name = "Ricardo Alves", Email = "ricardo.alves@teste.com", BaseSalary = 1000, BirthDate = DateTime.Parse("1992-01-20"), Department = new Department() { Id = 3, Name = "Books" } },
                };

                _context.Set<Seller>().AddRange(sellers);
                _context.SaveChanges();
            }

            if (!_context.Set<SalesRecord>().Any())
            {
                var salesRecords = new List<SalesRecord>()
                {
                    new SalesRecord() { Amount = 7000, Date = DateTime.Parse("2020-11-18"), Status = SaleStatus.BILLED, Seller = new Seller() { Name = "Richard Marchel", Email = "richard.marchel@teste.com", BaseSalary = 3000, BirthDate = DateTime.Parse("1985-01-10"), Department = new Department() { Id = 2, Name = "Computer" } } },
                    new SalesRecord() { Amount = 3000, Date = DateTime.Parse("2020-10-20"), Status = SaleStatus.PENDING, Seller = new Seller() { Name = "Marco Aurelio", Email = "marco.aurelio@teste.com", BaseSalary = 2500, BirthDate = DateTime.Parse("1989-07-11"), Department = new Department() { Id = 1, Name = "Eletronics" } } },
                    new SalesRecord() { Amount = 2500, Date = DateTime.Parse("2020-09-30"), Status = SaleStatus.CANCELED, Seller = new Seller() { Name = "Ricardo Alves", Email = "ricardo.alves@teste.com", BaseSalary = 1000, BirthDate = DateTime.Parse("1992-01-20"), Department = new Department() { Id = 3, Name = "Books" } } }
                };

                _context.Set<SalesRecord>().AddRange(salesRecords);
                _context.SaveChanges();
            }
        }

    }
}
