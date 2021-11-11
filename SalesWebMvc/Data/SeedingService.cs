using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        /*
         * Tipo que permite ter acesso aos objs.
        */
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        // Método que irá popular minha base de dados.
        public void Seed()
        {
            /*
             * Esse if vai verificar se já tem algum dado no meu DB.
             * Se tiver ele quebra meu método, se não ele continua.
             * 
             * Ele faz essa verificação usando o método Any do Linq.
            */
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                // O banco de dados já foi populado
                return;
            }

            // Instanciando os obj(Department, Seller e SalesRecord)

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            // No caso do DateTime ao passa a Data, temos que intanciar novamente esse dado.

            Seller s1 = new Seller(1, "Bob Brow", "bob@gmail.com", new DateTime(1994, 4, 21), 1000.00, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1984, 8, 28), 1800.00, d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1974, 8, 1), 1088.00, d3);
            Seller s4 = new Seller(4, "Martha Red ", "martha@gmail.com", new DateTime(1997, 7, 7), 7000.00, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(1995, 5, 2), 1000.00, d1);
            Seller s6 = new Seller(6, "Yuri A.T.", "yuri@gmail.com", new DateTime(1994, 4, 4), 4400.00, d2);
            Seller s7 = new Seller(7, "Amanda Rosa", "amanda@gmail.com", new DateTime(1992, 2, 4), 1222.00, d3);

            // No caso do SalesRecord, temos que importar os Enums.

            SalesRecord r1 = new SalesRecord(1, new DateTime(2020, 01, 02), 11000.00, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2020, 02, 04), 11300.00, SaleStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2020, 02, 05), 11400.00, SaleStatus.Billed, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2020, 03, 22), 11500.00, SaleStatus.Billed, s4);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2020, 03, 02), 11600.00, SaleStatus.Billed, s5);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2020, 04, 21), 11700.00, SaleStatus.Billed, s6);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2020, 05, 30), 11800.00, SaleStatus.Billed, s7);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2020, 05, 22), 11800.00, SaleStatus.Billed, s1);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2020, 06, 11), 11900.00, SaleStatus.Billed, s2);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2020, 07, 21), 13000.00, SaleStatus.Billed, s3);
            SalesRecord r11 = new SalesRecord(11, new DateTime(2020, 07, 11), 11000.00, SaleStatus.Billed, s4);
            SalesRecord r12 = new SalesRecord(12, new DateTime(2020, 08, 16), 12000.00, SaleStatus.Billed, s5);
            SalesRecord r13 = new SalesRecord(13, new DateTime(2020, 08, 15), 16000.00, SaleStatus.Billed, s6);
            SalesRecord r14 = new SalesRecord(14, new DateTime(2020, 08, 13), 17000.00, SaleStatus.Billed, s7);
            SalesRecord r15 = new SalesRecord(15, new DateTime(2020, 08, 13), 18000.00, SaleStatus.Billed, s1);
            SalesRecord r16 = new SalesRecord(16, new DateTime(2020, 08, 25), 18000.00, SaleStatus.Billed, s2);
            SalesRecord r17 = new SalesRecord(17, new DateTime(2020, 08, 25), 18000.00, SaleStatus.Billed, s3);
            SalesRecord r18 = new SalesRecord(18, new DateTime(2020, 08, 24), 18000.00, SaleStatus.Billed, s4);
            SalesRecord r19 = new SalesRecord(19, new DateTime(2020, 08, 23), 18000.00, SaleStatus.Billed, s5);
            SalesRecord r20 = new SalesRecord(20, new DateTime(2020, 08, 23), 18000.00, SaleStatus.Billed, s6);
            SalesRecord r21 = new SalesRecord(21, new DateTime(2020, 08, 26), 19000.00, SaleStatus.Billed, s7);
            SalesRecord r22 = new SalesRecord(22, new DateTime(2020, 08, 27), 11200.00, SaleStatus.Billed, s1);
            SalesRecord r23 = new SalesRecord(23, new DateTime(2020, 08, 28), 11020.00, SaleStatus.Billed, s2);
            SalesRecord r24 = new SalesRecord(24, new DateTime(2020, 08, 29), 11002.00, SaleStatus.Billed, s3);
            SalesRecord r25 = new SalesRecord(25, new DateTime(2020, 08, 30), 11020.00, SaleStatus.Billed, s4);
            SalesRecord r26 = new SalesRecord(26, new DateTime(2020, 08, 30), 11020.00, SaleStatus.Billed, s5);
            SalesRecord r27 = new SalesRecord(27, new DateTime(2020, 08, 30), 11110.00, SaleStatus.Billed, s6);
            SalesRecord r28 = new SalesRecord(28, new DateTime(2020, 08, 30), 11020.00, SaleStatus.Billed, s7);
            SalesRecord r29 = new SalesRecord(29, new DateTime(2020, 08, 30), 11040.00, SaleStatus.Billed, s1);
            SalesRecord r30 = new SalesRecord(30, new DateTime(2020, 09, 03), 11080.00, SaleStatus.Billed, s2);

            // Add os objs no banco de dados.

            // Ao ussar o AddRange, eu posso add vários objs de uma só vez.
            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6, s7);

            _context.SalesRecord.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30);

            // Usando o SaveChanges do Linq, conseguimos salvar as alterações no DB.

            _context.SaveChanges();

        }

    }
}
