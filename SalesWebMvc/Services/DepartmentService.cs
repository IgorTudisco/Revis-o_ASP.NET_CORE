using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {

        // O readonly garante que essa depencencia não pode ser alterada.
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        // Metodo que retorna uma lista de departamentos ordenado pelo nome.
        // Mudando o método para uma chamada assíncrona
        public async Task<List<Department>> FindAllAsync()
        {

            return await _context.Department.OrderBy(by => by.Name).ToListAsync();

        }

    }
}
