using Curso.Common.DTO;
using Curso.Model.Context;
using Curso.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Data.Services.FolderAltaPersona
{
    public class AltaPersona : IAltaPersona
    {
        private readonly CursoContext _cursoContext;
        public AltaPersona(CursoContext cursoContext)
        {
            _cursoContext = cursoContext;
        }
        
        public async Task<PersonaTablaDTO> CargarPersona(PersonaTablaDTO persona)
        {
            var dniEnTabla = this._cursoContext.Persons.Where(x => x.DNI == persona.DniAlta).FirstOrDefault();

            if (dniEnTabla != null)
            {
                return null;
            }

            Person personaAgregar = new Person();
            personaAgregar.Name = persona.NombreAlta;
            personaAgregar.SurName = persona.ApellidoAlta;
            personaAgregar.DNI = persona.DniAlta;

            await _cursoContext.Persons.AddAsync(personaAgregar);
            await _cursoContext.SaveChangesAsync();
            return persona;
        }
    }
}
