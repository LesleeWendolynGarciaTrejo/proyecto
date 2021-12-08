using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto
{
    class Computadora : Jugador
    {
        private List<Carta> cartas;

        public Computadora(String nombre, int[] tablero) : base(nombre, tablero)
        {
            cartas = new List<Carta>();
        }

        public List<Carta> getCartas()
        {
            return this.cartas;
        }

        public void checarTablero(int cartaPasada)
        {
            foreach (Carta c in cartas)
            {
                if (cartaPasada == getTablero()[c.getValor()])
                {
                    c.Image = Image.FromFile(Application.StartupPath + @"C:\Users\w10\Desktop\Wendo1\Programacion\plotmex\plotmex\bin\Debug\sonido\Nueva carpeta\Nueva carpeta\ficha");
                    setCartasContadas(getCartasContadas() + 1);
                }
            }
        }
    }
}