using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebasRepaso
{
    class Program
    {
        static void Main(string[] args)
        {

            De1Paso de1Paso = new De1Paso();
            Robot robot1 = new Robot(de1Paso);
            Console.WriteLine("ROBOT 1!----------------------------");
            Console.WriteLine(robot1.ParaAdelante());
            Console.WriteLine(robot1.ParaAtras());


            Console.WriteLine("ROBOT 2!----------------------------");
            DeSaltos deSaltos = new DeSaltos();
            Robot robot2 = new Robot(deSaltos);
            Console.WriteLine(robot2.ParaAdelante());
            Console.WriteLine(robot2.ParaAtras());

            Console.ReadKey();

        }
    }
}
