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
namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable Ucionica = new DataTable();
        string cs = "Data source=DESKTOP-CQJ6GR7; Initial catalog= Ucionica; Integrated security=true";
        int row=0;
        public void refresh(int x)
        {
            txt_id.Text = Ucionica.Rows[x]["id"].ToString();
            txt_naziv.Text = Ucionica.Rows[x]["naziv"].ToString();
            txt_sprat.Text = Ucionica.Rows[x]["sprat"].ToString();
            txt_brrac.Text = Ucionica.Rows[x]["brracunara"].ToString();
            txt_bruce.Text = Ucionica.Rows[x]["brucenika"].ToString();
            txt_pro.Text = Ucionica.Rows[x]["projektor"].ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txt_id.Enabled = false;
            SqlConnection veza = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Ucionice", veza);
            adapter.Fill(Ucionica);
            refresh(row);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            row = 0;
            refresh(row);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            row--;
            if (row<0)
            {
                row = 0;
            }
            refresh(row);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            row++;
            if (row > Ucionica.Rows.Count -1 )
            {
                row = Ucionica.Rows.Count - 1;
            }
            refresh(row);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            row = Ucionica.Rows.Count - 1;
            refresh(row);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            SqlCommand naredbe = new SqlCommand("delete from Ucionice where id =  " + txt_id.Text, veza);
            veza.Open();
            naredbe.ExecuteNonQuery();
            veza.Close();
            Ucionica.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Ucionice", veza);
            adapter.Fill(Ucionica);
            if(row == Ucionica.Rows.Count) 
            {
                row--;
            }
            refresh(row);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            //MessageBox.Show("update Ucionice set naziv = '" + txt_naziv.Text + "', sprat='" + txt_sprat.Text + "', brucenika='" + txt_bruce.Text + "', brracunara='" + txt_brrac.Text + "', projektor='" + txt_pro.Text + "' where id =" + txt_id.Text);
            SqlCommand naredbe = new SqlCommand("update Ucionice set naziv = '"+txt_naziv.Text + "', sprat='"+txt_sprat.Text+"', brucenika='"+txt_bruce.Text+"', brracunara='"+txt_brrac.Text+"', projektor='"+txt_pro.Text+"' where id ="+txt_id.Text, veza);
            veza.Open();
            naredbe.ExecuteNonQuery();
            veza.Close();
            Ucionica.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Ucionice", veza);
            adapter.Fill(Ucionica);
           
            refresh(row);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(cs);
            //MessageBox.Show("insert into Ucionice (naziv, sprat, brracunara, brucenika, projektor) values ('"+txt_naziv.Text +"','"+ txt_sprat.Text + "','" + txt_brrac.Text + "','" + txt_bruce.Text + "','" + txt_pro.Text + "')");
            SqlCommand naredbe = new SqlCommand("insert into Ucionice (naziv, sprat, brracunara, brucenika, projektor) values ('"+txt_naziv.Text +"','"+ txt_sprat.Text + "','" + txt_brrac.Text + "','" + txt_bruce.Text + "','" + txt_pro.Text + "')", veza);
            veza.Open();
            naredbe.ExecuteNonQuery();
            veza.Close();
            Ucionica.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Ucionice", veza);
            adapter.Fill(Ucionica);

            refresh(row);
        }
    }
}
