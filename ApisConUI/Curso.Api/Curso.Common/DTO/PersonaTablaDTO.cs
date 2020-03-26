using System;
using System.Collections.Generic;
using System.Text;

namespace Curso.Common.DTO
{
    public class PersonaTablaDTO
    {
        private string nombre;
        private string apellido;
        private long dni;

        public string NombreAlta { get => nombre; set => nombre = value; }
        public string ApellidoAlta { get => apellido; set => apellido = value; }
        public long DniAlta { get => dni; set => dni = value; }
    }
}
