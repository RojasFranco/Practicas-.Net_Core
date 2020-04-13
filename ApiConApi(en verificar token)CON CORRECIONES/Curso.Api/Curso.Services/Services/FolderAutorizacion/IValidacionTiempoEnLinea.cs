using Curso.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Services.Services.FolderAutorizacion
{
    public interface IValidacionTiempoEnLinea
    {
        Task<bool> VerificarTiempo(Guid? token);
    }
}
