using System;
using System.Linq;
using System.Threading.Channels;

namespace ConsoleAppEjercicio79
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantidadVelocidades;
            bool seguir = true;
            do
            {
                Console.Write("Ingrese la cantidad de velocidades:");
                if (!int.TryParse(Console.ReadLine(),out cantidadVelocidades))
                {
                    seguir = true;
                    Console.WriteLine("Error al ingresar la cantidad de velocidades");
                }
                else
                {
                    seguir = false;
                }
            } while (seguir);

            int[] velocidades = new int[cantidadVelocidades];

            LlenarVector(velocidades);
            MostrarVelocidades(velocidades);
            int velocidadMaxima = HallarVelocidadMaxima(velocidades);
            int velMaxima = MaximaAlternativa(velocidades);

            int velocidadMinima = HallarVelocidadMinima(velocidades);
            int velMinima = MinimaAlternativa(velocidades);

            double promedio = HallarPromedioVelocidades(velocidades);
            double promedioLinq = HallarPromedioAlternativo(velocidades);

            Console.WriteLine($"Máxima Velocidad: {velocidadMaxima}");
            Console.WriteLine($"Máxima Velocidad: {velMaxima}");
            Console.WriteLine($"Minima Velocidad: {velocidadMinima}");
            Console.WriteLine($"Minima Velocidad: {velMinima}");
            Console.WriteLine($"Promedio Velocidad: {promedio}");
            Console.WriteLine($"Promedio Velocidad: {promedioLinq}");

            MarcarVelocidadesSuperioresAlPromedio(velocidades,promedio);

            var menoresPromedio = CalcularVelocidadesMenoresAlPromedio(velocidades, promedio);

            Console.WriteLine($"Cantidad de menores al promedio: {menoresPromedio}");
            Console.ReadLine();

        }

        private static int CalcularVelocidadesMenoresAlPromedio(int[] vector, double promedio)
        {
            int cantidad = 0;
            foreach (var elemento in vector)
            {
                if (elemento<promedio)
                {
                    cantidad++;
                }
            }

            return cantidad;
        }

        private static void MarcarVelocidadesSuperioresAlPromedio(int[] vector,double promedio)
        {
            Console.Clear();
            Console.WriteLine("Listado de Velocidades ");
            Console.WriteLine($"Promedio de Velocidad:{promedio}");
            foreach (var velocidad in vector)
            {
                if (velocidad>promedio)
                {
                    Console.WriteLine($"{velocidad}*");
                }
                else
                {
                    Console.WriteLine($"{velocidad}");
                }
            }

        }

        private static double HallarPromedioAlternativo(int[] vector) => vector.Average();
        

        private static double HallarPromedioVelocidades(int[] vector)
        {
            var promedio = 0;
            for (int aux = 0; aux < vector.Length; aux++)
            {
                promedio += vector[aux];
            }

            return promedio /(double) vector.Length;
        }

        private static int MinimaAlternativa(int[] vector) => vector.Min();

        private static int HallarVelocidadMinima(int[] vector)
        {
            int minima = 301;
            foreach (var velocidad in vector)
            {
                if (velocidad <minima)
                {
                    minima = velocidad;
                }
            }

            return minima;
        }

        private static int MaximaAlternativa(int[] vector)
        {
            return vector.Max();
        }

        private static int HallarVelocidadMaxima(int[] vector)
        {
            int maxima = -1;
            foreach (var velocidad in vector)
            {
                if (velocidad>maxima)
                {
                    maxima = velocidad;
                }
            }

            return maxima;
        }

        private static void MostrarVelocidades(int[] vector)
        {
            Console.Clear();
            Console.WriteLine("Lista de Velocidades en Km y Millas");
            foreach (var velocidad in vector)
            {
                var millas = ConvertirKmMillas(velocidad);
                Console.WriteLine($"{velocidad} - {millas}");
            }
        }

        private static double ConvertirKmMillas(int velocidad)
        {
            return velocidad / 1.609;
        }

        private static void LlenarVector(int[] vector)
        {
            int velocidad;
            bool seguir = true;
            for (int i = 0; i < vector.Length; i++)
            {
                //ciclo para ingresar la velocidad y la estoy validando
                do
                {
                    Console.Write($"Ingrese la velocidades del auto {i+1}:");
                    if (!int.TryParse(Console.ReadLine(), out velocidad))
                    {
                        seguir = true;
                        Console.WriteLine("Error al ingresar la velocidad");
                    }
                    else if(velocidad<100 || velocidad>300)
                    {
                        seguir = true;
                        Console.WriteLine("Velocidad fuera del rango permitido");

                    }
                    else
                    {
                        seguir = false;
                    }
                } while (seguir);
                //Asigno la velocidad en el vector en la posicion i
                vector[i] = velocidad;
            }

            Console.WriteLine("Proceso de llenado finalizado...ENTER para continuar");
            Console.ReadLine();
        }
    }
}
