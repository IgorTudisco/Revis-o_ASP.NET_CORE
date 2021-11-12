using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public List<Department> FindAll()
        {

            return _context.Department.OrderBy(by => by.Name).ToList();

        }

    }
}
