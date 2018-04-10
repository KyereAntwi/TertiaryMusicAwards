using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TertiaryMusicAwardsMobile.Models;
using TertiaryMusicAwardsMobile.Services;
using Xamarin.Forms;

namespace TertiaryMusicAwardsMobile.ViewModels
{
    public class NomineesPageViewModel : VotingBaseViewModel
    {
        ObservableCollection<Nominee> _nominees;
        public ObservableCollection<Nominee> Nominees
        {
            get { return _nominees; }
            set
            {
                _nominees = value;
                OnPropertyChanged();
            }
        }

        public NomineesPageViewModel(IAppNavService navService) : base(navService)
        {
            Nominees = new ObservableCollection<Nominee>();
        }

        public override async Task Init()
        {
            await LoadNomineesDetails();
        }

        public async Task LoadNomineesDetails()
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
                Nominees = new ObservableCollection<Nominee>(await DependencyService.Get<IWebServices>().GetNominees());
            }
            finally
            {
                if (Nominees != null)
                    IsProcessBusy = false;
                else
                    IsProcessBusy = true;
            }

            //add a temporary timer, so that we can see our progress indicator working
            await Task.Delay(1000);

            await Task.Factory.StartNew(() => {});
        }
    }
}
