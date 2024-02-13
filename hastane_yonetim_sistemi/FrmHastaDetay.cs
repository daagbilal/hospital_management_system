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
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular Where HastaTC =" + tc, conn.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            // Branş ve Doktor Çekme
            SqlCommand cmd2 = new SqlCommand("Select BransAd From Tbl_Branslar", conn.baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2[0]);
            }

            //SqlCommand cmd3 = new SqlCommand("Select DoktorAd, DoktorSoyad From Tbl_Doktorlar Whe", conn.baglanti());
            //SqlDataReader dr3 = cmd3.ExecuteReader();
            //while (dr3.Read())
            //{
            //    comboBox2.Items.Add(dr3[0]);
            //}

            conn.baglanti().Close();


        }
    }
}
