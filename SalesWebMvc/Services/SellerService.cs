using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _dbContext;

        public SellerService(SalesWebMvcContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Seller> FindAll() => _dbContext.Set<Seller>().Include(x => x.Department).ToList();

        public Seller InsertSeller(Seller seller)
        {
            _dbContext.Add(seller);
            SaveChanges();

            return seller;
        }

        public void UpdateSeller(Seller seller)
        {
            _dbContext.Update(seller);
            SaveChanges();
        }

        public Seller FindById(int id) => _dbContext.Set<Seller>().Include(x => x.Department).FirstOrDefault(x => x.Id == id);

        public void Remove(int id)
        {
            var seller = FindById(id);

            _dbContext.Set<Seller>().Remove(seller);
            SaveChanges();
        }

        public SellerFormViewModel GetSellerById(int id)
        {
            var departments = _dbContext.Set<Department>().AsQueryable().AsNoTracking().ToList();
            var seller = _dbContext.Set<Seller>().AsQueryable().AsNoTracking().FirstOrDefault(x => x.Id == id);

            return new SellerFormViewModel()
            {
                Seller = seller,
                Departments = departments
            };
        }

        private void SaveChanges() => _dbContext.SaveChanges(true);
    }
}
