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
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\WebContoler\WebContoler\App_Data\CardDB.mdf;Integrated Security=True";
        
        public Form1()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {

            //создать переменную для хранения
            string JSONGData = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(textBox1.Text));
            //создать веб-запрос и используэмый метод для запроса
            WebRequest request = WebRequest.Create("http://localhost:57976/Home/Hello");
            request.Method = "POST";
            //тело запроса
            string query = $"name={JSONGData}";
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
            MessageBox.Show(helloStr);
            
            if (helloStr.Contains("root"))
            {
                Form2 form2 = new Form2();
                form2.Show();
                Hide();
                ActiveForm.Enabled=false;
                Form2.ActiveForm.Enabled = true;
            }
            else
            {
                Form3 form3 = new Form3();
                form3.Show();
                Hide();
                ActiveForm.Enabled = false;
                Form3.ActiveForm.Enabled = true;
            }
        }
    }
}
