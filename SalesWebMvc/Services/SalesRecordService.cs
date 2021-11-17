using SalesWebMvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {

        // O readonly garante que essa depencencia não pode ser alterada.
        private readonly SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            // Essa função servirá de apoio para add mais funcionalidades a ela.
            var result = from sales in _context.SalesRecord select sales;

            // Verificando a data mínima.
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate);
            }

            // Verificando a data máxima
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate);
            }

            return await result
                // O X é do tipo SalesRecord.
                .Include(x => x.Seller) // Faz os join entre as tabelas.
                .Include(x => x.Seller.Department) // Join com o departamento.
                .OrderByDescending(x => x.Date) // Ordenando por Data.
                .ToListAsync();

        }

    }
}
