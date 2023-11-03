using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BINGO
{
    internal class Nodo
    {
        public Tabloncillo datos;
        public Nodo siguiente;

        public Nodo(Tabloncillo datos)
        {
            this.datos = datos;
            siguiente = null;
        }
    }
}
