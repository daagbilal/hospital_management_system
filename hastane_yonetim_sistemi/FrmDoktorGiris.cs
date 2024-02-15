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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        SqlBaglanti conn = new SqlBaglanti();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Doktorlar Where DoktorTC = @p1 And DoktorSifre = @p2", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay frm = new FrmDoktorDetay();
                frm.DoktorTc = maskedTextBox1.Text;
                frm.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Giriş bilgileriniz yanlış. Lütfen tekrar deneyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.baglanti().Close();
        }
    }
}
