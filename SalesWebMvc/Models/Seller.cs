using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        // Instanciando a lista.
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord salesRecord)
        {
            Sales.Add(salesRecord);
        }

        public void RemoveSales(SalesRecord salesRecord)
        {
            Sales.Remove(salesRecord);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {

            /*
             * Usamos o Where que é uma função dá expressão linq e nele,
             * passamos uma expressão lambida para filtrar o período e aí sim
             * realizar a soma.
            */
            return Sales.Where(salesRecord => salesRecord.Date >= initial 
                                && salesRecord.Date <= final)
                                    .Sum(sr => sr.Amount);
        }
    }
}
