using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TertiaryMusicAwardsMobile.Services;

namespace TertiaryMusicAwardsMobile.ViewModels
{
    public abstract class VotingBaseViewModel : INotifyPropertyChanged
    {
        protected IAppNavService NavService { get; private set; }

        bool _isProcessBusy;
        public bool IsProcessBusy
        {
            get { return _isProcessBusy; }
            set
            {
                _isProcessBusy = value;
                OnPropertyChanged();
                OnIsBusyChanged();
            }
        }

        protected VotingBaseViewModel(IAppNavService navService)
        {
            NavService = navService;
        }

        protected virtual void OnIsBusyChanged()
        {
            //we are processing our information   
        }

        public abstract Task Init();
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public abstract class AppBaseViewModel<AppParam> : VotingBaseViewModel
    {
        protected AppBaseViewModel(IAppNavService navService) : base(navService)
        {
        }

        public override async Task Init()
        {
            await Init(default(AppParam));
        }
        public abstract Task Init(AppParam appDetails);
    }
}