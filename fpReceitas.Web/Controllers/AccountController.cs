using fpReceitas.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace fpReceitas.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/receitas");
            }
            return View(new LoginViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            //acesso ao db
            if ((model.UserName == "admin das couve" && model.Password == "hubho")
                || (model.UserName == "ze das couve" && model.Password == "hubho"))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UserName)
                };

                if (model.UserName.Contains("admin"))
                {
                    claims.Add(new Claim(ClaimTypes.Role, "admin"));
                }

                var id = new ClaimsIdentity(claims, "password");
                var principal = new ClaimsPrincipal(id);
                await HttpContext.SignInAsync("admin", principal, new AuthenticationProperties { IsPersistent = model.IsPersistent });

                return Redirect("/receitas");
            }


            return View(model);
        }

        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }
    }
}