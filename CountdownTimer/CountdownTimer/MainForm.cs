using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace CountdownTimer
{
    public partial class MainForm : Form
    {
        DBManager dbManager = new DBManager();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            AddToListFromDB();
        }

        private void AddToListFromDB()
        {
            //dbManager.listUser.Clear();
            dbManager.GetUsers();
            lstBoxUsers.Items.Clear();

            for (int i = 0; i < dbManager.listUser.Count; i++)
            {
                string id = dbManager.listUser[i].id.ToString();
                string username = dbManager.listUser[i].username;
                string latitude = dbManager.listUser[i].latitude;
                string longitude = dbManager.listUser[i].longitude;
                string counter = dbManager.listUser[i].counter.ToString();

                string result = id + "   " + username + "   " + latitude + "   " + longitude + "   " + counter;

                lstBoxUsers.Items.Add(result);

            }

            lblCounter.Text = dbManager.listUser.Count.ToString() + " active users";
        }

        private void CompareValuesFromDB()
        {
            dbManager.CompareValues();

            lstBoxUsers.Items.Clear();

            for (int i = 0; i < dbManager.listUser.Count; i++)
            {
                string id = dbManager.listUser[i].id.ToString();
                string username = dbManager.listUser[i].username;
                string latitude = dbManager.listUser[i].latitude;
                string longitude = dbManager.listUser[i].longitude;
                string counter = dbManager.listUser[i].counter.ToString();

                string result = id + " " + username + " " + latitude + " " + longitude + " " + counter;

                lstBoxUsers.Items.Add(result);

            }
        }

        private void timerDB_Tick(object sender, EventArgs e)
        {
            CompareValuesFromDB();
            for (int i = 0; i < dbManager.listUser.Count; i++)
            {
                if (dbManager.listUser[i].counter > 4)
                {
                    dbManager.RemoveUserInfo(dbManager.listUser[i].id, i);
                }
            }
        }
    }
}
