namespace CSBEF.Connector.Models
{
    public class GetRequestModel
    {
        public string Action { get; set; } = "Get";
        public string Where { get; set; } = "Status = true";
        public string Order { get; set; } = "";
    }
}
