using Curso.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Data.Services.FolderBajaPersona
{
    public class BajaPersona : IBajaPersona
    {
        private readonly CursoContext _cursoContext;
        public BajaPersona(CursoContext cursoContext)
        {
            _cursoContext = cursoContext;
        }
        
        public async Task<bool> BorrarPersona(long dniAEliminar)
        {
            var dbUser = await _cursoContext.Persons.Where(x => x.DNI == dniAEliminar).FirstOrDefaultAsync();
            
            if(dbUser==null)
            {
                return false;
            }
            _cursoContext.Remove(dbUser);
            await _cursoContext.SaveChangesAsync();

            return true;            
        }
    }
}
