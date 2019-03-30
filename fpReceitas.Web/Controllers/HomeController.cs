using fpReceitas.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace fpReceitas.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Boletos()
        {

            var boletos = new ViewModelBoleto();
            boletos.Boletos = new System.Collections.Generic.List<Boleto>();
            boletos.Boletos.Add(new Boleto() { Id = 1, Remover = false });
            boletos.Boletos.Add(new Boleto() { Id = 3, Remover = false });
            boletos.Boletos.Add(new Boleto() { Id = 5, Remover = false });
            return View(boletos);
        }
        [HttpPost]
        public IActionResult Boletos(ViewModelBoleto modelBoleto)
        {
            var a = modelBoleto;
            var boletos = new ViewModelBoleto();
            boletos.Boletos = new System.Collections.Generic.List<Boleto>();
            boletos.Boletos.Add(new Boleto() { Id = 1, Remover = false });
            boletos.Boletos.Add(new Boleto() { Id = 3, Remover = false });
            boletos.Boletos.Add(new Boleto() { Id = 5, Remover = false });
            return View(boletos);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Redirects(string redirectUrl)
        {
            //return Redirect(redirectUrl);
            //return LocalRedirect(redirectUrl);

            if (Url.IsLocalUrl(redirectUrl))
            {
                return Redirect(redirectUrl);
            }

            return Redirect("/");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
