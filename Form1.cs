using System;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandevuTespiti_B201210026
{
  

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=randevu; user ID=postgres; password=meryem123");
        private void btnEKLE_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into randevubilgileri (randevubilgileriid,tc,il,ilce,muayneyeri,tarih,saat,hastane,poliklinik) values(@p0,@p1,@p2,@p3,@p5,@p6,@p7,@p8,@p9)", baglanti);
          
            komut.Parameters.AddWithValue("@p0", int.Parse(textBox3.Text));
            komut.Parameters.AddWithValue("@p1", textBoxtc.Text);
            komut.Parameters.AddWithValue("@p2", textBoxil.Text);
            komut.Parameters.AddWithValue("@p3", textBoxilce.Text);
            komut.Parameters.AddWithValue("@p5", textBoxmuayneyeri.Text);
            komut.Parameters.AddWithValue("@p6", Convert.ToDateTime(textBoxtarih.Text));
            komut.Parameters.AddWithValue("@p7",int.Parse(textBoxsaat.Text));
            komut.Parameters.AddWithValue("@p8", textBoxhastane.Text);
            komut.Parameters.AddWithValue("@p9", textBox2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Randevu ekleme işlemi başarı ile gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK);

        }

        private void buttonARA_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from randevubilgileri where tc like'%" + textBoxtcara.Text + "%' ", baglanti);

            DataSet ds = new DataSet();


            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            baglanti.Close();


        }

        private void buttonGUNCELLE_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update randevubilgileri set il=@p1,ilce=@p2,muayneyeri=@p3,tarih=@p4,saat=@p5,hastane=@p6 where tc=@p7", baglanti);


            
            komut3.Parameters.AddWithValue("@p7", textBoxgunctc.Text);
            komut3.Parameters.AddWithValue("@p1", textBoxill.Text);
            komut3.Parameters.AddWithValue("@p2", textBoxilcee.Text);
            komut3.Parameters.AddWithValue("@p3", textBoxmuayneyerii.Text);
            komut3.Parameters.AddWithValue("@p4", Convert.ToDateTime(textBoxtarihh.Text));
            komut3.Parameters.AddWithValue("@p5", int.Parse(textBoxsaatt.Text));
            komut3.Parameters.AddWithValue("@p6", textBoxhastanee.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Randevu güncelleme işlemi başarı ile gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK);



        }

        private void buttonSİL_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("delete from randevubilgileri where tc=@p1", baglanti);
            cmd.Parameters.AddWithValue("@p1", siltctxt.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Randevu silme işlemi başarı ile gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK);

        }

        private void btnsilara_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from randevubilgileri where tc like'%" + siltctxt.Text + "%' ", baglanti);

            DataSet ds = new DataSet();


            da.Fill(ds);

            dataGridView2.DataSource = ds.Tables[0];

            baglanti.Close();
        }


       

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from randevubilgileri where tc like'%" + textBoxgunctc.Text + "%' ", baglanti);

            DataSet ds = new DataSet();


            da.Fill(ds);

            dataGridView3.DataSource = ds.Tables[0];

            baglanti.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
