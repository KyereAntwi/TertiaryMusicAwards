using System.Threading.Tasks;
using TertiaryMusicAwardsMobile.DataTemplates;
using TertiaryMusicAwardsMobile.Models;
using TertiaryMusicAwardsMobile.Services;
using TertiaryMusicAwardsMobile.ValueConverters;
using TertiaryMusicAwardsMobile.ViewModels;
using Xamarin.Forms;

namespace TertiaryMusicAwardsMobile.Pages
{
    public class AwardCategoriesPage : ContentPage
	{
        AwardCategoriesPageViewModel _viewModel
        {
            get
            {
                return BindingContext as AwardCategoriesPageViewModel;
            }
        }
        public AwardCategoriesPage ()
		{
            BindingContext = new AwardCategoriesPageViewModel(DependencyService.Get<IAppNavService>());
            var awardCategoryList = new ListView
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(AwardCategoriesPageDataTemplate))
            };

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    awardCategoryList.SeparatorColor = Color.Default;
                    break;
                default:
                    awardCategoryList.SeparatorColor = Color.Black;
                    break;
            }

            awardCategoryList.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "AwardCategories");
            awardCategoryList.SetBinding(ItemsView<Cell>.IsVisibleProperty, "IsProcessBusy", converter: new BooleanConverter());

            //declare our progress lable
            var progressLabel = new Label()
            {
                FontSize = 14,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Loading Award Categories List...."
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
                    awardCategoryList,
                    progessIndicator
                }
            };

            // set up our event handler
            awardCategoryList.ItemTapped += async (object sender, ItemTappedEventArgs e) =>
            {
                // get the selected item by the user
                var item = (AwardCategory)e.Item;

                // check to see if we have a value for our item
                if (item == null) return;

                // display an action sheet with choices
                var action = await DisplayActionSheet("Perform an operation", "Cancel", "Proceed to vote for " + item.Category);
                if (action.Contains("Proceed"))
                {
                    await Navigation.PushAsync(new CategoryNomineesPage(item)
                    {
                        Title = "Click to Vote"
                    });
                }
                item = null;
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