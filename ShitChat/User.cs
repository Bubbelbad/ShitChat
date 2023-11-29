﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ShitChat
{
    public class User : Person
    {
        public string UserName;
        public string Password; //Borde inte dessa två variabler ligga i User istället för Person? 

        public List<User> friendsList = new List<User>();
        public List<Conversation> conversations = new List<Conversation>();


        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }


        public void AddFriend(User user)
        {
            friendsList.Add(user);
        }


        public void RemoveFriend(User user)
        {
            friendsList.Remove(user);
        }



    }
}
