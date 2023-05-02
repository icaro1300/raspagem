using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raspagem.Base;
using Raspagem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Raspagem.Controllers
{
    public class HomeController : Controller
    {
        private readonly DAL_Cursos _cursosContext;
        public HomeController(DAL_Cursos cursosContext)
        {
            _cursosContext = cursosContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await _cursosContext.Preparar_Cursos();
            return View(_cursosContext.Pegar_Cursos());
        }
        [HttpPost]
        public IActionResult Curso(string pesquisa)
        {
            var curso = _cursosContext.Pegar_Curso(pesquisa);
            return curso is null ? RedirectToAction(nameof(Index)) : View(curso);
        }
    }
}
