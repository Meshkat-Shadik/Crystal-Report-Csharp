using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace crrow
{
    public partial class StartShuru : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;username=root;database=pro_one_try;password=");
        MySqlCommand command,command2;
        string shortDate= null;
        string shortDate2= null;
        string sD = null;
        string sD2 = null;
        string roboIp;
       // string xxx , xxxx;
        MySqlDataAdapter da,da2;
        int salary;
        string a, b, c, d, p,exx,q,r,s,late,abs;
        byte[] ImageData;
        
       // int a;
        public StartShuru()
        {
            InitializeComponent();
            //dateTimePicker1.Value = null;

            display();
        }
        public void display()
        {
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            try
            {
                string selectQuery = "select * from tryview";
                //SELECT CAST(Date as DATE), CAST(Time as TIME) from presents
                command = new MySqlCommand(selectQuery, connection);
                da = new MySqlDataAdapter(command);

                DataTable table = new DataTable();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.RowTemplate.Height = 50;
                dataGridView2.AllowUserToAddRows = false;

                da.Fill(table);

                dataGridView2.DataSource = table;
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)dataGridView2.Columns[0];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                da.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        public String activereturn()
        {
            string selectQuery2 = "SELECT COUNT(*) FROM tryview WHERE (Date BETWEEN " + shortDate + " and " + shortDate2 + " and ID=" + a + " and (Time Between '08:00:00' and '10:00:00'));";
            // SELECT * FROM tryview WHERE Time Between '09:00:00' and '10:00:00';
            connection.Open();
            command2 = new MySql.Data.MySqlClient.MySqlCommand(selectQuery2, connection);

            var queryResult = command2.ExecuteScalar();//Return an object so first check for null
            if (queryResult != null)
                // If we have result, then convert it from object to string.
                roboIp = Convert.ToString(queryResult);
            else
                // Else make id = "" so you can later check it.
                roboIp = "";

            label5.Text = roboIp;
            return roboIp;
        }
        public string latereturn()
        {
            string selectQuery3 = "SELECT COUNT(*) FROM tryview WHERE (Date BETWEEN " + shortDate + " and " + shortDate2 + " and ID=" + a + " and (Time Between '10:01:00' and '16:00:00'));";
            // SELECT * FROM tryview WHERE Time Between '09:00:00' and '10:00:00';
            //  connection.Open();
            command2 = new MySql.Data.MySqlClient.MySqlCommand(selectQuery3, connection);

            var queryResult2 = command2.ExecuteScalar();//Return an object so first check for null
            if (queryResult2 != null)
                // If we have result, then convert it from object to string.
                late = Convert.ToString(queryResult2);
            else
                // Else make id = "" so you can later check it.
                late = "";
            label3.Text = late;
            return late;
        }
        public string absentreturn()
        {

            //  label2.Text = late;
            string selectQuery4 = "SELECT COUNT(*) FROM tryview WHERE (Date BETWEEN " + shortDate + " and " + shortDate2 + " and ID=" + a + " and (Time  NOT  Between '08:00:00' and '16:00:00'));";
            // SELECT * FROM tryview WHERE Time Between '09:00:00' and '10:00:00';
            //  connection.Open();
            command2 = new MySql.Data.MySqlClient.MySqlCommand(selectQuery4, connection);

            var queryResult3 = command2.ExecuteScalar();//Return an object so first check for null
            if (queryResult3 != null)
                // If we have result, then convert it from object to string.
                abs = Convert.ToString(queryResult3);
            else
                // Else make id = "" so you can later check it.
                abs = "";
            label4.Text = abs;
            return abs;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            shortDate = dateTimePicker1.Value.ToString("yyyyMMdd");
            sD = dateTimePicker1.Value.ToString("dd-MMMM,yyyy");
            //label2.Text = date.ToString("yyyy-mm-dd");
            label1.Text = shortDate;
         //   xxx = dateTimePicker1.Value.ToString("dd-MMMM-yyyy");
          //  shortDate = null;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            shortDate2 = dateTimePicker2.Value.ToString("yyyyMMdd");
            sD2 = dateTimePicker2.Value.ToString("dd-MMMM,yyyy");
           // xxxx = dateTimePicker2.Value.ToString("dd-MMMM-yyyy");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            //    string selectQuery = "SELECT users.ID,users.NAME,users.Rank,CAST(presents.Date as DATE), CAST(presents.Time as TIME) FROM users inner join presents where users.ID=presents.ID and  CAST(Date as DATE)  BETWEEN " + shortDate + " and " + shortDate2 + ";";
                //string selectQuery = "SELECT CAST(Date as DATE), CAST(Time as TIME) from presents   WHERE CAST(Date as DATE)  BETWEEN " + shortDate + " and " + shortDate2 + ";";

                string selectQuery = "Select ID,NAME,Rank,DATE_FORMAT(CAST(Date as DATE),'%d-%M,%Y') as Date,Time,Src,Salary,Mobile,Email from tryview where Date BETWEEN " + shortDate + " and " + shortDate2 + ";";//SELECT CAST(Date as DATE), CAST(Time as TIME) from presents
               // string selectQuery2 = "SELECT COUNT(*) FROM demos WHERE val = 2";
                command = new MySqlCommand(selectQuery, connection);
                da = new MySqlDataAdapter(command);

                DataTable table = new DataTable();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.RowTemplate.Height = 20;
                dataGridView2.AllowUserToAddRows = false;

                da.Fill(table);

                dataGridView2.DataSource = table;
                da.Dispose();
           //    ordersBindingSource.DataSource = connection.Query<Orders>(selectQuery, CommandType: CommandType.Text);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                try
                {
                 //   int newWidth = 568;
                 ////   dataGridView1.MaximumSize = new Size(newWidth, dataGridView1.Height);
                 //   dataGridView1.Size = new Size(newWidth, dataGridView1.Height);
                //    panel1.Visible = true;
                    //    pictureBox1.Image = (Image)dataGridView1.SelectedRows[0].Cells["IMAGE"].Value;
               //     byte[] bytes = (byte[])dataGridView1.SelectedRows[0].Cells["IMAGE"].Value;
               //     MemoryStream ms = new MemoryStream(bytes);
                //    pictureBox1.Image = Image.FromStream(ms);
                    button1.Visible = true;
                    p = dataGridView2.SelectedRows[0].Cells["Src"].Value.ToString();
                    a = dataGridView2.SelectedRows[0].Cells["ID"].Value.ToString();
                     b = dataGridView2.SelectedRows[0].Cells["NAME"].Value.ToString();
                     c = dataGridView2.SelectedRows[0].Cells["Rank"].Value.ToString();
                      d = dataGridView2.SelectedRows[0].Cells["Email"].Value.ToString();
                     exx = dataGridView2.SelectedRows[0].Cells["Mobile"].Value.ToString();
                    salary = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Salary"].Value);
                     label1.Text = p;

                     
                     BinaryReader br;
                     FileStream fs;
                     fs = new FileStream(p, FileMode.Open, FileAccess.Read);
                     br = new BinaryReader(fs);
                     ImageData = br.ReadBytes((int)fs.Length);
                     //Date.ToString("yyyy-MM-dd");
                    //MessageBox.Show(x + "" + y + "" + z + "" + xx + "" + xy);
                   // label10.Text = dataGridView1.SelectedRows[0].Cells["Rank"].Value.ToString();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Orders obj = ordersBindingSource.Current as Orders;
                string selectQuery = "Select * from tryview where Date BETWEEN " + shortDate + " and " + shortDate2 + ";";
               // string selectQuery2 = "SELECT COUNT(*) FROM tryview WHERE Date BETWEEN " + shortDate + " and " + shortDate2 + ";";
                //string selectQuery = "SELECT CAST(Date as DATE), CAST(Time as TIME) from presents   WHERE CAST(Date as DATE)  BETWEEN " + shortDate + " and " + shortDate2 + ";";
                //SELECT CAST(Date as DATE), CAST(Time as TIME) from presents
                command = new MySqlCommand(selectQuery, connection);
                //command2 = new MySqlCommand(selectQuery2, connection);
                da = new MySqlDataAdapter(command);
               // da2 = new MySqlDataAdapter(command2);

                DataTable table = new DataTable();
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.RowTemplate.Height = 20;
                dataGridView2.AllowUserToAddRows = false;

                da.Fill(table);

                dataGridView2.DataSource = table;
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn = (DataGridViewImageColumn)dataGridView2.Columns[0];
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                da.Dispose();
               

              

               
             


          

                //     ordersBindingSource.DataSource = connection.Query<Orders>(selectQuery, CommandType: CommandType.Text);




                frmprint obj = new frmprint(a, b, c, d, exx, p, activereturn(), latereturn(),absentreturn(), salary,sD,sD2);
                obj.ShowDialog();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }






























    }
}
