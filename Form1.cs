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
using System.IO;
namespace Library_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            show_book();
        }

        SqlConnection sql = new SqlConnection(" Data Source=SHEFA;Initial Catalog=library;Integrated Security=True");
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql.Close();
            sql.Open();
            SqlCommand cmd = new SqlCommand("insert into book_list(book_name,writer_name,quantity,dept)values('"+richTextBox2.Text+"','"+richTextBox1.Text+"','"+richTextBox3.Text+"','"+comboBox1.Text+"')" ,sql);
            int a = cmd.ExecuteNonQuery();
            if(a>0)
            {
            MessageBox.Show("upload successfull");
            }

            sql.Close();

        }

        void show_book()
        {
       
         sql.Close();
         sql.Open();

             SqlDataAdapter sda = new SqlDataAdapter ("select . from book_list" , sql);
             dataGridView1.Rows.Clear();
             DataTable dt = new DataTable();
             //sda.Fill(dt);
             foreach(DataRow item in dt.Rows)

            {
                int n = dataGridView1.Rows.Add();
                 dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                 dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                 dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                 dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                 dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
            }


         sql.Close();

         }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sql.Close();
            sql.Open();

            SqlCommand cmd = new SqlCommand("insert into Registration(id,name,date,dept,image)values('" + richTextBox6.Text + "','" + richTextBox5.Text + "','" + dateTimePicker1.Text + "','" + comboBox2.Text + "',@image);", sql);
            cmd.Parameters.AddWithValue("@image",savephoto()); 

            int a = cmd.ExecuteNonQuery(); 
            if (a > 0)
            {
                MessageBox.Show("Rgistration Sucessfull");
            }
            sql.Close();
        }

        public byte[] savephoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image File (*.png;*.jpg;*.bmp;*.gif)|*.png;*.jpg;*.bmp;*.gif";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(op.FileName);
            }
        }

    }
}
