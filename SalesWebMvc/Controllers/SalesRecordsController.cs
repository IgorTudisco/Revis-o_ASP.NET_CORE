using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordsService;

        public SalesRecordsController(SalesRecordService salesRecords)
        {
            _salesRecordsService = salesRecords;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Mudando para assíncrono e colocando os parâmetros
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            // Passando um valor mínino caso a Data mínima veia em branco.
            if (!minDate.HasValue)
            {
                // A função vai pegar o ano atual e o dia e o mês passados.
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            // Passando um valor mínino caso a Data máxima veia em branco.
            if (!maxDate.HasValue)
            {
                // A função vai pegar a data atual.
                maxDate = DateTime.Now;
            }

            // Passando a minha data para o meu view no valor atual.
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            // Passando a ação de busca.
            var result = await _salesRecordsService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }

    }
}
