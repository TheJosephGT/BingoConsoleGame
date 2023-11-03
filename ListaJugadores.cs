using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace BINGO
{
    internal class ListaJugadores
    {
        private Nodo cabeza;
        private Nodo cola;
        private int cont;
        private int[] tombola;
        private int temporal;

        public ListaJugadores()
        {
            tombola = new int[75];
            cabeza = cola = null;
            cont = 0;
            temporal = 0;

        }

        public bool EsVacio()
        {
            return cabeza == null;
        }

        public void AgregarPorCola(Tabloncillo valor)
        {
            Nodo nuevoNodo = new Nodo(valor);

            if (EsVacio())
            {
                cabeza = cola = nuevoNodo;
                CerrarCirculo();

            }
            else
            {
                cola.siguiente = nuevoNodo;
                cola = nuevoNodo;
                CerrarCirculo();


            }

        }

        public void CerrarCirculo()
        {
            cola.siguiente = cabeza;
        }

        public bool ComprobarTombola(int[] tombola, int num)
        {
            for (int i = 0; i < 75; i++)
            {
                if (num == tombola[i])
                {
                    return true;
                }
            }

            return false;
        }

        public int Tombola()
        {
            int num;
            Random r = new Random();
            

            num = r.Next(1, 76);
            while (ComprobarTombola(tombola, num) == true)
            {
                num = r.Next(1, 76);
            }
            tombola[cont] = num;
            cont++;
            return num;


        }

        public void Imprimir()
        {
            Nodo aux = cabeza;
            Nodo inicial = aux;
            int contador = 0;
            


            do
            {
                aux.datos.tablero[2, 2] = 0;
                Console.WriteLine("===================================================================================================================================================================================================================");
                Console.WriteLine($"-----------------------------------------------------------------------------------------------------JUGADOR {aux.datos.nombre[contador]}------------------------------------------------------------------------------------------------\n");
                Console.WriteLine("B \t I \t N \t G \t O");
                Console.WriteLine($"-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (aux.datos.tablero[i, j] == 0)
                        {
                            Console.Write("X\t ");
                        }
                        else
                        {
                            Console.Write($"{aux.datos.tablero[i, j]}\t ");
                        }
                        
                    }

                    Console.WriteLine("\n");
                }

                aux = aux.siguiente;
                contador++;
                

            } while (aux != inicial);
            Console.WriteLine("===================================================================================================================================================================================================================");
        }

        public bool ComprobarVerticalmente(int[,] tablero)
        {
            int contador = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 4; j >= 0; j--)
                {
                    if (tablero[j, i] == 0)
                    {
                        contador++;
                        if (contador == 5)
                        {
                            return true;
                        }
                    }

                }

                if (contador == 5)
                {
                    return true;
                }

                if (contador != 5)
                    contador = 0;
            }

            return false;
        }

        public bool ComprobarHorizontalmente(int[,] tablero)
        {
            int contador = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (tablero[i, j] == 0)
                    {
                        contador++;

                    }


                }

                if (contador == 5)
                {
                    return true;
                }

                if (contador != 5)
                    contador = 0;

            }

            return false;
        }

        public bool ComprobarDiagonales(int[,] tablero)
        {

            int contador = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == j)
                    {
                        if (tablero[i,j] == 0)
                        {
                            contador += 1;

                            if (contador == 5)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            contador = 0;

            for (int i = 0, j = 5 - 1; i < 5 && j >= 0; i++, j--)
            {

                if (tablero[i,j] == 0)
                {
                    contador += 1;

                    if (contador == 5)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Ganador()
        {
            Nodo aux = cabeza;
            Nodo inicial = aux;
            int contador = 0;

            do
            {
                if(ComprobarVerticalmente(aux.datos.tablero) == true || ComprobarHorizontalmente(aux.datos.tablero) == true
                    || ComprobarDiagonales(aux.datos.tablero) == true)
                {

                    Console.WriteLine($" !!!!! BINGO !!!!! - FELICITACIONES. EL JUGADOR {aux.datos.nombre[contador]} ha conseguido la victoria.");
                    Imprimir();
                    return true;
                }
                aux = aux.siguiente;
                contador++;

            } while (aux != inicial);
            return false;
        }

        public void Jugar()
        {
            //SoundPlayer sound = new SoundPlayer("cancion.wav");
            //sound.Play();
            do
            {
                Imprimir();
                CondicionesBINGO();

            } while (Ganador() == false);

        }

        private void CondicionesBINGO()
        {
            
            int numAleatorio = Tombola();

            
            
            if (numAleatorio <= 15)
            {
                Console.WriteLine($"El numero sacado de la TOMBOLA es: B - {numAleatorio}");
                Console.WriteLine($"Boleada numero: {temporal}");
                temporal++;
                Console.WriteLine("Presione ENTER para continuar: ");
                Console.ReadKey();
            }
            if (numAleatorio > 15 && numAleatorio <= 30)
            {
                Console.WriteLine($"El numero sacado de la TOMBOLA es: I - {numAleatorio}");
                Console.WriteLine($"Boleada numero: {temporal}");
                temporal++;
                Console.WriteLine("Presione ENTER para continuar: ");
                Console.ReadKey();
            }
            if (numAleatorio > 30 && numAleatorio <= 45)
            {
                Console.WriteLine($"El numero sacado de la TOMBOLA es: N - {numAleatorio}");
                Console.WriteLine($"Boleada numero: {temporal}");
                temporal++;
                Console.WriteLine("Presione ENTER para continuar: ");
                Console.ReadKey();
            }
            if (numAleatorio > 45 && numAleatorio <= 60)
            {
                Console.WriteLine($"El numero sacado de la TOMBOLA es: G - {numAleatorio}");
                Console.WriteLine($"Boleada numero: {temporal}");
                temporal++;
                Console.WriteLine("Presione ENTER para continuar: ");
                Console.ReadKey();
            }
            if (numAleatorio > 60 && numAleatorio <= 75)
            {
                Console.WriteLine($"El numero sacado de la TOMBOLA es: O - {numAleatorio}");
                Console.WriteLine($"Boleada numero: {temporal}");
                temporal++;
                Console.WriteLine("Presione ENTER para continuar: ");
                Console.ReadKey();
            }
            //Console.ReadKey();
            Console.Clear();
            TacharNumero(numAleatorio);


        }

        private void TacharNumero(int numAleatorio)
        {
            Nodo aux = cabeza;
            Nodo inicial = aux;

            do
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (numAleatorio == aux.datos.tablero[i, j])
                        {
                            aux.datos.tablero[i, j] = 0;
                        }
                    }
                }

                aux = aux.siguiente;

            } while (aux != inicial);
        }
    }
}


/*public void Imprimir()
        {
            Nodo aux = cabeza;
            Nodo inicial = aux;
            int contador = 0;
            


            do
            {
                aux.datos.tablero[2, 2] = 0;
                Console.WriteLine("===================================================================================================================================================================================================================");
                Console.WriteLine($"-----------------------------------------------------------------------------------------------------JUGADOR {aux.datos.nombre[contador]}------------------------------------------------------------------------------------------------\n");
                Console.WriteLine("B \t I \t N \t G \t O");
                Console.WriteLine($"-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write($"{aux.datos.tablero[i, j]}\t ");
                    }

                    Console.WriteLine("\n");
                }

                aux = aux.siguiente;
                contador++;
                

            } while (aux != inicial);
            Console.WriteLine("===================================================================================================================================================================================================================");
        }*/