using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDPasajes
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMarcas frm = new FrmMarcas();
            frm.ShowDialog();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmpleados frm = new FrmEmpleados();
            frm.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClienteSexo frm = new FrmClienteSexo();
            frm.ShowDialog();
        }

        private void busToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBus frm = new FrmBus();
            frm.ShowDialog();
        }

        private void viajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmViajes frm = new FrmViajes();
            frm.ShowDialog();
        }
    }
}
