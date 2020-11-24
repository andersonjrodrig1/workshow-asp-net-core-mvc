using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
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
            _dbContext.SaveChanges();

            return seller;
        }
    }
}
