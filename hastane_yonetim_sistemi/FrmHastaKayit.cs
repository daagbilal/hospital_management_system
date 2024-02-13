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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        SqlBaglanti conn = new SqlBaglanti();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert Into Tbl_Hastalar (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) Values (@p1,@p2,@p3,@p4,@p5,@p6)", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox3.Text);
            cmd.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p4", maskedTextBox2.Text);
            cmd.Parameters.AddWithValue("@p5", textBox2.Text);
            cmd.Parameters.AddWithValue("@p6", comboBox1.Text);
            cmd.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Kaydınız gerçekleşmiştir. Şifreniz: " + textBox2.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
