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
    public partial class UrunlerForm : Form
    {
        private readonly KafeVeri _db;
        public UrunlerForm(KafeVeri db)
        {
            InitializeComponent();
            _db = db;
            UrunleriListele();
        }
        private void UrunleriListele()
        {
            dgvUrunler.DataSource = _db.Urunler.ToList();

        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            string ad = txtUrunler.Text.Trim();

            if (string.IsNullOrEmpty(ad))
            {
                MessageBox.Show("Ürün adı zorunlu.");
                return;
            }
            if (btnUrunEkle.Text == "EKLE")
            {
                _db.Urunler.Add(new Urun() { UrunAd = txtUrunler.Text, BirimFiyat = nudUrunFiyat.Value });
            }
            else
            {
                DataGridViewRow satir = dgvUrunler.SelectedRows[0];
                Urun urun = (Urun)satir.DataBoundItem;
                urun.BirimFiyat = nudUrunFiyat.Value;
                urun.UrunAd = txtUrunler.Text;
                UrunleriListele();
                btnUrunEkle.Text = "EKLE";
                btnIptal.Enabled = false;
                txtUrunler.Clear();
                nudUrunFiyat.Value = 0;
            }

            //    _db.Urunler.Add(new Urun()
            //    {
            //        UrunAd = ad,
            //        BirimFiyat = nudUrunFiyat.Value

            //    });

            //UrunleriListele();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvUrunler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Önce ürün seçiniz.");
                return;
            }

            DialogResult dr = MessageBox.Show("Silmek istediğinize emin misiniz?", "Silme Onayı", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.No)
                return;

            DataGridViewRow satir = dgvUrunler.SelectedRows[0];
            Urun urun = (Urun)satir.DataBoundItem;
            _db.Urunler.Remove(urun);
            UrunleriListele();
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            btnUrunEkle.Text = "KAYDET";
            btnIptal.Visible = true;
            DataGridViewRow satir = dgvUrunler.Rows[0];

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            btnUrunEkle.Text = "EKLE";
            btnIptal.Visible = false;
            txtUrunler.Clear();
            nudUrunFiyat.Value = 0;
        }
    }
}