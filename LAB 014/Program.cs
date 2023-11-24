using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB_014;

namespace LAB_014
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = pantalla.pantallaPrincipal();
            do
            {
                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        opcion = pantalla.getEncuesta();
                        break;
                    case 2:
                        opcion = pantalla.getDatos();
                        break;
                    case 3:
                        opcion = pantalla.getResultados();
                        break;
                    case 4:
                        opcion = pantalla.buscarPersona();
                        break;
                    case 0:
                    default:
                        opcion = pantalla.pantallaPrincipal();
                        break;
                }
            } while (opcion != 5);
        }
    }
}
