using ABMC_Empleados.datos;
using ABMC_Empleados.modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABMC_Empleados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (consultado==false)
            {
                MessageBox.Show("Debe consultar el empleado");
            }
            else if (txtLegajo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un legajo valido");
            }
            else if(txtDni.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un Documento");
            }
            else if (txtNombres.Text.Trim().Length < 5)
            {
                MessageBox.Show("Debe ingresar un nombre mas largo");
            }
            else
            {
                try
                {
                    Empleado em = new Empleado();
                    em.Legajo = txtLegajo.Text.Trim();
                    em.Documento = txtDni.Text.Trim();
                    em.Nombres = txtNombres.Text.ToUpper();
                    em.Apellidos = txtApellidos.Text.ToUpper();
                    em.Edad = Convert.ToInt32(txtEdad.Text.Trim());
                    em.Direccion = txtDireccion.Text.ToUpper();
                    em.Fecha_nacimiento = txtFechaNacimiento.Value.Day + "-" + txtFechaNacimiento.Value.Month + "-" + txtFechaNacimiento.Value.Year;

                    if (EmpleadoCAD.actualizar(em))
                    {
                        llenarGrid();
                        limpiarCampos();
                        MessageBox.Show("Empleado actualizado");
                        consultado = false;
                    }
                    else
                    {
                        MessageBox.Show("No se actualizo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtLegajo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un legajo valido");
            }
            else if (txtDni.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un Documento");
            }
            else if (txtNombres.Text.Trim().Length < 5)
            {
                MessageBox.Show("Debe ingresar un nombre mas largo");
            }
            else
            {
                try
                {
                    Empleado em = new Empleado();
                    em.Legajo = txtLegajo.Text.Trim();
                    em.Documento = txtDni.Text.Trim();
                    em.Nombres = txtNombres.Text.ToUpper();
                    em.Apellidos = txtApellidos.Text.ToUpper();
                    em.Edad = Convert.ToInt32(txtEdad.Text.Trim());
                    em.Direccion = txtDireccion.Text.ToUpper();
                    em.Fecha_nacimiento = txtFechaNacimiento.Value.Day + "-" + txtFechaNacimiento.Value.Month + "-" + txtFechaNacimiento.Value.Year;

                    if (EmpleadoCAD.guardar(em))
                    {
                        llenarGrid();
                        limpiarCampos();
                        MessageBox.Show("Empleado guardado");
                    }
                    else
                    {
                        MessageBox.Show("Ya existe otro empleado");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void llenarGrid()
        {
            DataTable datos = EmpleadoCAD.listar();
            if (datos ==null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {
                dglista.DataSource = datos.DefaultView;
            }
        }


        private void limpiarCampos()

        {
            txtApellidos.Text = "";
            txtLegajo.Text = "";
            txtDni.Text = "";
            txtNombres.Text = "";
            txtEdad.Text = "";
            txtDireccion.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        bool consultado = false;

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtLegajo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un legajo");
            }
            else
            {
                Empleado em = EmpleadoCAD.consultar(txtLegajo.Text.Trim());
                if (em == null)
                {
                    MessageBox.Show("no existe el empleado con legajo " + txtLegajo.Text);
                    limpiarCampos();
                    consultado = false;
                }
                else
                {
                    txtApellidos.Text = em.Apellidos;
                    txtLegajo.Text = em.Legajo;
                    txtDni.Text = em.Documento;
                    txtNombres.Text = em.Nombres;
                    txtDireccion.Text = em.Direccion;
                    txtEdad.Text = em.Edad.ToString();
                    txtFechaNacimiento.Text = em.Fecha_nacimiento;
                    consultado = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (consultado == false)
            {
                MessageBox.Show("Debe consultar el empleado");
            }
            else if (txtLegajo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un legajo valido");
            }
            else if (txtDni.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un Documento");
            }
            else if (txtNombres.Text.Trim().Length < 5)
            {
                MessageBox.Show("Debe ingresar un nombre mas largo");
            }
            else
            {
                try
                {
                    
                    if (EmpleadoCAD.eliminar(txtLegajo.Text.Trim()))
                    {
                        llenarGrid();
                        limpiarCampos();
                        MessageBox.Show("Empleado eliminado correctamente");
                        consultado = false;
                    }
                    else
                    {
                        MessageBox.Show("No se elimino");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
