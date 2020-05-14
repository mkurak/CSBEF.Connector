using System.Net.Http;

namespace CSBEF.Connector.Models
{
    public class PostFileRequestModel
    {
        public string Action { get; set; }
        public MultipartFormDataContent FormData { get; set; }
    }
}
