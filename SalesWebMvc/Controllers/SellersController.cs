using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        // Mudando para assíncrono.
        public async Task<IActionResult> Index()
        {
            // Passando o meu método para ser chamado no index.
            var list = await _sellerService.FindAllAsync();

            // Passando a lista para ser mostrada na view.
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            // Buscando todos os departamentos.
            var departaments = await _departmentService.FindAllAsync();

            /*
             * Passando os departamentos para o nossa view
             * models que conterá os nossos departamentos.
            */
            var viewModel = new SellerFormViewModel { Departments = departaments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Para preveni ataques de (XSRF/CSRF).
        // Mudando para o método assíncrono.
        public async Task<IActionResult> Create(Seller seller)
        {
            // Teste para verificar se o Seller passou na validação.
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            };

            await _sellerService.InsertAsync(seller);

            /*
             * Para melhorar a manutenção do codgo, usamos nameof.
             * Assim caso eu mude o Index, eu só preciso mudar em um único lugar.
            */
            return RedirectToAction(nameof(Index));
        }

        // Ao passar o ? junto do parâmetro, o mesmo se torna opcional.
        // Método de alerta de deleção.
        // Mudando para o modo assíncrono.
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                // Passando um error personalizado.
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            }

            // Como usamos o ? essa variavel vira um nullable.
            var obj = await _sellerService.FindByIdAsync(id.Value);

            if (obj == null)
            {

                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);

        }

        // Método que de fato irá fazer a deleção.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Mudando para o modo assíncrono
        public async Task<IActionResult> Delete(int id)
        {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {

                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            // Como usamos o ? essa variavel vira um nullable.
            var obj = await _sellerService.FindByIdAsync(id.Value);

            if (obj == null)
            {

                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);


        }

        // Método que vai fazer a atualização do meu vendedor.
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {

                return RedirectToAction(nameof(Error), new { message = "Id nor provided" });
            }

            var seller = await _sellerService.FindByIdAsync(id.Value);

            if (seller == null)
            {

                return RedirectToAction(nameof(Error), new { message = "Id nor found" });
            }

            // Caso passe em tudo, ele vai mostrar uma lista de departamento
            List<Department> departments = await _departmentService.FindAllAsync();

            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
            return View(viewModel);

        }

        // Metódo de edição do vendedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            // Teste para verificar se o Seller passou na validação.
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            };

            // Caso de dar algum erro com o meu id na url.
            if (id != seller.Id)
            {
                // badrequest
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }

            // Passando o Bloco try porque possa ser que dê algum erro no meu DB
            try
            {

                await _sellerService.UpdateAsync(seller);
                return RedirectToAction(nameof(Index));

            }
            catch (NotFoundException error)
            {
                return RedirectToAction(nameof(Error), new { message = error });
            }
            catch (DbConcurrencyException error)
            {
                return RedirectToAction(nameof(Error), new { message = error });
            }

        }

        // Método que vai retornar o meus error personalizados.
        public IActionResult Error(string message)
        {
            // Instanciando a class de erro do frameWork
            var viewModel = new ErrorViewModel
            {
                Message = message,
                // Passando o id do erro. Esse erro é os erros padrões do sistema.
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);

        }

    }
}
