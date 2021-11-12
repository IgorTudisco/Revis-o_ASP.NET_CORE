using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
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

        // Passando uma dependencia do DepartmentService
        public DepartmentService _departmentService { get; set; }

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            // Passando o meu método para ser chamado no index.
            var list = _sellerService.FindAll();

            // Passando a lista para ser mostrada na view.
            return View(list);
        }

        public IActionResult Create()
        {
            // Buscando todos os departamentos.
            var departaments = _departmentService.FindAll();

            /*
             * Passando os departamentos para o nossa view
             * models que conterá os nossos departamentos.
            */
            var viewModel = new SellerFormViewModel { Departments = departaments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Para preveni ataques de (XSRF/CSRF).
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);

            /*
             * Para melhorar a manutenção do codgo, usamos nameof.
             * Assim caso eu mude o Index, eu só preciso mudar em um único lugar.
            */
            return RedirectToAction(nameof(Index));
        }

        // Ao passar o ? junto do parâmetro, o mesmo se torna opcional.
        // Método de alerta de deleção.
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {

                return NotFound();

            }

            // Como usamos o ? essa variavel vira um nullable.
            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
            {

                return NotFound();

            }

            return View(obj);

        }

        // Método que de fato irá fazer a deleção.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));

        }

    }
}
