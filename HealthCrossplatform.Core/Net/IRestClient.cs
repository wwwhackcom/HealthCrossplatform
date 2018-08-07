using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthCrossplatform.Core.Net
{
    public interface IRestClient
    {
        Task<TResult> MakeApiCall<TResult>(string url, HttpMethod method, object data = null)
                        where TResult : class;
    }
}
