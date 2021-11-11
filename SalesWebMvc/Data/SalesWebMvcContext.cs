using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data
{
    public class SalesWebMvcContext : DbContext
    {
        public SalesWebMvcContext (DbContextOptions<SalesWebMvcContext> options)
            : base(options)
        {
        }

        /* 
         * Para que se entenda o modelo de dados, se faz necessário os métodos
         * de DbSet, para que ele implemente no Banco as minhas alterações e
         * relacionamentos. Com isso podemos fazer uma nova Migration para Add
         * essas alterações no banco.
         * 
         * Como o nome da class é o mesmo nome do caminho, podemos apagar o
         * a indicação.
        */
        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }

    }
}
