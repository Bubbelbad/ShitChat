﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ShitChat.UserControls;

namespace ShitChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DropDownMenu.SetChatWindow(ChatWindow);
            DropDownMenu.SetProfile(Profile);
            DropDownMenu.SetFrontWindow(Front);
        }

        public void SetUserName(string userName)
        {
            MenuBar.SetUserName(userName);
            Profile.SetLabelToUser(userName.ToString()); 
        }
        public void ShowProfile()
        {
            Profile.ShowProfile();
        }
    }
}
