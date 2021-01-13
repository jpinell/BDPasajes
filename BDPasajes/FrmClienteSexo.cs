using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BDPasajes.Models;

namespace BDPasajes
{
    public partial class FrmClienteSexo : Form
    {
        public FrmClienteSexo()
        {
            InitializeComponent();
        }

        private void FrmClienteSexo_Load(object sender, EventArgs e)
        {
            BDPasajeEntities db = new BDPasajeEntities();
            var consulta = (from cliente in db.Cliente
                            join sexo in db.Sexo
                            on cliente.IIDSEXO equals sexo.IIDSEXO
                            where cliente.BHABILITADO == 1
                            select new
                            {
                                cliente.IIDCLIENTE,
                                NombreCompleto = cliente.NOMBRE + " " + cliente.APPATERNO + " " + cliente.APMATERNO,
                                cliente.EMAIL,
                                sexo.NOMBRE
                            }).ToList();

            dgvCliente.DataSource = consulta;
        }

        private void txtFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            string nombreCompleto = txtFiltroNombre.Text;
            BDPasajeEntities db = new BDPasajeEntities();
            var consulta = (from cliente in db.Cliente
                            join sexo in db.Sexo
                            on cliente.IIDSEXO equals sexo.IIDSEXO
                            where cliente.BHABILITADO == 1
                            && (cliente.NOMBRE + " " + cliente.APPATERNO + " " + cliente.APMATERNO).Contains(nombreCompleto)
                            select new
                            {
                                cliente.IIDCLIENTE,
                                NombreCompleto = cliente.NOMBRE + " " + cliente.APPATERNO + " " + cliente.APMATERNO,
                                cliente.EMAIL,
                                sexo.NOMBRE
                            }).ToList();

            dgvCliente.DataSource = consulta;
        }
    }
}
