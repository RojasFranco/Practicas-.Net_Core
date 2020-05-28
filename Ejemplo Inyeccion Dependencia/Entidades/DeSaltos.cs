using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DeSaltos : IMovimientos
    {
        public string avanzar()
        {
            return "Avance saltando";
        }

        public string retroceder()
        {
            return "Retroceso saltando";
        }
    }
}
