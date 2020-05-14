namespace CSBEF.Connector.Models
{
    public class GetWithHashRequestModel
    {
        public string Action { get; set; } = "Get";
        public string Where { get; set; } = "Status = true";
        public string Order { get; set; } = string.Empty;
        public string HashSecretKey { get; set; } = string.Empty;
    }
}
