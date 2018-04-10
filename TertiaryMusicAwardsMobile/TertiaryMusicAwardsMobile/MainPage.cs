
using TertiaryMusicAwardsMobile.Pages;
using Xamarin.Forms;

namespace TertiaryMusicAwardsMobile
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page awardCategories, nominneesPage, aboutpage = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    awardCategories = new NavigationPage(new AwardCategoriesPage())
                    {
                        Title = "Award Categories List"
                    };

                    nominneesPage = new NavigationPage(new NomineesPage())
                    {
                        Title = "Nominees List"
                    };

                    aboutpage = new NavigationPage(new AboutUsPage())
                    {
                        Title = "About Tertiary Music Awards"
                    };

                    awardCategories.Icon = "";
                    nominneesPage.Icon = "";
                    aboutpage.Icon = "";
                    break;
                default:
                    awardCategories = new AwardCategoriesPage()
                    {
                        Title = "Award Categories List"
                    };

                    nominneesPage = new NomineesPage()
                    {
                        Title = "Nominees List"
                    };

                    aboutpage = new AboutUsPage()
                    {
                        Title = "About Tertiary Music Awards"
                    };
                    break;
            }

            Children.Add(awardCategories);
            Children.Add(nominneesPage);
            Children.Add(aboutpage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
            BarBackgroundColor = Color.Blue;
            BarTextColor = Color.White;
        }
    }
}