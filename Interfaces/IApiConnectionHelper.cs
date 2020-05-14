using CSBEF.Connector.Models;
using System.Threading.Tasks;

namespace CSBEF.Connector.Interfaces
{
    public interface IApiConnectionHelper
    {
        Task<ConnectorReturnModel<T>> GetWithHashAsync<T>(GetWithHashRequestModel args);
        Task<ConnectorReturnModel<T>> GetWithAuthWithHashAsync<T>(GetWithAuthWithHashRequestModel args);
        Task<ConnectorReturnModel<T>> GetWithAutAsync<T>(GetWithAutRequestModel args);
        Task<ConnectorReturnModel<T>> GetAsync<T>(GetRequestModel args);
        Task<ConnectorReturnModel<T>> PostAsync<T, T2>(PostRequestModel<T2> args) where T2 : class;
        Task<ConnectorReturnModel<T>> PostFileAsync<T>(PostFileRequestModel args);
        Task<ConnectorReturnModel<T>> ListWithHashAsync<T>(ListWithHashRequestModel args);
        Task<ConnectorReturnModel<T>> ListWithAuthWithHashAsync<T>(ListWithAuthWithHashRequestModel args);
        Task<ConnectorReturnModel<T>> ListWithAutAsync<T>(ListWithAutRequestModel args);
        Task<ConnectorReturnModel<T>> ListAsync<T>(ListRequestModel args);
        Task<ConnectorReturnModel<T>> CustomGetAsync<T>(CustomGetRequestModel args);
        Task<ConnectorReturnModel<T>> CustomGetWithAutAsync<T>(CustomGetWithAutRequestModel args);
    }
}
