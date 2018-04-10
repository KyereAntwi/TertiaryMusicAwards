using Xamarin.Forms;

namespace TertiaryMusicAwardsMobile.DataTemplates
{
    public class VotesPageDataTemplate : ViewCell
    {
        public VotesPageDataTemplate()
        {
            var nomineeImage = new Image
            {
                HeightRequest = 140,
                WidthRequest = 140,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Aspect = Aspect.Fill,
                Source = ImageSource.FromFile("image.jpg")
            };
            //nomineeImage.SetBinding(Image.SourceProperty, "ImageUrl");

            var nomineeStageName = new Label()
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                TextColor = Color.Black
            };
            nomineeStageName.SetBinding(Label.TextProperty, "StageName");

            var nomineeSchool = new Label()
            {
                FontAttributes = FontAttributes.Italic,
                FontSize = 14,
                TextColor = Color.FromHex("#666"),
            };
            nomineeSchool.SetBinding(Label.TextProperty, "School");

            var statusStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                Margin = 5,
                Children =
                {
                    nomineeStageName,
                    nomineeSchool
                }
            };

            var cellLayout = new StackLayout
            {
                Spacing = 0,
                Padding = new Thickness(5, 5, 5, 5),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    nomineeImage,
                    statusStack
                }
            };

            this.View = cellLayout;
        }
    }
}
