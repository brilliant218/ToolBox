using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace ToolBox.ViewModels
{
    public class SecondPageViewModel : ViewModelBase
    {
        private INavigationService _nav;
        public SecondPageViewModel(INavigationService nav)
        {
            _nav = nav;
        }

        public string FirstPageKey
        {
            get
            {
                return "FirstPage";
            }

        }

        public RelayCommand NavigationCommand
        {
            get { return new RelayCommand(() => _nav.NavigateTo(FirstPageKey)); }
        }

        public RelayCommand NavigationBackCommand
        {
            get { return new RelayCommand(() => _nav.GoBack()); }
        }
    }
}
