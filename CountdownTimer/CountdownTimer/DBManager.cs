using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace CountdownTimer
{
    class DBManager
    {
        public List<UserList> listUser = new List<UserList>();
        private List<UserList> compareList = new List<UserList>();

        public void GetUsers()
        {
            int id = 0;
            string username = null;
            string latitude = null;
            string longitude = null;
            int counter = 0;

            try
            {
                string myConnection = "datasource=gocommander.sytes.net;port=3306;username=commander;password=commander123;database=gocommander";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand verifyCommand = new MySqlCommand("SELECT * FROM users;", myConn);

                MySqlDataReader myReader;
                myConn.Open();
                myReader = verifyCommand.ExecuteReader();

                while (myReader.Read())
                {
                    id = myReader.GetInt32(0);
                    username = myReader.GetString(1);
                    latitude = myReader.GetString(3);
                    longitude = myReader.GetString(4);

                    if (latitude != "")
                    {
                        listUser.Add(new UserList(id, username, latitude, longitude, counter));
                    }

                }
            }

            catch (Exception ex)
            {

            }
        }

        public void CompareValues()
        {
            int id = 0;
            string username = null;
            string latitude = null;
            string longitude = null;

            try
            {
                string myConnection = "datasource=gocommander.sytes.net;port=3306;username=commander;password=commander123;database=gocommander";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand verifyCommand = new MySqlCommand("SELECT * FROM users;", myConn);

                MySqlDataReader myReader;
                myConn.Open();
                myReader = verifyCommand.ExecuteReader();

                while (myReader.Read())
                {
                    id = myReader.GetInt32(0);
                    username = myReader.GetString(1);
                    latitude = myReader.GetString(3);
                    longitude = myReader.GetString(4);

                    for (int i = 0; i < listUser.Count; i++)
                    {
                        if (id == listUser[i].id)
                        {
                            if(latitude.Contains(listUser[i].latitude))
                            {
                                listUser[i].counter++;
                            }
                            else
                            {
                                listUser[i].counter = 0;
                            }
                        }
                    }
                    
                }

                compareList.Add(new UserList(id, username, latitude, longitude));
            }

            catch (Exception ex)
            {

            }
        }

        //public void AddCredit(int cardID, int amount)
        //{
        //    int getAmount = Int32.Parse(CheckCard(cardID));
        //    int sum = getAmount + amount;

        //    try
        //    {
        //        string myConnection = "datasource=sts.sytes.net;port=3306;username=liberte;password=vivelafrance;database=stiot";
        //        MySqlConnection myConn = new MySqlConnection(myConnection);

        //        MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
        //        MySqlCommand verifyCommand = new MySqlCommand("UPDATE jojocards SET MONEY = '" + sum + "' WHERE ID='" + cardID + "' ;", myConn);
        //        myConn.Open();
        //        verifyCommand.ExecuteNonQuery();
        //        myConn.Close();
        //    }

        //    catch (Exception ex)
        //    {
        //        //return null;
        //    }
        //}

        public void CheckUserChange()
        {

        }

        public void RemoveUserInfoAndTreasure()
        {

        }
    }
}
