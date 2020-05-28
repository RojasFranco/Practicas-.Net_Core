using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Robot
    {
        private readonly IMovimientos movimientos;
        public Robot(IMovimientos movimientos)
        {
            this.movimientos = movimientos;
        }
        public string ParaAdelante()
        {
            return movimientos.avanzar();
        }

        public string ParaAtras()
        {
            return movimientos.retroceder();
        }
    }
}
