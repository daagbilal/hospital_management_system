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
    public partial class FrmDuyurular : Form
    {
        public FrmDuyurular()
        {
            InitializeComponent();
        }
        SqlBaglanti conn = new SqlBaglanti();
        private void FrmDuyurular_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Duyuru From Tbl_Duyurular", conn.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.baglanti().Close();
        }
    }
}
