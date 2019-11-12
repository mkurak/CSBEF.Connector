using CSBEF.Connector.Models;
using CSBEF.Core.Models;
using System.Threading.Tasks;

namespace CSBEF.Connector.Interfaces
{
    public interface IApiConnectionHelper
    {
        Task<ReturnModel<T>> GetWithHashAsync<T>(GetWithHashRequestModel args);
        Task<ReturnModel<T>> GetWithAuthWithHashAsync<T>(GetWithAuthWithHashRequestModel args);
        Task<ReturnModel<T>> GetWithAutAsync<T>(GetWithAutRequestModel args);
        Task<ReturnModel<T>> GetAsync<T>(GetRequestModel args);
        Task<ReturnModel<T>> PostAsync<T, T2>(PostRequestModel<T2> args) where T2 : class;
        Task<ReturnModel<T>> PostFileAsync<T, T2>(PostFileRequestModel args);
        Task<ReturnModel<T>> ListWithHashAsync<T>(ListWithHashAsyncRequestModel args);
        Task<ReturnModel<T>> ListWithAuthWithHashAsync<T>(ListWithAuthWithHashRequestModel args);
        Task<ReturnModel<T>> ListWithAutAsync<T>(ListWithAutRequestModel args);
        Task<ReturnModel<T>> ListAsync<T>(ListRequestModel args);
        Task<ReturnModel<T>> CustomGetAsync<T>(CustomGetRequestModel args);
        Task<ReturnModel<T>> CustomGetWithAutAsync<T>(CustomGetWithAutRequestModel args);
    }
}
