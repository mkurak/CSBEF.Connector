using System;
using System.Collections.Generic;
using System.Text;

namespace CSBEF.Connector.Models
{
    public class GetWithAuthWithHashRequestModel
    {
        public string Action { get; set; } = "Get";
        public string Where { get; set; } = "Status = true";
        public string Order { get; set; } = "";
        public string Token { get; set; } = "";
        public string HashSecretKey { get; set; } = "";
    }
}
