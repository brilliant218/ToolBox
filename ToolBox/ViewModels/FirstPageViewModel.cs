using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace ToolBox.ViewModels
{
    public class FirstPageViewModel : ViewModelBase
    {
        private INavigationService _nav;
        public FirstPageViewModel(INavigationService nav)
        {
            _nav = nav;
        }

        public string SecondPageKey
        {
            get
            {
                return "SecondPage";
            }

        }

        public RelayCommand NavigationCommand
        {
            get { return new RelayCommand(() => _nav.NavigateTo(SecondPageKey)); }
        }

        public RelayCommand NavigationBackCommand
        {
            get { return new RelayCommand(() => _nav.GoBack()); }
        }
    } 
}
