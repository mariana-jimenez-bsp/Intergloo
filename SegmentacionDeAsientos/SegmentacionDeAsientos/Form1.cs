using SegmentacionDeAsientos.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SegmentacionDeAsientos.Data.dtasientos;

namespace SegmentacionDeAsientos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            connection asientos = new connection();

            List<dtasiento> SNList = new List<dtasiento>();
            SNList = asientos.ViewAsientosSN();
            foreach (var schema in SNList)
            {
                cmbSN.Items.Add(schema.Asiento);
            }

            List<dtasiento> NORList = new List<dtasiento>();
            NORList = asientos.ViewAsientosSeparado();
            foreach (var schema in NORList)
            {
                cmbNor.Items.Add(schema.Asiento);
            }
              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection asientos = new connection();
            string resultcode;
            resultcode = asientos.PasoUno();
            if (resultcode != "-1")
                {
                    MessageBox.Show("Proceso exitoso", "Exito");
                }
                else
                {
                    MessageBox.Show("No se encontro preasiento", "Advertencia");
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection asientos = new connection();

            string txtAsiNor = cmbNor.SelectedItem.ToString();
            string txtAsiSN = cmbSN.SelectedItem.ToString();

            string resultcode;
            resultcode = asientos.PasoDos(txtAsiNor, txtAsiSN);
            if (resultcode != "-1")
            {
                MessageBox.Show("Proceso exitoso", "Exito");
            }
            else
            {
                MessageBox.Show("No se encontro encotraron los datos necesarios", "Advertencia");
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
