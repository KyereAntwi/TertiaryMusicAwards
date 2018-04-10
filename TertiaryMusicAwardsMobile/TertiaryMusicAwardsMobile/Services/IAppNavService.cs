using System.Threading.Tasks;
using TertiaryMusicAwardsMobile.ViewModels;

namespace TertiaryMusicAwardsMobile.Services
{
    public interface IAppNavService
    {
        //navigate back to the previous page in the stack
        Task PreviousPage();

        //navigate to the first page within the navigationstack
        Task BackToMainPage();

        //navigate to a particular viewmodel 
        Task NavigateToViewModel<ViewModel, TParameter>(TParameter parameter) where ViewModel : VotingBaseViewModel;
    }
}
