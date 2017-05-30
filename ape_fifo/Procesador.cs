using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ape_fifo
{
    class Procesador
    {
        Proceso primero, ultimo, temp;

        public Procesador()
        {
            primero = null;
            ultimo = null;
        }

        public void enqueue(Proceso nuevoP)   //Meter proceso
        {
            if (primero == null)
            {
                primero = nuevoP;
                ultimo = nuevoP;
            }
            else
            {
                ultimo.siguiente = nuevoP;
                ultimo = nuevoP;
            }
        }

        public void dequeue()   //Sacar proceso
        {
            if (primero == null || ultimo == primero)
            {
                primero = null;
                ultimo = null;
            }
            else
                primero = primero.siguiente;
        }

        public Proceso peek()   //Ver proceso actual
        {
            return primero;
        }

        public string procesosPendientes()
        {
            int procPendientes = 0;
            int sumaCiclosPendientes = 0;
            temp = primero;

            while (temp != null)
            {
                sumaCiclosPendientes += temp.ciclos;
                procPendientes++;
                temp = temp.siguiente;
            }

            string pendientes = "Procesos pendientes: " + procPendientes.ToString() + Environment.NewLine +
                                "Suma de los ciclos pendientes: " + sumaCiclosPendientes.ToString();

            return pendientes;
        }
    }
}
