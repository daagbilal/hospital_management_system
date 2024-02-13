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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        SqlBaglanti conn = new SqlBaglanti();

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit frm = new FrmHastaKayit();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC = @p1 and HastaSifre = @p2", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read()) 
            {
                FrmHastaDetay frm = new FrmHastaDetay();
                frm.tc = maskedTextBox1.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kimlik numaranız ya da şifreniz yanlış.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            conn.baglanti().Close();
        }
    }
}
