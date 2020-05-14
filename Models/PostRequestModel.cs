namespace CSBEF.Connector.Models
{
    public class PostRequestModel<T>
        where T : class
    {
        public string Action { get; set; } = "Get";
        public T SendDataModel { get; set; }
    }
}
