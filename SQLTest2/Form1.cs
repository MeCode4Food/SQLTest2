using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SQLTest2
{
    public struct Person
    {
        public string name;
        public string age;
        public string money;
        public string addTime;
    }

    public partial class Form1 : Form
    {
        MySqlConnection conn = null;

        public Form1()
        {
            InitializeComponent();

            //Inititalise MySqlConnection, connect to server, get connection
            conn = Connect();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //declare new struct of newGuy
            Person newGuy;

            //declare the members of struct of newGuy
            newGuy.name = inputName.Text;
            newGuy.age = inputAge.Text;
            newGuy.money = inputMoney.Text;
            newGuy.addTime = GetTimestamp(DateTime.Now);

            //Add text to Database
            AddToSQL(newGuy, conn);
        }

        //Connect Function
        public MySqlConnection Connect()
        {
            //Connects to server somehow
            string cs = @"Persist Security Info=False;server=127.0.0.1;database=test;uid=root;password=1234";

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();

                string stm = "SELECT VERSION()";
                MySqlCommand cmd = new MySqlCommand(stm, conn);
                string version = Convert.ToString(cmd.ExecuteScalar());
                MessageBox.Show(string.Format("MySQL version : {0}", version), "Connection Established");

                
            } catch (MySqlException ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.ToString()), "Error!");
            } finally
            {
                if(conn != null)
                {
                    
                    conn.Close();
                }
            }

            return conn;

        }

        //Inserts data into Mysql database
        public void AddToSQL(Person c, MySqlConnection conn)
        {
            //Adds to database somehow
            try
            {
                
                conn.Open();

                MySqlCommand cmd = new MySqlCommand()
                {
                    Connection = conn,
                    CommandText = "INSERT INTO testtable VALUES(@name, @age, @money, @date_entered, @user_id)"
                };
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@age", c.age);
                cmd.Parameters.AddWithValue("@money", c.money);
                cmd.Parameters.AddWithValue("@date_entered", c.addTime);
                cmd.Parameters.AddWithValue("@user_id", null);

                cmd.ExecuteNonQuery();
                MessageBox.Show(string.Format("Done bro."));
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.ToString()));

            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

            }

        }

        private string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssfff");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Test Connect feature
            Connect();
        }
    }
}
