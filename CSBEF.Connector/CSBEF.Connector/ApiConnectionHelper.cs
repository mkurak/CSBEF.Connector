using CS.CommonTools;
using CSBEF.Connector.Enums;
using CSBEF.Connector.Interfaces;
using CSBEF.Connector.Models;
using CSBEF.Core.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CSBEF.Connector
{
    public class ApiConnectionHelper : IApiConnectionHelper
    {
        private ILogger<ILog> Logger { get; set; }
        private string ModuleName { get; set; }
        private string ServiceName { get; set; }
        private string ApiUrl { get; set; }
        private string ServiceUrl { get; set; }

        public ApiConnectionHelper(ILogger<ILog> logger, string moduleName, string serviceName, string apiUrl)
        {
            Logger = logger;
            ModuleName = moduleName;
            ServiceName = serviceName;
            ApiUrl = apiUrl;

            ServiceUrl = ApiUrl + "/" + ModuleName + "/" + ServiceName + "/";
        }

        public async Task<ReturnModel<T>> GetWithHashAsync<T>(GetWithHashRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ReturnModel<T> rtn = new ReturnModel<T>(Logger);

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page=0&PageSize=0";
                var generateHash = Tools.ToSha1(args.Where + args.Order + "0" + "0" + args.HashSecretKey);

                generateUrl += "&Hash=" + generateHash;

                using var httpClient = new HttpClient();
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn = rtn.SendError(GlobalErrors.TechnicalError, ex);
            }

            return rtn;
        }

        public async Task<ReturnModel<T>> GetWithAuthWithHashAsync<T>(GetWithAuthWithHashRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ReturnModel<T> rtn = new ReturnModel<T>(Logger);

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page=0&PageSize=0";
                var generateHash = Tools.ToSha1(args.Where + args.Order + "0" + "0" + args.HashSecretKey);

                generateUrl += "&Hash=" + generateHash;

                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", args.Token);
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn = rtn.SendError(GlobalErrors.TechnicalError, ex);
            }

            return rtn;
        }

        public async Task<ReturnModel<T>> GetWithAutAsync<T>(GetWithAutRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ReturnModel<T> rtn = new ReturnModel<T>(Logger);

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page=0&PageSize=0";

                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", args.Token);
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn = rtn.SendError(GlobalErrors.TechnicalError, ex);
            }

            return rtn;
        }

        public async Task<ReturnModel<T>> GetAsync<T>(GetRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ReturnModel<T> rtn = new ReturnModel<T>(Logger);

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page=0&PageSize=0";

                using var httpClient = new HttpClient();
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn = rtn.SendError(GlobalErrors.TechnicalError, ex);
            }

            return rtn;
        }

        public async Task<ReturnModel<T>> PostAsync<T, T2>(PostRequestModel<T2> args)
            where T2 : class
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ReturnModel<T> rtn = new ReturnModel<T>(Logger);

            try
            {
                var generateUrl = ServiceUrl + args.Action;

                StringContent content = new StringContent(JsonConvert.SerializeObject(args.SendDataModel), Encoding.UTF8, "application/json");
                using var httpClient = new HttpClient();
                using var response = await httpClient.PostAsync(generateUrl, content).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn = rtn.SendError(GlobalErrors.TechnicalError, ex);
            }

            return rtn;
        }

        public async Task<ReturnModel<T>> PostFileAsync<T>(PostFileRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ReturnModel<T> rtn = new ReturnModel<T>(Logger);

            try
            {
                var generateUrl = ServiceUrl + args.Action;

                using var httpClient = new HttpClient();
                using var response = await httpClient.PostAsync(generateUrl, args.FormData).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn = rtn.SendError(GlobalErrors.TechnicalError, ex);
            }

            return rtn;
        }

        public async Task<ReturnModel<T>> ListWithHashAsync<T>(ListWithHashRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ReturnModel<T> rtn = new ReturnModel<T>(Logger);

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page="+ args.Page +"&PageSize=" + args.PageSize;
                var stringOfHash = args.Where + args.Order + args.Page.ToString() + args.PageSize.ToString() + args.HashSecretKey;
                var generateHash = Tools.ToSha1(stringOfHash);

                generateUrl += "&Hash=" + generateHash;

                using var httpClient = new HttpClient();
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn = rtn.SendError(GlobalErrors.TechnicalError, ex);
            }

            return rtn;
        }

        public async Task<ReturnModel<T>> ListWithAuthWithHashAsync<T>(ListWithAuthWithHashRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ReturnModel<T> rtn = new ReturnModel<T>(Logger);

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page="+ args.Page +"&PageSize=" + args.PageSize;
                var generateHash = Tools.ToSha1(args.Where + args.Order + args.Page + args.PageSize + args.HashSecretKey);

                generateUrl += "&Hash=" + generateHash;

                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", args.Token);
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn = rtn.SendError(GlobalErrors.TechnicalError, ex);
            }

            return rtn;
        }

        public async Task<ReturnModel<T>> ListWithAutAsync<T>(ListWithAutRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ReturnModel<T> rtn = new ReturnModel<T>(Logger);

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page="+ args.Page +"&PageSize=" + args.PageSize;

                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", args.Token);
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn = rtn.SendError(GlobalErrors.TechnicalError, ex);
            }

            return rtn;
        }

        public async Task<ReturnModel<T>> ListAsync<T>(ListRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ReturnModel<T> rtn = new ReturnModel<T>(Logger);

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page="+ args.Page +"&PageSize=" + args.PageSize;

                using var httpClient = new HttpClient();
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn = rtn.SendError(GlobalErrors.TechnicalError, ex);
            }

            return rtn;
        }

        public async Task<ReturnModel<T>> CustomGetAsync<T>(CustomGetRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ReturnModel<T> rtn = new ReturnModel<T>(Logger);

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?" + args.Params;

                using var httpClient = new HttpClient();
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn = rtn.SendError(GlobalErrors.TechnicalError, ex);
            }

            return rtn;
        }

        public async Task<ReturnModel<T>> CustomGetWithAutAsync<T>(CustomGetWithAutRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ReturnModel<T> rtn = new ReturnModel<T>(Logger);

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?" + args.Params;

                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", args.Token);
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn = rtn.SendError(GlobalErrors.TechnicalError, ex);
            }

            return rtn;
        }
    }
}
