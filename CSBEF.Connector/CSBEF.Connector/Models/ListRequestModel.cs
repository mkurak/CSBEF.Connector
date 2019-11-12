﻿namespace CSBEF.Connector.Models
{
    public class ListRequestModel
    {
        public string Action { get; set; } = "Get";
        public string Where { get; set; } = "Status = true";
        public string Order { get; set; } = "";
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = int.MaxValue;
    }
}