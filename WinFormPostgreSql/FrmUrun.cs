using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace WinFormPostgreSql
{
    public partial class FrmUrun : Form
    {
     
        public FrmUrun()
        {
            InitializeComponent();
            
        }

        NpgsqlConnection npgsqlConnection = new NpgsqlConnection("server=localhost; port=5432; Database=dburun; user ID=postgres; password=yok1;");
        private void btnListele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from urunler";
          NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sorgu , npgsqlConnection);
          DataSet dataSet = new DataSet();
          dataAdapter.Fill(dataSet);
          dataGridView1.DataSource = dataSet.Tables[0];

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            npgsqlConnection.Open();
            NpgsqlCommand command =
                new NpgsqlCommand(
                    "insert into urunler (urunid , urunad, stok , satisfiyat , alisfiyat , gorsel , kategori ) " +
                    "values (@p1 , @p2 , @p3 , @p4 , @p5 , @p6 , @p7)",
                    npgsqlConnection);

            command.Parameters.AddWithValue("@p1", int.Parse(txtUrunId.Text));
            command.Parameters.AddWithValue("@p2", txtUrunAd.Text);
            command.Parameters.AddWithValue("@p3", int.Parse(numericUpDown1.Value.ToString()));
            command.Parameters.AddWithValue("@p4", double.Parse(txtAlisFiyat.Text));
            command.Parameters.AddWithValue("@p5", double.Parse(txtSatisFiyat.Text));
            command.Parameters.AddWithValue("@p6", txtGorsel.Text);
            command.Parameters.AddWithValue("@p7", int.Parse(comboBox1.SelectedValue.ToString()));
            command.ExecuteNonQuery();
            npgsqlConnection.Close();
            MessageBox.Show("Başarılı");

        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            npgsqlConnection.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from kategori", npgsqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "kategoriad";
            comboBox1.ValueMember = "kategoriid";
            comboBox1.DataSource = dt;
            npgsqlConnection.Close();
        }
    }
}
