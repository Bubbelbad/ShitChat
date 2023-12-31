﻿using ShitChat.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShitChat
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>


    public partial class Login : Window
    {
        RegisterWindow registerWindow = new RegisterWindow();
        MainWindow mainWindow = new MainWindow();
        Profile profile = new Profile();
        profilePage ProfilePage = new profilePage();
        dropDownMenu menu = new dropDownMenu();

        bool isFound = false;
        string user = null;
        string password = null;
        User logedInUser { set; get; }


        public Login()
        {
            InitializeComponent();
          // profile.SetRegisterWindow(registerWindow);
            registerWindow.SetLogin(this);
            mainWindow.SetRegisterWindow(registerWindow, this);
            profile.SetLogin(this);
            this.Show();
        }


        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }


        //Tar användaren till registeringen, gömmer Påminnelse label.
        private void ToRegisterWindow(object sender, RoutedEventArgs e)
        {
           // registerWindow.userList = registerWindow.ReadUsersFromJson("users.json");
            registerWindow.Show();
            this.Hide();
            Register_label.Visibility = Visibility.Collapsed;
        }
        

        //Loggar in en användare om den finns i Userlist, om inte hänvisas man till registerWindow.
        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
           // registerWindow.userList = registerWindow.ReadUsersFromJson("users.json");
            user = UserName_box.Text;
            password = Psw_Box.Password;

            if (user != "" && password != "")
            {
                foreach(User users in registerWindow.userList)
                {
                    if (user == users.UserName &&
                        password == users.Password)
                    {
                        isFound = true;
                        logedInUser = users;
                        mainWindow.SetUserName(users);
                        mainWindow.Show();
                        this.Hide();

                        Register_label.Visibility = Visibility.Hidden;
                        break;
                    }
                    if (!isFound)
                    { 
                        Register_label.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                MessageBox.Show("You need to write Username & Password");
            }
        }


        //Retunerar Den inlogade Usern till resten av programmet.
        public User GetLogedInUser()
        {
            return logedInUser;
        }


        //stänger ner applikationen.
        private void Quit_app(object sender, RoutedEventArgs e)
        {
            Application application = Application.Current;
            application.Shutdown();
        }
    }
}
