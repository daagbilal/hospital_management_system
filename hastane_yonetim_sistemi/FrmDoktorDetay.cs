using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hastane_yonetim_sistemi
{
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        public string DoktorTc;
        SqlBaglanti conn = new SqlBaglanti();

        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            label3.Text = DoktorTc.ToString();
            SqlCommand cmd = new SqlCommand("Select (DoktorAd + ' ' + DoktorSoyad) From Tbl_Doktorlar Where DoktorTC = @p1", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", DoktorTc);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label5.Text = dr[0].ToString();
            }

            // Randevular
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular Where RandevuDoktor = '" + label5.Text + "'" , conn.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // Duyurular
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select Duyuru From Tbl_Duyurular ", conn.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;


            conn.baglanti().Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            richTextBox1.Clear();
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            string randevuTrh = dataGridView1.Rows[selected].Cells[1].Value.ToString();
            string randevuSaat = dataGridView1.Rows[selected].Cells[2].Value.ToString();
            string randevuBrans = dataGridView1.Rows[selected].Cells[3].Value.ToString();
            string randevuDoktor = dataGridView1.Rows[selected].Cells[4].Value.ToString();
            string randevuDurum = dataGridView1.Rows[selected].Cells[5].Value.ToString();
            string hastaTc = dataGridView1.Rows[selected].Cells[6].Value.ToString();
            richTextBox1.AppendText("Randevu Tarihi: " + randevuTrh + "\n");
            richTextBox1.AppendText("Randevu Saat: " + randevuSaat + "\n");
            richTextBox1.AppendText("Randevu Branşı: " + randevuBrans + "\n");
            richTextBox1.AppendText("Randevu Doktoru: " + randevuDoktor + "\n");
            richTextBox1.AppendText("Randevu Durumu: " + randevuDurum + "\n");
            richTextBox1.AppendText("Hasta TC No: " + hastaTc + "\n");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
