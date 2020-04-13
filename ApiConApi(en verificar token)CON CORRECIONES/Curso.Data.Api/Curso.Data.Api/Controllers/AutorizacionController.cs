using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Common.DTO;
using Curso.Data.Services.FolderAutorizacion;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using RestSharp;

namespace Curso.Data.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_CURSO_")]
    public class AutorizacionController : ControllerBase
    {
        private readonly ILogger<AutorizacionController> _logger;
        private readonly IAutorizando _autorizacion;        

        public AutorizacionController(ILogger<AutorizacionController> logger, IAutorizando autorizacion)
        {
            _logger = logger;
            _logger.LogInformation("Constructor AutorizacionController");
            _autorizacion = autorizacion;
        }

        [HttpPost("Validacion/{tokenValidar}")]
        public ActionResult Validacion(string tokenValidar)
        {
            IRestResponse respuesta = _autorizacion.TestApi(tokenValidar);

            JavaScriptSerializer deserealizer = new JavaScriptSerializer();
            bool respuestaDeserealizada = deserealizer.Deserialize<bool>(respuesta.Content);
            if (respuestaDeserealizada)
            {
                return Ok(new ResultJson() { Message = "Token validado, sesion abierta"});
            }
            else
            {
                return Unauthorized(new ResultJson() { Message = "Token no valido o activo" });
            }

        }

    }
}