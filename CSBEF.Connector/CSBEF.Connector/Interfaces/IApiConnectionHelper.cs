using CSBEF.Connector.Models;
using CSBEF.Core.Interfaces;
using System.Threading.Tasks;

namespace CSBEF.Connector.Interfaces
{
    public interface IApiConnectionHelper
    {
        Task<IReturnModel<T>> GetWithHashAsync<T>(GetWithHashRequestModel args);
        Task<IReturnModel<T>> GetWithAuthWithHashAsync<T>(GetWithAuthWithHashRequestModel args);
        Task<IReturnModel<T>> GetWithAutAsync<T>(GetWithAutRequestModel args);
        Task<IReturnModel<T>> GetAsync<T>(GetRequestModel args);
        Task<IReturnModel<T>> PostAsync<T, T2>(PostRequestModel<T2> args) where T2 : class;
        Task<IReturnModel<T>> PostFileAsync<T>(PostFileRequestModel args);
        Task<IReturnModel<T>> ListWithHashAsync<T>(ListWithHashRequestModel args);
        Task<IReturnModel<T>> ListWithAuthWithHashAsync<T>(ListWithAuthWithHashRequestModel args);
        Task<IReturnModel<T>> ListWithAutAsync<T>(ListWithAutRequestModel args);
        Task<IReturnModel<T>> ListAsync<T>(ListRequestModel args);
        Task<IReturnModel<T>> CustomGetAsync<T>(CustomGetRequestModel args);
        Task<IReturnModel<T>> CustomGetWithAutAsync<T>(CustomGetWithAutRequestModel args);
    }
}
