using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

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
        // Mudando para o modo assíncrono.
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        // Add um novo Seller no DB.
        // Mudando para o modo assíncrono.
        public async Task InsertAsync(Seller seller)
        {

            _context.Add(seller);
            await _context.SaveChangesAsync();

        }

        /*
         * Método que vai retornar o Seller no id selecionado.
         * 
         * Mudando para o modo assíncrono.
        */
        public async Task<Seller> FindByIdAsync(int id)
        {
            /*
             * Para que ele faça um join das entidades e me
             * traga os departamentos eu preciso incluir o
             * Include(obj => obj.Department) do namespace: Microsoft.EntityFrameworkCore.
             * 
             * Chamado também de eager loading 
            */
            return await _context.Seller.Include(obj => obj.Department)
                .FirstOrDefaultAsync(seller => seller.Id == id);

        }

        // A implementação foi baseada no scaffold de Departamento
        // Mudando para o modo assíncrono.
        public async Task RemoveAsync(int id)
        {

            // Fazendo o tratamento de erro no nível de serviço.
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException error)
            {
                throw new IntegrityException(error.Message);
            }

        }

        // Método que vau atualizar os vendedores
        // Mudando para o modo assíncrono
        public async Task UpdateAsync(Seller seller)
        {
            /*
             * Verificando com o Any se tem algum item igual ao id passado.
             * Se não existir ele vai lançar um exceção.
            */
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == seller.Id);
            if (!hasAny)
            {
                // Lançamento personalizado.
                throw new NotFoundException("Id not found");

            }

            /*
             * Caso acontece algum erro de concorrência no DB
             * ela será tratada no bloco try.
            */
            try
            {

                _context.Update(seller);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException e)
            {
                // Relançando o erro dá minha camada de Serviço.
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}
