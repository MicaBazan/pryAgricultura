using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryAgricultura
{
    public partial class frm : Form
    {
        clsLocalidad loc;
        clsCultivos cul;
        clsProduccion prod;

        public frm()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void frm_Load(object sender, EventArgs e)
        {
            loc = new clsLocalidad();
            cul = new clsCultivos();
            prod = new clsProduccion();


            loc.ver(cbLocalidad);
            loc.ver(lbLocalidades);
            cul.ver(cbCultivo);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            try
            {
                bool valor = prod.actualizar(Convert.ToInt32(cbLocalidad.SelectedValue), Convert.ToInt32(cbCultivo.SelectedValue), Convert.ToInt32(txtToneladas.Text));

                if (valor == true)
                {
                    MessageBox.Show("DATOS CARGADO CON EXITO");
                    txtToneladas.Text = " ";
                }
                else
                {
                    MessageBox.Show("ESTOS DATOS YA ESTAN REGISTRADOS....", "ERROR");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("INGRESE NUMEROS EN TONELADAS...");
            }
            

        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            prod.graficar(Convert.ToInt32(lbLocalidades.SelectedValue), chart1);
        }
    }
}
