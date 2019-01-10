using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuePerigo.Estoque.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Visualizar()
        {
            return View();
        }
    }
}