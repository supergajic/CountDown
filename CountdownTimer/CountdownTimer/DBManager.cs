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

                    if (latitude != "" && listUser.Count == 0)
                    {
                        listUser.Add(new UserList(id, username, latitude, longitude, counter));
                    }
                    else if (latitude != "")
                    {
                        for (int i = 0; i < listUser.Count; i++)
                        {
                            if (id == listUser[i].id)
                            {
                                listUser[i].longitude = longitude;
                                listUser[i].latitude = latitude;
                                break;
                            }
                            else if (i == listUser.Count - 1)
                            {
                                listUser.Add(new UserList(id, username, latitude, longitude, counter));
                            }
                        }
                    }
                }
                myConn.Close();
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
                myConn.Close();
            }

            catch (Exception ex)
            {

            }
        }

        public void RemoveUserInfo(int in_id, int user_index)
        {
            int id = in_id;

            try
            {
                string myConnection = "datasource=gocommander.sytes.net;port=3306;username=commander;password=commander123;database=gocommander";                
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand verifyCommand = new MySqlCommand("UPDATE users SET latitude = '', longitude = '' WHERE id=" + id + " ;", myConn);
                myConn.Open();
                verifyCommand.ExecuteNonQuery();
                myConn.Close();

                RemoveTreasure(id);

                listUser.RemoveAt(user_index);
            }
            catch (Exception ex)
            {
                //return null;
            }
        }

        public void RemoveTreasure(int in_id)
        {
            int id = in_id;

            try
            {
                string myConnection = "datasource=gocommander.sytes.net;port=3306;username=commander;password=commander123;database=gocommander";
                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                MySqlCommand verifyCommand = new MySqlCommand("DELETE FROM treasures WHERE uid=" + id + " ;", myConn);
                myConn.Open();
                verifyCommand.ExecuteNonQuery();
                myConn.Close();
            }
            catch (Exception ex)
            {
                //return null;
            }
        }
    }
}
