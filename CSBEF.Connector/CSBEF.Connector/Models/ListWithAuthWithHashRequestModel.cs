namespace CSBEF.Connector.Models
{
    public class ListWithAuthWithHashRequestModel
    {
        public string Action { get; set; } = "Get";
        public string Where { get; set; } = "Status = true";
        public string Order { get; set; } = "";
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = int.MaxValue;
        public string Token { get; set; } = "";
        public string HashSecretKey { get; set; } = "";
    }
}
