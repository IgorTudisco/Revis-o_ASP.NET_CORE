using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Department
    {

        public int Id { get; set; }
        public string Name { get; set; }

        // Garantindo que a lista seja instanciada.
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void addSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double totalSeller(DateTime initial, DateTime final)
        {
            /*
             * Usando a função sum da Linq para somar a quantidade de vendas em determinado
             * período de tempo.
             * No caso para reaproveitar o código, usamos a método que já tinhamos
             * criado na class Seller.
            */
            return Sellers.Sum(Seller => Seller.TotalSales(initial, final));
        }

    }
}
