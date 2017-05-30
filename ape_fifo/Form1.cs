using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ape_fifo
{
    public partial class Form1frmPrincipal : Form
    {
        static Random rand = new Random();
        Procesador proc = new Procesador();

        public Form1frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            int contadorDeVacio = 0;

            for (int i = 0; i < 200; i++)
            {
                if (rand.Next(1,101) <= 25)
                {
                    Proceso nuevoP = new Proceso();
                    proc.enqueue(nuevoP); //Meter proceso
                }

                Proceso vProceso = proc.peek(); //Ver primero de la cola
                if (vProceso != null)
                {
                    vProceso.ciclos--;
                    if (vProceso.ciclos == 0)
                        proc.dequeue();

                } else
                    contadorDeVacio++;   //Si el procesador está vacío, suma 1 al contador
            }

            txtInformacion.Text = "Ciclos que estuvo vacía: " + contadorDeVacio.ToString() + Environment.NewLine
                                    + proc.procesosPendientes() + Environment.NewLine;
            
        }
    }
}
