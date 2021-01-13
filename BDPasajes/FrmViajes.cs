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
    public partial class FrmViajes : Form
    {
        public FrmViajes()
        {
            InitializeComponent();
        }

        private void FrmViajes_Load(object sender, EventArgs e)
        {
            ListarViajes();
        }

        private void ListarViajes()
        {
            //JOIN CON 2 PROPIEDADES DE LA MISMA TABLA

            BDPasajeEntities db = new BDPasajeEntities();
            var consulta = (from viaje in db.Viaje
                            join lugarorigen in db.Lugar
                            on viaje.IIDLUGARORIGEN equals lugarorigen.IIDLUGAR
                            join lugardestino in db.Lugar
                            on viaje.IIDLUGARDESTINO equals lugardestino.IIDLUGAR
                            select new
                            {
                                viaje.IIDVIAJE,
                                NombreOrigen = lugarorigen.NOMBRE,
                                NombreDestino = lugardestino.NOMBRE,
                                viaje.PRECIO,
                                viaje.FECHAVIAJE
                            }).ToList();

            dgvViajes.DataSource = consulta;
        }
    }
}
