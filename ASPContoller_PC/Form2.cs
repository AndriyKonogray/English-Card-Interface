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
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace ASPContoller_PC
{
    public partial class Form2 : Form
    {
        SqlConnection sqlConnection;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\WebContoler\WebContoler\App_Data\CardDB.mdf;Integrated Security=True";

        int idData =0;
        public Form2()
        {
            InitializeComponent();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            //бд
            
           sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    idData = Convert.ToInt32(sqlReader["Id"]) + 1;
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "               " + Convert.ToString(sqlReader["EngWord"]) + "              " + Convert.ToString(sqlReader["UkrWord"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null) sqlReader.Close();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
            ActiveForm.Enabled = false;
            Form1.ActiveForm.Enabled = true;

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();

            Form1 form1 = new Form1();
            form1.Show();
            Hide();
            ActiveForm.Enabled = false;
            Form1.ActiveForm.Enabled = true;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label7.Visible == true) label7.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                
                SqlCommand command = new SqlCommand("INSERT INTO [Eng_Uk] (Id,EngWord, UkrWord) VALUES(@Id,@EngWord, @UkrWord)", sqlConnection);
                command.Parameters.AddWithValue("EngWord", textBox1.Text);
                command.Parameters.AddWithValue("UkrWord", textBox2.Text);
                command.Parameters.AddWithValue("Id", idData);
                idData++;
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Поля EngWord и UkrWord мають бути заповнені";
            }
        }

        private async void оновитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "               " + Convert.ToString(sqlReader["EngWord"]) + "              " + Convert.ToString(sqlReader["UkrWord"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null) sqlReader.Close();
            }
            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label8.Visible == true) label8.Visible = false;
            if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Eng_Uk] SET [EngWord]=@EngWord, [UkrWord]=@UkrWord WHERE [Id]=@Id",sqlConnection);
                command.Parameters.AddWithValue("EngWord", textBox4.Text);
                command.Parameters.AddWithValue("Id", textBox5.Text);
                command.Parameters.AddWithValue("UkrWord", textBox3.Text);
                await command.ExecuteNonQueryAsync();
            }
            else 
            {
                label8.Visible = true;
                label8.Text = "Поля мають бути заповнені";
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label9.Visible == true) label9.Visible = false;
            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                command.Parameters.AddWithValue("Id", textBox6.Text);
                
                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label9.Visible = true;
                label9.Text = "Поле має бути заповненим";
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}
