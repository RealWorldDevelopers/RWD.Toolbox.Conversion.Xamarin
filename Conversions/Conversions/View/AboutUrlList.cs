
using Xamarin.Forms;

namespace RWD.Conversions.View
{
    public class AboutUrlList : ViewCell
    {        public AboutUrlList()
        {
            var displayLabel = new Label
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            displayLabel.SetBinding(Label.TextProperty, new Binding("Display"));

            View = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { displayLabel }

            };
        }
    }
}
