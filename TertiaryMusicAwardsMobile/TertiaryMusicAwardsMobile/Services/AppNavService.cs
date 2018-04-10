using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TertiaryMusicAwardsMobile.Services;
using TertiaryMusicAwardsMobile.ViewModels;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppNavService))]
namespace TertiaryMusicAwardsMobile.Services
{
    public class AppNavService : IAppNavService
    {
        public INavigation navigation { get; set; }
        readonly IDictionary<Type, Type> _viewMapping = new Dictionary<Type, Type>();

        // register our viewmodel and view within our dictionary
        public void RegisterViewMapping(Type viewModel, Type view)
        {
            _viewMapping.Add(viewModel, view);
        }

        //instance method that allows us to move back to the previous page.
        public async Task PreviousPage()
        {
            //check to see if we can move back to the previous page
            if (navigation.NavigationStack != null && navigation.NavigationStack.Count > 0)
            {
                await navigation.PopAsync(true);
            }
        }

        //instance method that takes us back to the main root page
        public async Task BackToMainPage()
        {
            await navigation.PopToRootAsync(true);
        }

        //instance method that navigates to a specific viewModel
        public async Task NavigateToViewModel<ViewModel, VotingParam>(VotingParam parameter) where ViewModel : VotingBaseViewModel
        {
            Type viewType;

            if (_viewMapping.TryGetValue(typeof(ViewModel), out viewType))
            {
                var constructor = viewType.GetTypeInfo()
                    .DeclaredConstructors
                    .FirstOrDefault(dc => dc.GetParameters()
                    .Count() <= 0);

                var view = constructor.Invoke(null) as Page;
                await navigation.PushAsync(view, true);
            }

            if (navigation.NavigationStack.Last().BindingContext is AppBaseViewModel<VotingParam>)
                await ((AppBaseViewModel<VotingParam>)(navigation.NavigationStack.Last().BindingContext)).Init(parameter);
        }
    }
}
