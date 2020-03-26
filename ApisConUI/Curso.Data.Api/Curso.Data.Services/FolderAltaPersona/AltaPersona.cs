using Curso.Common.DTO;
using Curso.Model.Context;
using Curso.Model.Model;
using System;
using System.Collections.Generic;
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
        
        public async Task CargarPersona(PersonaTablaDTO persona)
        {
            Person personaAgregar = new Person();
            personaAgregar.Name = persona.NombreAlta;
            personaAgregar.SurName = persona.ApellidoAlta;
            personaAgregar.DNI = persona.DniAlta;

            await _cursoContext.Persons.AddAsync(personaAgregar);
            _cursoContext.SaveChanges();
        }
    }
}
