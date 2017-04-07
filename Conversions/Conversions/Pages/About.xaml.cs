
using RWD.Conversions.Models;
using RWD.Conversions.View;
using System;
using Xamarin.Forms;

namespace RWD.Conversions.Pages
{
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();

            var listView = new ListView();

            listView.ItemsSource = AboutUrl.GetUrlList();
            listView.ItemTemplate = new DataTemplate(typeof(AboutUrlList));

            listView.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem != null)
                {
                    var g = e.SelectedItem as AboutUrl;                    
                    var u = new Uri(g.Uri);
                    Device.OpenUri(u);
                    listView.SelectedItem = null;
                }
            };

            var logo = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = @"http://realworlddevelopers.com/resources/images/rwdevs-header.jpg"
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                // var imageSender = (Image)s;
                var u = new Uri(@"http://www.realworlddevelopers.com");
                Device.OpenUri(u);
                //DisplayAlert("Alert", "Tap gesture recoganised", "OK");
            };
            logo.GestureRecognizers.Add(tapGestureRecognizer);

            var version = new Label { Text = "Version 1.0.0" };
            var copyright = new Label { Text = "Copyright © Real World Developers" };
            var rightsReserved = new Label { Text = "All Rights Reserved" };

            Content = new StackLayout
            {
                Spacing = 10,
                Children = { listView, logo, version, copyright, rightsReserved }
            };

        }

    }
}
