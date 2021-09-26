using CheckpointDigital.Models;
using CheckpointDigital.Services.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CheckpointDigital.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioServices _service;
        public HomeController(ILogger<HomeController> logger, IUsuarioServices service)
        {
            _logger = logger;
            _service = service;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult Listar()
        {
            var retorno = GetAll();
            return View(retorno);
        }
        public ActionResult Editar(int id)
        {
            var user = _service.GetByID(id);

            if (user == null)
                return null;


            return View(user);
        }

        public ActionResult Update(Usuario usuario)
        {
            var user = _service.Update(usuario);

            if (user == null)
                return null;


            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult<Usuario> Cadastrar(Usuario usuario)
        {
            ViewData["nome"] = usuario.nome;
            ViewBag.data = usuario.dtNascimento;
            TempData["msg"] = "Usuario Registrado!";

            var retorno = _service.Create(usuario);
            return View(retorno);
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            var retorno = _service.GetAll();

            if (retorno == null)
                return null;


            return retorno;
        }

        [HttpGet]
        public IActionResult Apagar(int id)
        {
            _service.Delete(id);

            return RedirectToAction("Listar");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
