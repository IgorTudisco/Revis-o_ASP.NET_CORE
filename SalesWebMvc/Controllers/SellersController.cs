using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        // Inserindo uma dependencia de SellerService.
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            // Passando o meu método para ser chamado no index.
            var list = _sellerService.FindAll();

            // Passando a lista para ser mostrada na view.
            return View(list);
        }



    }
}
