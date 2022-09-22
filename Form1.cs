using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Summer_Task02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employees", "Data Source=DESKTOP-MCA5OE5;Initial Catalog=crud;Integrated Security=True");
            DataSet ds = new DataSet();
            da.Fill(ds, "Employees");
            userDataGridView.DataSource = ds.Tables["Employees"].DefaultView;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=DESKTOP-MCA5OE5;Initial Catalog=crud;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string Insertquery = "Insert into Employees(FirstName,LastName,DateOfBirth,PhoneNumber,Email,Gender) values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
            SqlCommand cmd = new SqlCommand(Insertquery, con);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Data Inserted Successfully...!");
            }
            else
            {
                MessageBox.Show("ERROR...Please try again....");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=DESKTOP-MCA5OE5;Initial Catalog=crud;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string Updatequery = "Update Employees set FirstName = '" + textBox2.Text + "', LastName = '" + textBox3.Text + "' , DateOfBirth = '" + textBox4.Text + "' , PhoneNumber = '" + textBox5.Text + "' , Email = '" + textBox6.Text + "' , Gender = '" + textBox7.Text + "'   where EmployeeId = " + textBox1.Text + " ";
            SqlCommand cmd = new SqlCommand(Updatequery, con);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Data Updated Successfully...!");
            }
            else
            {
                MessageBox.Show("ERROR...Please try again....");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=DESKTOP-MCA5OE5;Initial Catalog=crud;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string Deletequery = "delete from Employees where EmployeeId = '" + textBox1.Text + "';";

            SqlCommand cmd = new SqlCommand(Deletequery, con);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Data deleted Successfully...!");
            }
            else
            {
                MessageBox.Show("ERROR...Please try again....");
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String connectionString = "Data Source=DESKTOP-MCA5OE5;Initial Catalog=crud;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            String SelectQry = " Select * from Employees where EmployeeId = " + textBox1.Text + " ";
            SqlDataAdapter sda = new SqlDataAdapter(SelectQry, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                textBox2.Text = dt.Rows[0]["FirstName"].ToString();
                textBox3.Text = dt.Rows[0]["LastName"].ToString();
                textBox4.Text = dt.Rows[0]["DateOfBirth"].ToString();
                textBox5.Text = dt.Rows[0]["PhoneNumber"].ToString();
                textBox6.Text = dt.Rows[0]["Email"].ToString();
                textBox7.Text = dt.Rows[0]["Gender"].ToString();

            }

            else
            {
                MessageBox.Show("no data found");
            }

            con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}

