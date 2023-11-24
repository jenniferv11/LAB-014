using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_014
{
    public class pantalla
    {
        public static int[] edad = new int[100];
        public static int[] votoobtenido = new int[100];
        public static int contador = 0;

        public static int pantallaPrincipal()
        {
            string texto = "================================\n" +
                   "Encuesta Covid-19\n" +
                   "================================\n" +
                   "1: Realizar Encuesta\n" +
                   "2: Mostrar Datos de la encuesta\n" +
                   "3: Mostrar Resultados\n" +
                   "4: Buscar Personas por edad\n" +
                   "5: Salir\n" +
                   "================================\n";
            Console.Write(texto);
            return operaciones.getEntero("Ingrese una opción: ", texto);
        }

        public static int getEncuesta()
        {
            string texto = " ================================\n" +
                "Encuesta de vacunación\n" +
                "================================\n";
            Console.Write(texto);
            int EDAD = operaciones.getENTERO("¿Qué edad tienes?: ");
            if (contador == 1000)
            {
                Console.WriteLine("La lista ya esta completa");
            }
            else
            {
                string texto2 = "Te has vacunado\n" +
                "1: Sí\n" +
                "2: No\n" +
                "================================\n";
                Console.Write(texto2);
                int votacion;
                do
                {
                    votacion = operaciones.getENTERO("Ingrese una opción: ");

                    if (votacion != 1 && votacion != 2)
                    {
                        Console.WriteLine("Ingresa una opción valida");
                    }

                } while (votacion != 1 && votacion != 2);

                edad[contador] = EDAD;
                votoobtenido[contador] = votacion;
                contador++;
            }
            Console.Clear();
            return mensajeDeEncuesta();
        }
        public static int mensajeDeEncuesta()
        {
            string texto = " ================================\n" +
                "Encuesta de vacunación\n" +
                "================================\n" +
                " \n" +
                " \n" +
                "¡Gracias por participar!\n" +
                " \n" +
                " \n" +
                "================================\n" +
                "1: Regresar al menú\n" +
                "================================\n";
            Console.Write(texto);
            int opcion = operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;
        }
        public static int getDatos()
        {
            string texto = "================================\n" +
              "Datos de la encuesta\n" +
              "================================\n" +
              " \n" +
              "  ID |\tEdad |\tVacunado\n" +
              "================================\n";
            Console.Write(texto);

            if (contador == 0)
            {
                Console.WriteLine("No se han encontrado datos.");
            }
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"{i.ToString("D4")} | {edad[i].ToString().PadLeft(4)}  | {(votoobtenido[i] == 1 ? "Si" : "No").PadRight(2)}");
            }

            string texto2 = "================================\n" +
              "1: Regresar\n" +
              "================================\n";
            Console.Write(texto2);

            int opcion = operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;
        }
        public static int getResultados()
        {
            string texto = "================================\n" +
              "Resultados de la encuesta\n" +
              "================================\n";
            Console.Write(texto);

            int[] conteoOpcion = new int[3];
            int[] conteoEdad = new int[7];

            for (int i = 0; i < contador; i++)
            {
                int OPCION = votoobtenido[i];
                conteoOpcion[OPCION]++;

                int edad = pantalla.edad[i];

                if (edad >= 1 && edad <= 20)
                {
                    conteoEdad[1]++;
                }
                else if (edad >= 21 && edad <= 30)
                {
                    conteoEdad[2]++;
                }
                else if (edad >= 31 && edad <= 40)
                {
                    conteoEdad[3]++;
                }
                else if (edad >= 41 && edad <= 50)
                {
                    conteoEdad[4]++;
                }
                else if (edad >= 51 && edad <= 60)
                {
                    conteoEdad[5]++;
                }
                else if (edad > 60)
                {
                    conteoEdad[6]++;
                }
            }
            string texto2 = $"{conteoOpcion[1]} personas se han vacunado\n" +
              $"{conteoOpcion[2]} personas no se han vacunado\n" +
              " \n" +
              "Existen:\n" +
              $"{conteoEdad[1]} personas entre 01 y 20 años\n" +
              $"{conteoEdad[2]} personas entre 21 y 30 años\n" +
              $"{conteoEdad[3]} personas entre 31 y 40 años\n" +
              $"{conteoEdad[4]} personas entre 41 y 50 años\n" +
              $"{conteoEdad[5]} personas entre 51 y 60 años\n" +
              $"{conteoEdad[6]} personas de más de 61 años\n" +
              "================================\n" +
              "1: Regresar\n" +
              "================================\n";
            Console.Write(texto2);
            int opcion = operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;
        }
        public static int buscarPersona()
        {
            string texto = "================================\n" +
              "Busca a personas por edad\n" +
              "================================\n";
            Console.Write(texto);

            int valorBuscar = operaciones.getENTERO("¿Qué edad quieres buscar?: ");
            int vacunados = 0;
            int nroVacunados = 0;
            bool numeroEncontrado = false;

            for (int i = 0; i < contador; i++)
            {
                if (valorBuscar == edad[i])
                {
                    if (votoobtenido[i] == 1)
                    {
                        vacunados++;
                    }
                    else if (votoobtenido[i] == 2)
                    {
                        nroVacunados++;
                    }
                    numeroEncontrado = true;
                }
            }
            if (!numeroEncontrado)
            {
                Console.WriteLine("\nEl número ingresado no existe");
            }
            else
            {
                Console.WriteLine("\n" + vacunados + " se vacunaron");
                Console.WriteLine(nroVacunados + " no se vacunaron");
            }
            string texto2 = " \n" +
              "================================\n" +
              "1: Regresar\n" +
              "================================\n";
            Console.Write(texto2);
            int opcion = operaciones.getEntero("Ingrese una opción: ", texto);
            if (opcion == 1) return 0;
            return opcion;
        }
    }
}
 
