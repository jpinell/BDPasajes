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

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            ListarEmpleados();
        }

        private void ListarEmpleados()
        {
            //NOMBRE COMPLETO
            BDPasajeEntities db = new BDPasajeEntities();
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
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreCompleto = txtNombre.Text;
            BDPasajeEntities db = new BDPasajeEntities();
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
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            ListarEmpleados();
        }
    }
}
