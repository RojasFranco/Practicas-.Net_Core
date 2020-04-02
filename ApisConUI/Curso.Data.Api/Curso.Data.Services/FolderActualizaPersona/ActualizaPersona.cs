using Curso.Model.Context;
using Curso.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Data.Services.FolderActualizaPersona
{
    public class ActualizaPersona : IActualizaPersona
    {
        private readonly CursoContext _cursoContext;
        public ActualizaPersona(CursoContext cursoContext)
        {
            _cursoContext = cursoContext;
        }

        public async Task<bool> ActualizarPersona(Person personaActualizar)
        {
            var dbUser = await _cursoContext.Persons.Where(x => x.DNI == personaActualizar.DNI).FirstOrDefaultAsync();

            if (dbUser == null)
            {
                return false;
            }
            dbUser.Name = personaActualizar.Name;
            dbUser.SurName = personaActualizar.SurName;
            //_cursoContext.Persons.Update(dbUser);
            await _cursoContext.SaveChangesAsync();
            return true;
        }
    }
}
