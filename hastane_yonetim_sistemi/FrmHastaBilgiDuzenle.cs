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

namespace hastane_yonetim_sistemi
{
    public partial class FrmHastaBilgiDuzenle : Form
    {
        public FrmHastaBilgiDuzenle()
        {
            InitializeComponent();
        }
        public string hasta_tc;

        SqlBaglanti conn = new SqlBaglanti();

        private void FrmHastaBilgiDuzenle_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select HastaAd, HastaSoyad, HastaTelefon, HastaSifre, HastaCinsiyet From Tbl_Hastalar Where HastaTC = @p1", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", hasta_tc);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox3.Text = dr[1].ToString();
                maskedTextBox2.Text = dr[2].ToString();
                textBox2.Text = dr[3].ToString();
            }
            conn.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Update Tbl_Hastalar Set HastaAd = @p1, HastaSoyad = @p2, HastaTelefon = @p3, HastaSifre = @p4 Where HastaTC = @p5", conn.baglanti());
            cmd2.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd2.Parameters.AddWithValue("@p2", textBox3.Text);
            cmd2.Parameters.AddWithValue("@p3", maskedTextBox2.Text);
            cmd2.Parameters.AddWithValue("@p4", textBox2.Text);
            cmd2.Parameters.AddWithValue("@p5", hasta_tc);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Bilgileriniz Değiştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.baglanti().Close();

        }
    }
}
