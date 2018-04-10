using System;
using TertiaryMusicAwardsMobile.Pages;
using TertiaryMusicAwardsMobile.Services;
using TertiaryMusicAwardsMobile.ViewModels;
using Xamarin.Forms;

namespace TertiaryMusicAwardsMobile
{
    public partial class App : Application
	{
        public App()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    Do();
                    break;
                default:
                    Do();
                    break;
            }
        }


        void Do()
        {
            var navPage = new NavigationPage(new MainPage()
            {
                Title = "Tertiary Music Awards " + DateTime.Now.Year
            });

            var navService = DependencyService.Get<IAppNavService>() as AppNavService;
            navService.navigation = navPage.Navigation;
            navService.RegisterViewMapping(typeof(AwardCategoriesPageViewModel), typeof(AwardCategoriesPage));
            navService.RegisterViewMapping(typeof(NomineesPageViewModel), typeof(NomineesPage));
            MainPage = navPage;
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
