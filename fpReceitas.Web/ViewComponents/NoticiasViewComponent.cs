using fpReceitas.Core.Services;
using fpReceitas.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fpReceitas.Web.ViewComponents
{
    public class NoticiasViewComponent : ViewComponent
    {
        private NoticiaService _noticiaService;

        public NoticiasViewComponent(NoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }
        public async Task<IViewComponentResult> InvokeAsync(
            int total, bool noticiasUrgentes)
        {
            string view = "noticias";

            if (total > 3 && noticiasUrgentes == true)
            {
                view = "noticiasurgentes";
            }

            var items = _noticiaService.GetItens(total);
            return View(view, items);
        }

    }
}
