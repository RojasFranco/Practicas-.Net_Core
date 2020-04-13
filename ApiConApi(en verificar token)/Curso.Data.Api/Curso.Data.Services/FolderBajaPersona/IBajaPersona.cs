using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Data.Services.FolderBajaPersona
{
    public interface IBajaPersona
    {
        Task<bool> BorrarPersona(long dniAEliminar);
    }
}
