using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using C_Datos;
using C_Negocio;
using C_Entidad;

namespace Sistema
{
    public partial class Form1 : Form
    {
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();

        public Form1()
        {
            InitializeComponent();
        }

        void mantenimiento(string accion)
        {
            objent.codigo = textCodigo.Text;
            objent.nombre = textNombre.Text;
            objent.edad = Convert.ToInt32(textEdad.Text);
            objent.telefono = Convert.ToInt32(textTelefono.Text);
            objent.accion = accion;
            string men = objneg.N_mantenimiento_cliente(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void limpiar()
        {
            textCodigo.Text = "";
            textNombre.Text = "";
            textEdad.Text = "";
            textTelefono.Text = "";
            dataGridView1.DataSource = objneg.N_listar_clientes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objneg.N_listar_clientes();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textCodigo.Text=="")
            {
                if (MessageBox.Show($"¿Desea registrar a {textNombre.Text}?","Mensaje",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Information)==System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1");
                    limpiar();
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textCodigo.Text != "")
            {
                if (MessageBox.Show($"¿Desea modificar a {textNombre.Text}?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textCodigo.Text != "")
            {
                if (MessageBox.Show($"¿Desea eliminar a {textNombre.Text}?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            if (textBuscarNombre.Text !="")
            {
                objent.nombre = textBuscarNombre.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_clientes_nombre(objent);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objneg.N_listar_clientes();
            }
        }

        private void textBuscarCodigo_TextChanged(object sender, EventArgs e)
        {
            if (textBuscarCodigo.Text != "")
            {
                objent.codigo = textBuscarCodigo.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_clientes_codigo(objent);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objneg.N_listar_clientes();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            textCodigo.Text = dataGridView1[0, fila].Value.ToString();
            textNombre.Text = dataGridView1[1, fila].Value.ToString();
            textEdad.Text = dataGridView1[2, fila].Value.ToString();
            textTelefono.Text = dataGridView1[3, fila].Value.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked==true)
            {
                textBuscarCodigo.Enabled = true;
                textBuscarNombre.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBuscarCodigo.Enabled = false;
                textBuscarNombre.Enabled = true;
            }
        }
    }
}
