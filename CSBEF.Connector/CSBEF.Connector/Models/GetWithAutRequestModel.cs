﻿namespace CSBEF.Connector.Models
{
    public class GetWithAutRequestModel
    {
        public string Action { get; set; } = "Get";
        public string Where { get; set; } = "Status = true";
        public string Order { get; set; } = "";
        public string Token { get; set; } = "";
    }
}
