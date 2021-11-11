using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        // O readonly garante que essa depencencia não pode ser alterada.
        private readonly SalesWebMvcContext _context;

        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        // Método que retornará uma lista com os vendedores.
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        // Add um novo Seller no DB
        public void Insert(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

    }
}
