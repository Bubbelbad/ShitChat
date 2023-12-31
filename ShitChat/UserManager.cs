﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ShitChat
{
    public class UserManager
    {
        RegisterWindow registerWindow;
        public User currentUser;
        public string usersPath = "users.json";

        public UserManager() { }


        public void SetClasses(User user, RegisterWindow registerWindow)
        {
            this.currentUser = user;
            this.registerWindow = registerWindow;
        }

       
        public void DeleteUser(string userName)
        {
            foreach (User user in registerWindow.userList)
            {
                registerWindow.userList.Remove(user);
            }
        }
       
       
        public void SaveUserListToJson()
        {
            if (registerWindow != null) 
            {
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                string json = JsonConvert.SerializeObject(registerWindow.userList, Newtonsoft.Json.Formatting.Indented, settings); //Error
                StreamWriter sw = new StreamWriter(usersPath);
                sw.WriteLine(json);
                sw.Close();
            }
        }
    }  
}
