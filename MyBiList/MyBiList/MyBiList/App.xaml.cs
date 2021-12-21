using System;
using System.Collections.Generic;
using MyBiList.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyBiList.Service;


namespace MyBiList
{
    public partial class App : Application
    {
        public static List<BiList> GlobalTodoList = new List<BiList>();

        public App()
        {
            DependencyService.Register<MysqlDataStore>();

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
