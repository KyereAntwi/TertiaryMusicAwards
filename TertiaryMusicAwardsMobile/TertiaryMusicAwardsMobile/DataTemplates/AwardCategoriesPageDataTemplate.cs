using Xamarin.Forms;

namespace TertiaryMusicAwardsMobile.DataTemplates
{
    public class AwardCategoriesPageDataTemplate : ViewCell
    {
        public AwardCategoriesPageDataTemplate()
        {
            var category = new Label()
            {
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black
            };
            category.SetBinding(Label.TextProperty, "Category");

            var description = new Label()
            {
                FontSize = 14,
                FontAttributes = FontAttributes.None,
                TextColor = Color.FromHex("#ddd")
            };
            description.SetBinding(Label.TextProperty, "Description");

            var cellLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 0,
                Padding = new Thickness(5, 5, 5, 5),
                Children =
                {
                    category,
                    description
                }
            };

            this.View = cellLayout;
        }
    }
}
