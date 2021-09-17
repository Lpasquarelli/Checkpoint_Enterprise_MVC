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

        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            var retorno = _service.GetAll();

            if (retorno == null)
                return NotFound();

            return Ok(retorno);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
