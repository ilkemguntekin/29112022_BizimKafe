using BizimKafe.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BizimKafe.UI
{
    public partial class GecmisSiparisler : Form
    {
        private readonly KafeVeri _db;
        public GecmisSiparisler(KafeVeri db)
        {
            _db = db;
            InitializeComponent();
            dgvSiparisler.DataSource = _db.GecmisSiparisler;
        }

        private void dgvSiparisler_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvSiparisler.SelectedRows.Count == 0)
            {
                dgvSiparisDetaylari.DataSource = null;
            }
            else
            {
                DataGridViewRow secilenSatir = dgvSiparisler.SelectedRows[0];
                Siparis secilenSiparis=(Siparis)secilenSatir.DataBoundItem;
                dgvSiparisDetaylari.DataSource = secilenSiparis.SiparisDetaylar;
            }
        }
    }
}
