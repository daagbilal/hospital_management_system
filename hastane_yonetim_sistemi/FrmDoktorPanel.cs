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
    public partial class FrmDoktorPanel : Form
    {
        public FrmDoktorPanel()
        {
            InitializeComponent();
        }

        SqlBaglanti conn = new SqlBaglanti();

        private void FrmDoktorPanel_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select BransAd From Tbl_Branslar", conn.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Doktorlar", conn.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert Into Tbl_Doktorlar (DoktorAd, DoktorSoyad, DoktorBrans, DoktorTC, DoktorSifre) Values (@p1,@p2,@p3,@p4,@p5)", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", textBox2.Text);
            cmd.Parameters.AddWithValue("@p2", textBox3.Text);
            cmd.Parameters.AddWithValue("@p3", comboBox1.Text);
            cmd.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p5", textBox5.Text);
            cmd.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Doktor bilgisi kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            textBox2.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[selected].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[selected].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[selected].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[selected].Cells[5].Value.ToString();
        }
    }
}
