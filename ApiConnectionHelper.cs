using CSBEF.Connector.Helpers;
using CSBEF.Connector.Interfaces;
using CSBEF.Connector.Models;
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
        private string ModuleName { get; set; }
        private string ServiceName { get; set; }
        private string ApiUrl { get; set; }
        private string ServiceUrl { get; set; }

        public ApiConnectionHelper(string moduleName, string serviceName, string apiUrl)
        {
            ModuleName = moduleName;
            ServiceName = serviceName;
            ApiUrl = apiUrl;

            ServiceUrl = ApiUrl + "/" + ModuleName + "/" + ServiceName + "/";
        }

        public async Task<ConnectorReturnModel<T>> GetWithHashAsync<T>(GetWithHashRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ConnectorReturnModel<T> rtn = new ConnectorReturnModel<T>();

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page=0&PageSize=0";
                var generateHash = Tools.ToSha1(args.Where + args.Order + "0" + "0" + args.HashSecretKey);

                generateUrl += "&Hash=" + generateHash;

                using var httpClient = new HttpClient();
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ConnectorReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn.Error = new ConnectorErrorResult
                {
                    Status = true,
                    Code = "000",
                    Message = ex.Message != null ? ex.Message : "error"
                };
            }

            return rtn;
        }

        public async Task<ConnectorReturnModel<T>> GetWithAuthWithHashAsync<T>(GetWithAuthWithHashRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ConnectorReturnModel<T> rtn = new ConnectorReturnModel<T>();

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page=0&PageSize=0";
                var generateHash = Tools.ToSha1(args.Where + args.Order + "0" + "0" + args.HashSecretKey);

                generateUrl += "&Hash=" + generateHash;

                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", args.Token);
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ConnectorReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn.Error = new ConnectorErrorResult
                {
                    Status = true,
                    Code = "000",
                    Message = ex.Message != null ? ex.Message : "error"
                };
            }

            return rtn;
        }

        public async Task<ConnectorReturnModel<T>> GetWithAutAsync<T>(GetWithAutRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ConnectorReturnModel<T> rtn = new ConnectorReturnModel<T>();

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page=0&PageSize=0";

                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", args.Token);
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ConnectorReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn.Error = new ConnectorErrorResult
                {
                    Status = true,
                    Code = "000",
                    Message = ex.Message != null ? ex.Message : "error"
                };
            }

            return rtn;
        }

        public async Task<ConnectorReturnModel<T>> GetAsync<T>(GetRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ConnectorReturnModel<T> rtn = new ConnectorReturnModel<T>();

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page=0&PageSize=0";

                using var httpClient = new HttpClient();
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ConnectorReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn.Error = new ConnectorErrorResult
                {
                    Status = true,
                    Code = "000",
                    Message = ex.Message != null ? ex.Message : "error"
                };
            }

            return rtn;
        }

        public async Task<ConnectorReturnModel<T>> PostAsync<T, T2>(PostRequestModel<T2> args)
            where T2 : class
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ConnectorReturnModel<T> rtn = new ConnectorReturnModel<T>();

            try
            {
                var generateUrl = ServiceUrl + args.Action;

                StringContent content = new StringContent(JsonConvert.SerializeObject(args.SendDataModel), Encoding.UTF8, "application/json");
                using var httpClient = new HttpClient();
                using var response = await httpClient.PostAsync(generateUrl, content).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ConnectorReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn.Error = new ConnectorErrorResult
                {
                    Status = true,
                    Code = "000",
                    Message = ex.Message != null ? ex.Message : "error"
                };
            }

            return rtn;
        }

        public async Task<ConnectorReturnModel<T>> PostFileAsync<T>(PostFileRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ConnectorReturnModel<T> rtn = new ConnectorReturnModel<T>();

            try
            {
                var generateUrl = ServiceUrl + args.Action;

                using var httpClient = new HttpClient();
                using var response = await httpClient.PostAsync(generateUrl, args.FormData).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ConnectorReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn.Error = new ConnectorErrorResult
                {
                    Status = true,
                    Code = "000",
                    Message = ex.Message != null ? ex.Message : "error"
                };
            }

            return rtn;
        }

        public async Task<ConnectorReturnModel<T>> ListWithHashAsync<T>(ListWithHashRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ConnectorReturnModel<T> rtn = new ConnectorReturnModel<T>();

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page=" + args.Page + "&PageSize=" + args.PageSize;
                var stringOfHash = args.Where + args.Order + args.Page.ToString() + args.PageSize.ToString() + args.HashSecretKey;
                var generateHash = Tools.ToSha1(stringOfHash);

                generateUrl += "&Hash=" + generateHash;

                using var httpClient = new HttpClient();
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ConnectorReturnModel<T>>(apiResponse, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore,

                });
            }
            catch (Exception ex)
            {
                rtn.Error = new ConnectorErrorResult
                {
                    Status = true,
                    Code = "000",
                    Message = ex.Message != null ? ex.Message : "error"
                };
            }

            return rtn;
        }

        public async Task<ConnectorReturnModel<T>> ListWithAuthWithHashAsync<T>(ListWithAuthWithHashRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ConnectorReturnModel<T> rtn = new ConnectorReturnModel<T>();

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page=" + args.Page + "&PageSize=" + args.PageSize;
                var generateHash = Tools.ToSha1(args.Where + args.Order + args.Page + args.PageSize + args.HashSecretKey);

                generateUrl += "&Hash=" + generateHash;

                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", args.Token);
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ConnectorReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn.Error = new ConnectorErrorResult
                {
                    Status = true,
                    Code = "000",
                    Message = ex.Message != null ? ex.Message : "error"
                };
            }

            return rtn;
        }

        public async Task<ConnectorReturnModel<T>> ListWithAutAsync<T>(ListWithAutRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ConnectorReturnModel<T> rtn = new ConnectorReturnModel<T>();

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page=" + args.Page + "&PageSize=" + args.PageSize;

                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", args.Token);
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ConnectorReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn.Error = new ConnectorErrorResult
                {
                    Status = true,
                    Code = "000",
                    Message = ex.Message != null ? ex.Message : "error"
                };
            }

            return rtn;
        }

        public async Task<ConnectorReturnModel<T>> ListAsync<T>(ListRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ConnectorReturnModel<T> rtn = new ConnectorReturnModel<T>();

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?Where=" + args.Where + "&Order=" + args.Order + "&Page=" + args.Page + "&PageSize=" + args.PageSize;

                using var httpClient = new HttpClient();
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ConnectorReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn.Error = new ConnectorErrorResult
                {
                    Status = true,
                    Code = "000",
                    Message = ex.Message != null ? ex.Message : "error"
                };
            }

            return rtn;
        }

        public async Task<ConnectorReturnModel<T>> CustomGetAsync<T>(CustomGetRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ConnectorReturnModel<T> rtn = new ConnectorReturnModel<T>();

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?" + args.Params;

                using var httpClient = new HttpClient();
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ConnectorReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn.Error = new ConnectorErrorResult
                {
                    Status = true,
                    Code = "000",
                    Message = ex.Message != null ? ex.Message : "error"
                };
            }

            return rtn;
        }

        public async Task<ConnectorReturnModel<T>> CustomGetWithAutAsync<T>(CustomGetWithAutRequestModel args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ConnectorReturnModel<T> rtn = new ConnectorReturnModel<T>();

            try
            {
                var generateUrl = ServiceUrl + args.Action + "?" + args.Params;

                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", args.Token);
                using var response = await httpClient.GetAsync(generateUrl).ConfigureAwait(false);
                string apiResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                rtn = JsonConvert.DeserializeObject<ConnectorReturnModel<T>>(apiResponse);
            }
            catch (Exception ex)
            {
                rtn.Error = new ConnectorErrorResult
                {
                    Status = true,
                    Code = "000",
                    Message = ex.Message != null ? ex.Message : "error"
                };
            }

            return rtn;
        }
    }
}
