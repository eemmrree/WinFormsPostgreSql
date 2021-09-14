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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }
        NpgsqlConnection npgsqlConnection = new NpgsqlConnection("server=localhost; port=5432; Database=dburun; user ID=postgres; password=yok1;");
        private void btnEkle_Click(object sender, EventArgs e)
        {
            npgsqlConnection.Open();
            NpgsqlCommand command1 =
                new NpgsqlCommand("insert into kategori (kategoriid, kategoriad) values (@p1 ,@p2)", npgsqlConnection);

            command1.Parameters.AddWithValue("@p1",int.Parse(txtKategoriID.Text));
            command1.Parameters.AddWithValue("@p2", txtKategoriAd.Text);
            command1.ExecuteNonQuery();
            npgsqlConnection.Close();
            MessageBox.Show("Ekleme işlemi Başarılı");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from kategori";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sorgu, npgsqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }
    }
}
