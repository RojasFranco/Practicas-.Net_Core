using Curso.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Data.Services.FolderActualizaPersona
{
    public interface IActualizaPersona
    {
        Task<bool> ActualizarPersona(Person personaActualizar);
    }
}
