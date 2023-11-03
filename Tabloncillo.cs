using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BINGO
{
    internal class Tabloncillo
    {
        public int[,] tablero = new int[5, 5];
        public string[] nombre;

        public Tabloncillo(int[,] tablero, string[] nombre)
        {
            this.tablero = tablero;
            this.nombre = nombre;
        }

    }
}
