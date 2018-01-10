using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using ToolBox.Models;
using ToolBox.Views;

namespace ToolBox.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(()=>SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, TestDataService>();
            }
            else
            {
                
                SimpleIoc.Default.Register<IDataService, DataService>();
            }
            SimpleIoc.Default.Register<StartPageViewModel>();

            var nav = new NavigationService();
            nav.Configure("Start", typeof(StartPage));
            nav.Configure("FirstPage", typeof(FirstPage));
            nav.Configure("SecondPage", typeof(SecondPage));
            SimpleIoc.Default.Register<INavigationService>(()=>nav);
            SimpleIoc.Default.Register<FirstPageViewModel>();
            SimpleIoc.Default.Register<SecondPageViewModel>();

            InitializeRegistration();
        }

        public StartPageViewModel StartPage
        {
            get
            {
                //return ServiceLocator.Current.GetInstance<StartPageViewModel>();     
                //also could get more instance by specified key
                var key1 = ServiceLocator.Current.GetInstance<StartPageViewModel>("key1");
                var key2 = ServiceLocator.Current.GetInstance<StartPageViewModel>("key2");
                var key3 = ServiceLocator.Current.GetInstance<StartPageViewModel>("key3");
                //Now the collection will have four instance(defualt, key1, key2, key3)
                var collection = ServiceLocator.Current.GetAllInstances<StartPageViewModel>();

                return (StartPageViewModel)collection.First();


            }
        }

        public FirstPageViewModel FirstPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<FirstPageViewModel>(); }
        }

        public SecondPageViewModel SecondPageInstance
        {
            get { return ServiceLocator.Current.GetInstance<SecondPageViewModel>(); }
        }

        public async void InitializeRegistration()
        {
            //Pass a factory
            SimpleIoc.Default.Register(() => new TimeItem(DateTime.Now));
            await Task.Delay(2000);
            var tm1 = SimpleIoc.Default.GetInstance<TimeItem>();
            await Task.Delay(2000);
            var tm2 = SimpleIoc.Default.GetInstance<TimeItem>();
            await Task.Delay(2000);
            var tm3 = SimpleIoc.Default.GetInstance<TimeItem>();
        }
    }
}
