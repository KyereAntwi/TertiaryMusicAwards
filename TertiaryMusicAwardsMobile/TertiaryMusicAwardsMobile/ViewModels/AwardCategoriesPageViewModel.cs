using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TertiaryMusicAwardsMobile.Models;
using TertiaryMusicAwardsMobile.Services;
using Xamarin.Forms;

namespace TertiaryMusicAwardsMobile.ViewModels
{
    public class AwardCategoriesPageViewModel : VotingBaseViewModel
    {
        ObservableCollection<AwardCategory> _awardCategoreis;
        public ObservableCollection<AwardCategory> AwardCategories
        {
            get { return _awardCategoreis; }
            set
            {
                _awardCategoreis = value;
                OnPropertyChanged();
            }
        }

        public AwardCategoriesPageViewModel(IAppNavService navService) : base(navService)
        {
            AwardCategories = new ObservableCollection<AwardCategory>();
        }
        
        public override async Task Init()
        {
            await LoadAwardCategoriesDetails();
        }

        public async Task LoadAwardCategoriesDetails()
        {
            //check to see if we are already processing ou category items
            if (IsProcessBusy)
            {
                return;
            }

            //if we aren't currently processing, we need to initialize our variable to true
            IsProcessBusy = true;
            

            try
            {
                // populate our items with
                AwardCategories = new ObservableCollection<AwardCategory>(await DependencyService.Get<IWebServices>().GetAwardCategoriesAsync());
            }
            finally
            {
                if (AwardCategories != null)
                    IsProcessBusy = false;
                else
                    IsProcessBusy = true;
            }

            //add a temporary timer, so that we can see our progress indicator working
            await Task.Delay(1000);

            await Task.Factory.StartNew(() =>
            {
            });
        }
    }
}
