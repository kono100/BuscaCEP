using BuscaCEP.Models;
using BuscaCEP.Service;
using Microsoft.AspNetCore.Mvc;

namespace BuscaCEP.Controllers
{
    public class CepController : Controller
    {

        public readonly CorreiosService _correiosService;

        public CepController(CorreiosService correiosService)
        {
            _correiosService = correiosService;
        }
        [HttpPost]
        public async Task<IActionResult> BuscarEnderecoPorCep(string cep)
        {
            Endereco? endereco = await _correiosService.BuscarEnderecoPorCep(cep);
            if (endereco == null)
            {
                TempData["Mensagem"] = "CEP <strong> Não </strong> encontrado";
            }
            return View("Index", endereco);
        }
    }
}
