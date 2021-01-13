using BDPasajes.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BDPasajes
{
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private decimal sueldo = 0;
        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            ListarEmpleados();
        }


        private void ListarEmpleados()
        {
            //NOMBRE COMPLETO
            BDPasajeEntities db = new BDPasajeEntities();
            sueldo = 0;
            var consulta = (from empleado in db.Empleado //Esta es la tabla
                            where empleado.BHABILITADO == 1
                            select new
                            {
                                empleado.IIDEMPLEADO,
                                NombreCompleto = empleado.NOMBRE + " " + empleado.APPATERNO
                                + " " + empleado.APMATERNO,
                                empleado.FECHACONTRATO,
                                empleado.SUELDO
                            }).ToList();

            dgvEmpleados.DataSource = consulta;

            foreach (var item in consulta)
            {
                sueldo += (decimal)item.SUELDO;
            }

            txtTotalSueldos.Text = string.Format("{0:N2}", sueldo);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreCompleto = txtNombre.Text;
            BDPasajeEntities db = new BDPasajeEntities();
            sueldo = 0;
            var consulta = (from empleado in db.Empleado //Esta es la tabla
                            where empleado.BHABILITADO == 1
                            && (empleado.NOMBRE + " " + empleado.APPATERNO
                                + " " + empleado.APMATERNO).Contains(nombreCompleto)
                            select new
                            {
                                empleado.IIDEMPLEADO,
                                NombreCompleto = empleado.NOMBRE + " " + empleado.APPATERNO
                                + " " + empleado.APMATERNO,
                                empleado.FECHACONTRATO,
                                empleado.SUELDO
                            }).ToList();

            dgvEmpleados.DataSource = consulta;

            foreach (var item in consulta)
            {
                sueldo += (decimal)item.SUELDO;
            }

            txtTotalSueldos.Text = string.Format("{0:N2}", sueldo);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            ListarEmpleados();
            txtNombre.Focus();
        }
    }
}
