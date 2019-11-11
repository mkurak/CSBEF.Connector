using CSBEF.Connector.Interfaces;

namespace CSBEF.Connector.Models
{
    public class ErrorResult
    {
        #region Public Properties

        public string Message { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }

        #endregion Public Properties
    }
}