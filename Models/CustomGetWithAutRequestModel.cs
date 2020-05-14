namespace CSBEF.Connector.Models
{
    public class CustomGetWithAutRequestModel
    {
        public string Action { get; set; } = "Get";
        public string Params { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
