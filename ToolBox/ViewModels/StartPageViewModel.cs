using GalaSoft.MvvmLight;
using ToolBox.Models;

namespace ToolBox.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        private IDataService _service;
        public StartPageViewModel(IDataService service)
        {
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
    }
}