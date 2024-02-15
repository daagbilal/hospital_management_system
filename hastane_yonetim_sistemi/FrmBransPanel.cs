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
    public partial class FrmBransPanel : Form
    {
        public FrmBransPanel()
        {
            InitializeComponent();
        }

        SqlBaglanti conn = new SqlBaglanti();

        private void FrmBransPanel_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", conn.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert Into Tbl_Branslar (BransAd) Values (@p1)", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1",textBox3.Text);
            cmd.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Branş eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update Tbl_Branslar Set BransAd = @p1 Where Bransid = @p2", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", textBox3.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Branş bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From Tbl_Branslar Where Bransid = @p1", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", textBox2.Text);
            cmd.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Branş başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            textBox2.Text = dataGridView1.Rows[selected].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();

        }
    }
}
