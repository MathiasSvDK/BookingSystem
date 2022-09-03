using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Web.Exceptions;
using Web.Service.IdentityService;

namespace Web.Service
{
    public class ApiService : IApiService
    {

        private HttpClient httpClient;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;

        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public ApiService(IConfiguration configuration, ITokenService tokenService)
        {
#if DEBUG
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true;
#endif
            httpClient = new HttpClient(httpClientHandler);
            _config = configuration;
            _tokenService = tokenService;
        }

        #region GET
        public async Task<T> GetAsync<T>(string url)
        {
            UriBuilder builder = new UriBuilder(_config["Data:ApiIP"])
            {
                Path = $"{url}"
            };
            try
            {
                await ConfigureHttpClient();

                string jsonResult = string.Empty;

                HttpResponseMessage responseMessage = await httpClient.GetAsync(builder.ToString());

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = JsonConvert.DeserializeObject<T>(jsonResult);
                    return json;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ServiceAuthenticationException(jsonResult);
                }

                throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion

        #region POST
        public async Task<T> PostAsync<T>(string url, T data)
        {
            UriBuilder builder = new UriBuilder(_config["Data:ApiIP"])
            {
                Path = $"{url}"
            };
            try
            {
                await ConfigureHttpClient();

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                string jsonResult = string.Empty;

                var responseMessage = await httpClient.PostAsync(builder.ToString(), content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = JsonConvert.DeserializeObject<T>(jsonResult);
                    return json;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ServiceAuthenticationException(jsonResult);
                }

                throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        //public async Task<TR> PostAsync<T, TR>(string uri, T data, string authToken = "")
        //{
        //    try
        //    {
        //        ConfigureHttpClient(authToken);

        //        var content = new StringContent(JsonConvert.SerializeObject(data));
        //        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //        string jsonResult = string.Empty;

        //        var responseMessage = await httpClient.PostAsync(uri, content);

        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        //            var json = JsonConvert.DeserializeObject<TR>(jsonResult);
        //            return json;
        //        }

        //        if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
        //            responseMessage.StatusCode == HttpStatusCode.Unauthorized)
        //        {
        //            throw new ServiceAuthenticationException(jsonResult);
        //        }

        //        throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);

        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}
        #endregion

        #region PUT
        public async Task<T> PutAsync<T>(string url, T data)
        {
            UriBuilder builder = new UriBuilder(_config["Data:ApiIP"])
            {
                Path = $"{url}"
            };
            try
            {
                await ConfigureHttpClient();

                var content = new StringContent(JsonConvert.SerializeObject(data));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                string jsonResult = string.Empty;

                var responseMessage = await httpClient.PutAsync(builder.ToString(), content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var json = JsonConvert.DeserializeObject<T>(jsonResult);
                    return json;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                    responseMessage.StatusCode == HttpStatusCode.Unauthorized ||
                    responseMessage.StatusCode == HttpStatusCode.MethodNotAllowed)
                {
                    throw new ServiceAuthenticationException(jsonResult);
                }

                throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);

            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion

        #region DELETE
        public async Task DeleteAsync(string url)
        {
            UriBuilder builder = new UriBuilder(_config["Data:ApiIP"])
            {
                Path = $"{url}"
            };
            try
            {
                await ConfigureHttpClient();
                await httpClient.DeleteAsync(builder.ToString());
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion


        #region HELPER
        private async Task ConfigureHttpClient()
        {
            TokenResponse tokenResponse = await _tokenService.GetToken(_config["Data:ApiScope"]);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(tokenResponse.AccessToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);
            }
            else
            {
                httpClient.DefaultRequestHeaders.Authorization = null;
            }
        }
        #endregion

    }
}
