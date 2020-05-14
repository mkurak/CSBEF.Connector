namespace CSBEF.Connector.Models
{
    public class CustomGetRequestModel
    {
        public string Action { get; set; } = "Get";
        public string Params { get; set; } = string.Empty;
    }
}
