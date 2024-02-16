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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        public string tc;

        SqlBaglanti conn = new SqlBaglanti();

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            // TC ve Ad Soyad Çekme
            label3.Text = tc;
            SqlCommand cmd = new SqlCommand("Select HastaAd, HastaSoyad From Tbl_Hastalar Where HastaTC = @p1", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label5.Text = dr[0] + " " + dr[1];
            }
            
            // RAndevu Geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular Where HastaTC =" + tc + "And RandevuDurum = 1", conn.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            // Branş ve Doktor Çekme
            SqlCommand cmd2 = new SqlCommand("Select BransAd From Tbl_Branslar", conn.baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2[0]);
            }

            conn.baglanti().Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand cmd3 = new SqlCommand("Select DoktorAd, DoktorSoyad From Tbl_Doktorlar Where DoktorBrans = @p1", conn.baglanti());
            cmd3.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox2.Items.Add(dr3[0] + " " + dr3[1]);
            }

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular Where RandevuBrans = '" + comboBox1.Text + "' And RandevuDurum = 0", conn.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;

            conn.baglanti().Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Tbl_Randevular Where RandevuBrans = '" + comboBox1.Text + "' And RandevuDoktor = '" + comboBox2.Text + "' And RandevuDurum = 0", conn.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            conn.baglanti().Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaBilgiDuzenle frm = new FrmHastaBilgiDuzenle();
            frm.hasta_tc = tc;
            frm.Show();
        }
        
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView2.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView2.Rows[selected].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("Update Tbl_Randevular Set RandevuDurum = 1, HastaTC = @p1 Where Randevuid = @p2", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", tc);
            cmd.Parameters.AddWithValue("@p2", textBox1.Text);
            cmd.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Randevunuz alındı.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

            
            conn.baglanti().Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
