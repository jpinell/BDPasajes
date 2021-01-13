using BDPasajes.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BDPasajes
{
    public partial class FrmBus : Form
    {
        public FrmBus()
        {
            InitializeComponent();
        }

        private void FrmBus_Load(object sender, EventArgs e)
        {
            ListarBus();
            LlenarTipoBus();
        }

        private void LlenarTipoBus()
        {
            BDPasajeEntities db = new BDPasajeEntities();
            var consulta = (from tipobus in db.TipoBus
                            where tipobus.BHABILITADO == 1
                            select new
                            {
                                tipobus.IIDTIPOBUS,
                                tipobus.NOMBRE
                            }).ToList();

            cboTipoBus.DataSource = consulta;
            cboTipoBus.DisplayMember = "NOMBRE";
            cboTipoBus.ValueMember = "IIDTIPOBUS";
        }

        private void ListarBus()
        {
            //CONSULTA CON 3 TABLAS
            BDPasajeEntities db = new BDPasajeEntities();
            var consulta = (from bus in db.Bus
                            join sucursal in db.Sucursal
                            on bus.IIDBUS equals sucursal.IIDSUCURSAL
                            join tipoBus in db.TipoBus
                            on bus.IIDTIPOBUS equals tipoBus.IIDTIPOBUS
                            where bus.BHABILITADO == 1
                            select new
                            {
                                bus.IIDBUS,
                                NombreSucursal = sucursal.NOMBRE,
                                tipoBus.NOMBRE,
                                bus.PLACA
                            }).ToList();

            dgvBus.DataSource = consulta;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int valor = (int)cboTipoBus.SelectedValue;
            BDPasajeEntities db = new BDPasajeEntities();
            var consulta = (from bus in db.Bus
                            join sucursal in db.Sucursal
                            on bus.IIDBUS equals sucursal.IIDSUCURSAL
                            join tipoBus in db.TipoBus
                            on bus.IIDTIPOBUS equals tipoBus.IIDTIPOBUS
                            where bus.BHABILITADO == 1
                            && tipoBus.IIDTIPOBUS == valor
                            select new
                            {
                                bus.IIDBUS,
                                NombreSucursal = sucursal.NOMBRE,
                                tipoBus.NOMBRE,
                                bus.PLACA
                            }).ToList();

            dgvBus.DataSource = consulta;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ListarBus();
        }
    }
}
