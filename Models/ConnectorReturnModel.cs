namespace CSBEF.Connector.Models
{
    public class ConnectorReturnModel<T>
    {
        public ConnectorErrorResult Error { get; set; }
        public T Result { get; set; }
    }
}
