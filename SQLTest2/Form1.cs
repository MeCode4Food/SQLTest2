using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

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

        public Form1()
        {
            InitializeComponent();

            //Connect to server
            Connect();
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
        }

        public void Connect()
        {
            //Connects to server somehow
        }

        public void AddToSQL(Person c)
        {
            //Adds to database somehow
        }

        private string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssfff");
        }

    }
}
