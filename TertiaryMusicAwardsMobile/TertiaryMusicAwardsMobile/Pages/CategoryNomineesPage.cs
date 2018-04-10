using TertiaryMusicAwardsMobile.DataTemplates;
using TertiaryMusicAwardsMobile.Models;
using TertiaryMusicAwardsMobile.Services;
using TertiaryMusicAwardsMobile.ValueConverters;
using TertiaryMusicAwardsMobile.ViewModels;
using Xamarin.Forms;

namespace TertiaryMusicAwardsMobile.Pages
{
    public class CategoryNomineesPage : ContentPage
    {
        AwardCategory category;

        CategoryNomineesViewModel _viewModel
        {
            get
            {
                return BindingContext as CategoryNomineesViewModel;
            }
        }

        public CategoryNomineesPage(AwardCategory item)
        {
            BindingContext = new CategoryNomineesViewModel(DependencyService.Get<IAppNavService>(), item);
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

            nomineeList.ItemTapped += async (object sender, ItemTappedEventArgs e) =>
            {
                var result = (Nominee)e.Item;

                if (result == null) return;

                //display an action sheet
                var action = await DisplayActionSheet("Perform an operation", "Cancel", "Vote for " + result.StageName);
                if (action.Contains("Vote"))
                {
                    var vote = new Vote
                    {
                        PhoneIPAdress = DependencyService.Get<IIPAddressManager>().GetIPAddress(),
                        CategoryId = item.Id,
                        NomineeId = result.Id
                    };

                    bool voteResult = await DependencyService.Get<IWebServices>().PerformVoting(vote);

                    if (voteResult != false)
                    {
                        await DisplayAlert("Tertiary Music Awards", "Voting succusful", "Ok");
                        await Navigation.PushModalAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Tertiary Music Awards", "Sorry you have aready voted for this category or something went wrong", "Ok");
                        await Navigation.PushModalAsync(new MainPage());
                    }
                }
                result = null;
            };

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