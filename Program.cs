using System.Media;

namespace BINGO
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("===================================================================================================================================================================================================================");
            Console.WriteLine("\r\n" +
                "\t\t\t\t\t\t\t\t\t\t\t██████╗░██╗███╗░░██╗░██████╗░░█████╗░\r\n" +
                "\t\t\t\t\t\t\t\t\t\t\t██╔══██╗██║████╗░██║██╔════╝░██╔══██╗\r\n" +
                "\t\t\t\t\t\t\t\t\t\t\t██████╦╝██║██╔██╗██║██║░░██╗░██║░░██║\r\n" +
                "\t\t\t\t\t\t\t\t\t\t\t██╔══██╗██║██║╚████║██║░░╚██╗██║░░██║\r\n" +
                "\t\t\t\t\t\t\t\t\t\t\t██████╦╝██║██║░╚███║╚██████╔╝╚█████╔╝\r\n" +
                "\t\t\t\t\t\t\t\t\t\t\t╚═════╝░╚═╝╚═╝░░╚══╝░╚═════╝░░╚════╝░\n\n");
            Console.WriteLine("===================================================================================================================================================================================================================");

            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\tPresione cualquier tecla para continuar: ");
            Console.ReadKey();
            Console.Clear();

            int cant = 0;
            do
            {
                Console.WriteLine("===================================================================================================================================================================================================================");
                Console.Write("\t\t\t\t\t\t\t\t\t\t\tIngrese la cantidad de jugadores que participaran: ");
                cant = int.Parse(Console.ReadLine());
                Console.WriteLine("===================================================================================================================================================================================================================");
                Console.Clear();
            } while (cant <= 0);

            int[,] array = new int[5,5];
            string[] nombres = new string[cant];
            Console.WriteLine("===================================================================================================================================================================================================================");
            for (int i = 0; i < cant; i++)
            {
                
                Console.Write($"\t\t\t\t\t\t\t\t\t\t\tIngrese el nombre del jugador #{i+1}: ");
                nombres[i] = Console.ReadLine();
            }
            Console.WriteLine("===================================================================================================================================================================================================================");
            Console.Clear();


            ListaJugadores jugador = new ListaJugadores();

            for (int i = 0; i < cant; i++)
            {
                RellenarArreglo(array);
                Tabloncillo datos = new Tabloncillo(array, nombres);
                jugador.AgregarPorCola(datos);
                array = new int[5, 5];
            }

            jugador.Jugar();



        }

        public static void RellenarArreglo(int[,] tablero)
        {


            Random r;
            r = new Random();

            int num;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {

                    //B
                    if (j == 0)
                    {

                        num = r.Next(1, 16);
                        while (ComprobarIgualdad(tablero, num) == true)
                        {
                            num = r.Next(1, 16);
                        }
                        tablero[i, j] = num;
                    }
                    //i
                    if (j == 1)
                    {
                        num = r.Next(16, 31);
                        while (ComprobarIgualdad(tablero, num) == true)
                        {
                            num = r.Next(16, 31);
                        }
                        tablero[i, j] = num;

                    }
                    //n
                    if (j == 2)
                    {
                        num = r.Next(31, 46);
                        while (ComprobarIgualdad(tablero, num) == true)
                        {
                            num = r.Next(31, 46);
                        }
                        tablero[i, j] = num;

                    }
                    //g
                    if (j == 3)
                    {
                        num = r.Next(46, 61);
                        while (ComprobarIgualdad(tablero, num) == true)
                        {
                            num = r.Next(46, 61);
                        }
                        tablero[i, j] = num;

                    }
                    //o
                    if (j == 4)
                    {
                        num = r.Next(61, 76);
                        while (ComprobarIgualdad(tablero, num) == true)
                        {
                            num = r.Next(61, 76);
                        }
                        tablero[i, j] = num;

                    }

                }
            }
        }

        public static bool ComprobarIgualdad(int[,] array, int num)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (num == array[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}