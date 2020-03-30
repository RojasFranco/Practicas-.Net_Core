using Curso.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Data.Services.FolderAltaPersona
{
    public interface IAltaPersona
    {
        Task<PersonaTablaDTO> CargarPersona(PersonaTablaDTO persona);
    }
}
