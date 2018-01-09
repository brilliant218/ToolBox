namespace ToolBox.Models
{
    public class TestDataService : IDataService
    {
        public DataItem GetDataItem()
        {
            return new DataItem() {IsLoading = true, Title = "Test"};
        }
    }
}