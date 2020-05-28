using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class De1Paso : IMovimientos
    {
        public string avanzar()
        {
            return "AVANZANDO DE A 1 PASO";
        }

        public string retroceder()
        {
            return "retrocediendo DE A 1 PASO";
        }
    }
}
