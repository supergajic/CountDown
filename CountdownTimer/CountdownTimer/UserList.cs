using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace CountdownTimer
{
    class UserList
    {
        public int id;
        public string username;
        public string latitude;
        public string longitude;
        public int counter;

        public UserList(int id, string username, string latitude, string longitude, int counter)
        {
            this.id = id;
            this.username = username;
            this.latitude = latitude;
            this.longitude = longitude;
            this.counter = counter;
        }

        public UserList(int id, string username, string latitude, string longitude)
        {
            this.id = id;
            this.username = username;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public void ShowInfo()
        {
            string info = id.ToString() + " " + username;
        }
    }
}
