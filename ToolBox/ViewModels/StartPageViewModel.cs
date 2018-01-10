using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ToolBox.Models;

namespace ToolBox.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        private INavigationService _nav;
        private IDataService _service;
        public StartPageViewModel(INavigationService nav, IDataService service)
        {
            _nav = nav;
            _service = service;
        }

        public bool IsLoading
        {
            get { return _service.GetDataItem().IsLoading; }
        }

        public string Title
        {
            get { return _service.GetDataItem().Title; }
        }

        public string FirstPageKey
        {
            get
            {
                return "FirstPage";
            }

        }

        public string SecondPageKey
        {
            get
            {
                return "SecondPage";
            }

        }

        //Command， CommandParameter
        public ICommand NavigationCommand
        {
            get { return new RelayCommand<string>((e) => _nav.NavigateTo(e)); }
        }
    }
}