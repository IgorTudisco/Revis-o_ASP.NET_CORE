using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        // Usado para indicar que um item é obrigatório.
        // {0} pega o nome do atributo. {1} pega o máximo e o {2} o mínimo.
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        // Usado para configuração de dados. No caso a escolhida foi de mostrar somente a data.
        [DataType(DataType.EmailAddress)]
        // Verifica se é um email válido.
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
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

        [Required(ErrorMessage = "{0} required")]
        // O tamanho aceito pelo campo.
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
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
