using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TertiaryMusicAwardsMobile.Models;
using TertiaryMusicAwardsMobile.Services;
using Xamarin.Forms;

namespace TertiaryMusicAwardsMobile.ViewModels
{
    class CategoryNomineesViewModel : VotingBaseViewModel
    {
        ObservableCollection<Nominee> _categoryNominees;
        AwardCategory Category;

        public ObservableCollection<Nominee> Nominees
        {
            get { return _categoryNominees; }
            set
            {
                _categoryNominees = value;
                OnPropertyChanged();
            }
        }

        public CategoryNomineesViewModel(IAppNavService navService, AwardCategory awardCategory) : base(navService)
        {
            _categoryNominees = new ObservableCollection<Nominee>();
            this.Category = awardCategory;
        }

        public override async Task Init()
        {
            await LoadCategoryNominees();
        }

        public async Task LoadCategoryNominees()
        {
            if (IsProcessBusy) return;
            IsProcessBusy = true;

            try
            {
                Nominees = new ObservableCollection<Nominee>(await DependencyService.Get<IWebServices>().GetCategoryNominees(this.Category.Id));
            }
            finally
            {
                if (Nominees != null) IsProcessBusy = false;
                else IsProcessBusy = true;
            }

            await Task.Delay(1000);

            await Task.Factory.StartNew(() =>
            {
            });
        }
    }
}
