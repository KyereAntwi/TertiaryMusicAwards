using TertiaryMusicAwardsMobile.DataTemplates;
using TertiaryMusicAwardsMobile.Services;
using TertiaryMusicAwardsMobile.ValueConverters;
using TertiaryMusicAwardsMobile.ViewModels;
using Xamarin.Forms;

namespace TertiaryMusicAwardsMobile.Pages
{
    public class NomineesPage : ContentPage
	{
        NomineesPageViewModel _viewModel
        {
            get
            {
                return BindingContext as NomineesPageViewModel;
            }
        }

		public NomineesPage ()
		{
            BindingContext = new NomineesPageViewModel(DependencyService.Get<IAppNavService>());
            var nomineeList = new ListView
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(NomineesPageDataTemplate))
            };

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    nomineeList.SeparatorColor = Color.Default;
                    break;
                default:
                    nomineeList.SeparatorColor = Color.Black;
                    break;
            }

            nomineeList.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "Nominees");
            nomineeList.SetBinding(ItemsView<Cell>.IsVisibleProperty, "IsProcessBusy", converter: new BooleanConverter());

            //declare our progress lable
            var progressLabel = new Label()
            {
                FontSize = 14,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Loading Nominees List...."
            };

            //instantiate an initialise our activity indicator
            var activityIndicator = new ActivityIndicator()
            {
                IsRunning = true
            };
            var progessIndicator = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    activityIndicator,
                    progressLabel
                }
            };

            progessIndicator.SetBinding(StackLayout.IsVisibleProperty, "IsProcessBusy");

            var mainLayout = new StackLayout
            {
                Children =
                {
                    nomineeList,
                    progessIndicator
                }
            };

            Content = mainLayout;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //initialise our awardcategoryviewmodel
            if (_viewModel != null) await _viewModel.Init();
        }
    }
}