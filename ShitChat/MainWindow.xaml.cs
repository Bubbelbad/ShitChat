﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Microsoft.Windows.Themes;
using ShitChat.UserControls;

namespace ShitChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FriendsManager friendsManager = new FriendsManager();
        MessageManager messageManager = new MessageManager();
        UserManager userManager = new UserManager();
        RegisterWindow registerWindow;
        Login login;
        User currentUser;


        public MainWindow()
        {
            InitializeComponent();
            DropDownMenu.SetWindows(Profile, ChatWindow, Front, this, userManager, profilePage, friendsWindow);
            TakePhoto.SetProfilePage(profilePage);
            TakePhoto.SetProfile(Profile);
            Profile.SetTakePhoto(TakePhoto);
        }


        //Closes application if we exit main window
        protected override void OnClosed(EventArgs e)
        {
            userManager.SaveUserListToJson();
            base.OnClosed(e);
            Application.Current.Shutdown();
        }


        public void SetRegisterWindow(RegisterWindow registerWindow, Login login)
        {
            this.registerWindow = registerWindow;
            this.login = login;
        }

        public void SetUserName(User user)
        {
            this.currentUser = user;
            MenuBar.SetUserName(user.UserName.ToString());
            MenuBar.SetProfilePage(profilePage, userManager);
            messageManager.SetUser(user);
            userManager.SetClasses(user, registerWindow);
            profilePage.SetManagers(registerWindow, userManager, this);
            ChatWindow.SetManager(messageManager);
            Profile.SetRegisterWindow(registerWindow, userManager);
            ChatWindow.UpdateWindowInformation();
            friendsWindow.SetManager(messageManager);
        }

        public void ShowLogin()
        {
            login.Visibility = Visibility.Visible;
        }


        public void ShowProfile()
        {
            Profile.ShowProfile();
        }


        public void ShowPhotoWindow()
        {
            TakePhoto.PhotoShow();
        }


        public void hidePhotoWindow()
        {
            TakePhoto.PhotoHide();
        }

        public void HideFriends()
        {
            friendsWindow.Visibility = Visibility.Hidden;
        }
    }
}
