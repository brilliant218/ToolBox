namespace ToolBox.Models
{
    public class DataService : IDataService
    {
        public DataItem GetDataItem() => new DataItem() {IsLoading = false, Title = "Hi,Jarod"};

    }
}