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
    public partial class Form3 : Form
    {
        string deck = null;
        
        int[] deckInt = new int[20];
        SqlConnection sqlConnection;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\WebContoler\WebContoler\App_Data\CardDB.mdf;Integrated Security=True";

        //переменные для контроля
        int buttonN = 0;
        bool buttonHand =false;
        string cheker = null;
        int k = 10;
        int point1player = 0;
        int point2player = 0;
        int idData = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            //создать веб-запрос и используэмый метод для запроса

            string JSONGData = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(deck));
            WebRequest request = WebRequest.Create("http://localhost:57976/Home/Deck");
            request.Method = "POST";
            //тело запроса
            string query = $"deck={JSONGData}";
            byte[] byteMsg = Encoding.UTF8.GetBytes(query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteMsg.Length;
            //записание тела запроса в поток запроса
            using (Stream stream = await request.GetRequestStreamAsync())
            {
                await stream.WriteAsync(byteMsg, 0, byteMsg.Length);
            }
            //поток ответа
            WebResponse response = await request.GetResponseAsync();
            string answer = null;
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader sR = new StreamReader(s))
                {
                    answer = await sR.ReadToEndAsync();
                }
            }
            response.Close();
            string helloStr = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<string>(answer));
            deck = helloStr;
            //MessageBox.Show(deck);
            drawForm3();
        }
        
        private async void drawForm3()
        {
            String value = deck;
            Char delimiter = ' ';
            
            String [] split = value.Split(delimiter);
            //value = null;
            for (int i = 0; i < 20; i++)
            {
                deckInt[i] = Convert.ToInt32(split[i]);
               // value = value + " " + Convert.ToString(deckInt[i]);
               // MessageBox.Show(value);
            }
            //бд

            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            int j = 0;
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button1.Text=(Convert.ToString(sqlReader["UkrWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button2.Text = (Convert.ToString(sqlReader["UkrWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button2.Text = (Convert.ToString(sqlReader["UkrWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button3.Text = (Convert.ToString(sqlReader["UkrWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button4.Text = (Convert.ToString(sqlReader["UkrWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button5.Text = (Convert.ToString(sqlReader["UkrWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button6.Text = (Convert.ToString(sqlReader["UkrWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button7.Text = (Convert.ToString(sqlReader["UkrWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button8.Text = (Convert.ToString(sqlReader["UkrWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button9.Text = (Convert.ToString(sqlReader["UkrWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button10.Text = (Convert.ToString(sqlReader["UkrWord"]));
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
            j=0;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button11.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button12.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button13.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button14.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button15.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button16.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button17.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button18.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button19.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button20.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button21.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button22.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button23.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button24.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button25.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button26.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button27.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button28.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button29.Text = (Convert.ToString(sqlReader["EngWord"]));
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
            j++;
            sqlReader = null;
            command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
            command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[j]));
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    button30.Text = (Convert.ToString(sqlReader["EngWord"]));
                    string hak= (Convert.ToString(sqlReader["UkrWord"]));

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



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            cheker = button1.Text;
            buttonHand = true;
            buttonN = 1;
        }

        private async  void button11_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button11.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);
                        
                            if (cheker.Contains(s) == true)
                                point1player++;
                            else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);
                       
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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k+=2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cheker = button2.Text;
            buttonHand = true;
            buttonN = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cheker = button3.Text;
            buttonHand = true;
            buttonN = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cheker = button4.Text;
            buttonHand = true;
            buttonN = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cheker = button5.Text;
            buttonHand = true;
            buttonN = 5;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            cheker = button6.Text;
            buttonHand = true;
            buttonN = 6;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            cheker = button7.Text;
            buttonHand = true;
            buttonN = 7;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            cheker = button8.Text;
            buttonHand = true;
            buttonN = 8;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            cheker = button9.Text;
            buttonHand = true;
            buttonN = 9;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            cheker = button10.Text;
            buttonHand = true;
            buttonN = 10;
        }

        private async void button18_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button18.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button17_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button17.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button16_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button16.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button15_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button15.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button14.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button13.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button12.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button23_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button23.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button22_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button22.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button30_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button30.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button24_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button24.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button25_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button25.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button26_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button26.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button27_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button27.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button28_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button28.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button29_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button29.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button19_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button19.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button20_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button20.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private async void button21_Click(object sender, EventArgs e)
        {
            if (buttonHand)
            {
                sqlConnection = new SqlConnection(connectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sqlReader = null;
                SqlCommand command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [EngWord]=@EngWord", sqlConnection);
                command.Parameters.AddWithValue("EngWord", button21.Text);
                try
                {
                    sqlReader = await command.ExecuteReaderAsync();
                    if (await sqlReader.ReadAsync())
                    {
                        string s = Convert.ToString(sqlReader["UkrWord"]);

                        if (cheker.Contains(s) == true)
                            point1player++;
                        else point1player--;

                        buttonHand = false;
                        cheker = null;
                        label1.Text = Convert.ToString(point1player);
                        label2.Text = Convert.ToString(point2player);

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
                if (buttonN == 1)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button1.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 2)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button2.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 3)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button3.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 4)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button4.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (buttonN == 5)
                {
                    sqlReader = null;
                    command = new SqlCommand("SELECT * From [Eng_Uk] WHERE [Id]=@Id", sqlConnection);
                    command.Parameters.AddWithValue("Id", Convert.ToString(deckInt[k]));
                    try
                    {
                        sqlReader = await command.ExecuteReaderAsync();
                        if (await sqlReader.ReadAsync())
                        {
                            button5.Text = Convert.ToString(sqlReader["UkrWord"]);
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
                if (k < 19) k += 2;
                else Form3.ActiveForm.Close();
                point2player++;
                label2.Text = Convert.ToString(point2player);
                if (point2player == 5 || point1player == 5) Form3.ActiveForm.Close();

            }
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
            ActiveForm.Enabled = false;
            Form1.ActiveForm.Enabled = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
    
}
