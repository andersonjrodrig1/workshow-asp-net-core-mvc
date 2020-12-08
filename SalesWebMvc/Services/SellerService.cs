using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services.Exceptions;
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

        public async Task<IEnumerable<Seller>> FindAll() => await _dbContext.Set<Seller>().Include(x => x.Department).ToListAsync();

        public async Task<Seller> InsertSeller(Seller seller)
        {
            _dbContext.Add(seller);
            await SaveChangesAsync();

            return seller;
        }

        public async Task UpdateSeller(Seller seller)
        {
            _dbContext.Update(seller);
            await SaveChangesAsync();
        }

        public async Task<Seller> FindById(int id) => await _dbContext.Set<Seller>().Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);

        public async Task Remove(int id)
        {
            try
            {
                var seller = await FindById(id);

                _dbContext.Set<Seller>().Remove(seller);
                await SaveChangesAsync();
            }
            catch(DbUpdateException db)
            {
                throw new IntegrityException(db.Message);
            }
        }

        public async Task<SellerFormViewModel> GetSellerById(int id)
        {
            var departments = await _dbContext.Set<Department>().AsQueryable().AsNoTracking().ToListAsync();
            var seller = await _dbContext.Set<Seller>().AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return new SellerFormViewModel()
            {
                Seller = seller,
                Departments = departments
            };
        }

        private async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync(true);
    }
}
