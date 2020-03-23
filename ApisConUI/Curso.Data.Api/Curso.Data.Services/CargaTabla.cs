using Curso.Model.Context;
using Curso.Model.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Data.Services
{
    public class CargaTabla : ICargaTabla
    {
        //private readonly ILogger<CargaTabla> _logger;
        private readonly CursoContext _cursoContext;
        public CargaTabla(/*ILogger<CargaTabla> logger, */CursoContext cursoContext )
        {
            //this._logger = logger;
            //_logger.LogInformation("Constructor CargaTabla ");
            this._cursoContext = cursoContext;
        }
        
        public async Task<TablaJSON> CargarMiTabla()
        {
            TablaJSON retorno = new TablaJSON();

            retorno.Headers.Add("DNI");
            retorno.Headers.Add("NOMBRE");
            retorno.Headers.Add("APELLIDO");

            retorno.Rows = await _cursoContext.Persons.ToListAsync();

            return retorno;            
        }
    }
}
