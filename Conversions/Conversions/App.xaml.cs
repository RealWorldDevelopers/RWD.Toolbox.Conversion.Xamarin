// Copyright(C) 2016  
// Real World Developers (www.realworlddevelopers.com) 
// All Right Reserved

using RWD.Conversions.Pages;
using Xamarin.Forms;

namespace RWD.Conversions
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // The root page of your application
            var padValue = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            var tabbedPage = new TabbedPage();
            tabbedPage.Padding = padValue;
            tabbedPage.Title = "Conversions";

            var massPage = new Mass();
            massPage.Title = "Mass";
            massPage.Icon = "mass.png";
            tabbedPage.Children.Add(massPage);

            var volumePage = new Volume();
            volumePage.Title = "Volume";
            volumePage.Icon = "volume.png";
            tabbedPage.Children.Add(volumePage);

            var tempPage = new Temp();
            tempPage.Title = "Temp";
            tempPage.Icon = "temp.png";
            tabbedPage.Children.Add(tempPage);

            var aboutPage = new About();
            aboutPage.Title = "About";
            aboutPage.Icon = "about.png";
            tabbedPage.Children.Add(aboutPage);

            MainPage = new NavigationPage(tabbedPage);

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
