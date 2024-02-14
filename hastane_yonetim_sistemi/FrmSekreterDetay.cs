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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        public string tc;

        SqlBaglanti conn = new SqlBaglanti();

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            label3.Text = tc;
            SqlCommand cmd = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter Where SekreterTC = @p1", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label5.Text = dr[0].ToString();
            }

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", conn.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Tbl_Doktorlar", conn.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            SqlCommand cmd2 = new SqlCommand("Select BransAd From Tbl_Branslar", conn.baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2[0].ToString());
            }

            conn.baglanti().Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand cmd = new SqlCommand("Select (DoktorAd + ' ' + DoktorSoyad) From Tbl_Doktorlar Where DoktorBrans = @p1", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());
            }

            conn.baglanti().Close();
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

    }
}
