using BDPasajes.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BDPasajes
{
    public partial class FrmMarcas : Form
    {
        public FrmMarcas()
        {
            InitializeComponent();
        }

        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            ListarMarcas();
        }

        private void ListarMarcas()
        {
            BDPasajeEntities oBDPasaje = new BDPasajeEntities();
            var consulta = (from marca in oBDPasaje.Marca //Esta es la tabla
                            where marca.BHABILITADO == 1
                            select new
                            {
                                marca.IIDMARCA,
                                marca.NOMBRE,
                                marca.DESCRIPCION
                            }).ToList();
            dgvMarcas.DataSource = consulta;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreMarca=txtMarca.Text;

            BDPasajeEntities oBDPasaje = new BDPasajeEntities();
            var consulta = (from marca in oBDPasaje.Marca //Esta es la tabla
                            where marca.BHABILITADO == 1
                            && marca.NOMBRE.Contains(nombreMarca)
                            select new
                            {
                                marca.IIDMARCA,
                                marca.NOMBRE,
                                marca.DESCRIPCION
                            }).ToList();
            dgvMarcas.DataSource = consulta;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMarca.Text = string.Empty;
            ListarMarcas();
        }
    }
}
