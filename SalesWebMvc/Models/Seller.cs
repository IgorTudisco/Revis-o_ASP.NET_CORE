using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Usado para configuração de dados. No caso a escolhida foi de mostrar somente a data.
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Usado para mudar o nome direto na interface de todo o programa.
        [Display(Name = "Birth Date")]
        /*
         * Usado para configuração de dados.
         * No caso a escolhida foi de mostrar somente a data.
        */
        [DataType(DataType.Date)]
        // Usado para configurar o formato da data.
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        // Usado para mudar o nome direto na interface de todo o programa.
        [Display(Name = "Base Salary")]
        // Usado para formatar o número com duas casa decimais.
        [DisplayFormat(DataFormatString = "{0:F2}")]
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
