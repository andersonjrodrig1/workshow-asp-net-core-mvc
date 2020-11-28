﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; }

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department, int? departmentId)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
            DepartmentId = departmentId;
            Sales = new List<SalesRecord>();
        }

        public void AddSales(SalesRecord salesRecord) => Sales.Add(salesRecord);

        public void RemoveSales(SalesRecord salesRecord) => Sales.Remove(salesRecord);

        public double TotalSales(DateTime initial, DateTime final) => Sales.Where(x => x.Date >= initial && x.Date <= final)
                                                                           .Select(x => x.Amount)
                                                                           .DefaultIfEmpty(0.0)
                                                                           .Sum();
    }
}