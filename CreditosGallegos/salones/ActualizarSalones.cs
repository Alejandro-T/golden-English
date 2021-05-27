using Ge;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenE.alumnos
{
    public partial class ActualizarSalones : Form
    {
        public ActualizarSalones()
        {
            InitializeComponent();
        }

        private void btncActu_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand act = new OracleCommand("ACTUALIZASALONES", Conexion.conectar());
                act.CommandType = System.Data.CommandType.StoredProcedure;

                act.Parameters.Add("id_salon_in", OracleDbType.Int16).Value = textBoxSid.Text;

                act.Parameters.Add("salon_descripcion", OracleDbType.Varchar2).Value = textBoxAdescripcion.Text;

                //
                string comp = " select id_salon from salones where descripcion =lower('" + this.textBoxAdescripcion.Text + "')";
                OracleCommand cpe = new OracleCommand(comp, Conexion.conectar());
                OracleDataReader dre = cpe.ExecuteReader();
                if (dre.Read())
                {
                    MessageBox.Show("Existe un salon con el mismo nombre ", "aviso", MessageBoxButtons.OK);
                }
                else
                {
                    act.ExecuteNonQuery();
                    MessageBox.Show("Dato actualizado con exito", "exito", MessageBoxButtons.OK);
                    this.cargarSalon(this.dataGridViewCargaSalon);
                    this.Limpiar();
                }

                //aaaa
            }
            catch (OracleException ex)
            {
                switch (ex.Number)
                {
                    case 1722:
                        MessageBox.Show("Numero invalido(FormatException)--Error--" + ex.Number, "Aviso", MessageBoxButtons.OK);
                        break;
                    case 2292:
                        MessageBox.Show("No se puede eliminar el dato, porque existe una tabla hijo con ese dato", "Aviso", MessageBoxButtons.OK);
                        break;
                    default:
                        MessageBox.Show("Formato invalido--Error--" + ex.Number, "Aviso", MessageBoxButtons.OK);
                        break;
                }
            }
            finally
            {
                Conexion.cerrar();
            }
        }
 
        private void dataGridViewCargaAlumno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewCargaSalon.Rows[e.RowIndex];
                this.textBoxSid.Text = row.Cells["ID_SALON"].Value.ToString();
                this.textBoxIdSalon.Text = row.Cells["ID_SALON"].Value.ToString();
                this.textBoxAdescripcion.Text = row.Cells["descripcion"].Value.ToString();
            }
        }

        public void CargarSalonDescripcion(DataGridView dvg)
        {
            try
            {
                DataTable dtsSal = new DataTable();
                string comprobacion = "select ID_SALON, descripcion from salones where DESCRIPCION like '" + Convert.ToString(this.textBoxBdescripcion.Text).ToLower() + "%' order by id_salon";

                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {
                    da.Fill(dtsSal);
                    dvg.DataSource = dtsSal;
                }
                else
                {
                    dataGridViewCargaSalon.DataSource = "";
                    MessageBox.Show("El salon no existe", "aviso", MessageBoxButtons.OK);
                }
            }
            catch (OracleException ex)
            {
                switch (ex.Number)
                {
                    case 1722:
                        MessageBox.Show("--Error--" + ex.Number, "Aviso", MessageBoxButtons.OK);
                        break;
                    case 2292:
                        MessageBox.Show("No se puede eliminar el dato, porque existe una tabla hijo con ese dato", "Aviso", MessageBoxButtons.OK);
                        break;
                    default:
                        MessageBox.Show("Formato invalido--Error--" + ex.Number, "Aviso", MessageBoxButtons.OK);
                        break;
                }
            }


        }
        public void cargarSalon(DataGridView dvg)
        {
            try
            {
                DataTable dtsalones = new DataTable();
                string comprobacion = "Select ID_SALON,descripcion from salones where ID_SALON='" + this.textBoxIdSalon.Text + "'";
                OracleDataAdapter da = new OracleDataAdapter
                    (comprobacion, Conexion.conectar());
                OracleCommand cp = new OracleCommand(comprobacion, Conexion.conectar());
                OracleDataReader dr = cp.ExecuteReader();
                if (dr.Read())
                {

                    da.Fill(dtsalones);
                    dvg.DataSource = dtsalones;
                }
                else
                {
                    dataGridViewCargaSalon.DataSource = "";
                    MessageBox.Show("El salon no existe", "aviso", MessageBoxButtons.OK);
                }
            }


            catch (Oracle.DataAccess.Client.OracleException)
            {
                dataGridViewCargaSalon.DataSource = "";
                MessageBox.Show("Formato invalido", "Aviso", MessageBoxButtons.OK);
            }
        }
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.cargarSalon(this.dataGridViewCargaSalon);
        }

        private void ActualizarNiveles_Load(object sender, EventArgs e)
        {
            if (groupBox1.Enabled == true || groupBox2.Enabled == true)
            {



            }
            else
            {

                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                this.groupBox1.Hide();
                this.groupBox2.Hide();

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox1.Show();
                groupBox2.Hide();
                checkBox2.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
                groupBox1.Hide();
            }
        }
        public void Limpiar()
        {
            this.textBoxIdSalon.Clear();
            this.textBoxSid.Clear();
            this.textBoxAdescripcion.Clear();

        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                groupBox2.Show();
                groupBox1.Hide();
                checkBox1.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                groupBox2.Hide();
            }
        }

        private void textBoxBdescripcion_TextChanged(object sender, EventArgs e)
        {
            this.CargarSalonDescripcion(this.dataGridViewCargaSalon);
        }
      
    }
    
}
