using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HealthCrossplatform.Core.Models;
using HealthCrossplatform.Core.Net;
using HealthCrossplatform.Core.Services.Interface;

namespace HealthCrossplatform.Core.Services.Impl
{
    public class PeopleService : IUserService
    {
        private readonly IRestClient _restClient;

        public PeopleService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public Task<PagedResult<User>> GetUsersAsync(string url = null)
        {
            //return string.IsNullOrEmpty(url)
            //? _restClient.MakeApiCall<PagedResult<User>>("/user/", HttpMethod.Get)
            //: _restClient.MakeApiCall<PagedResult<User>>(url, HttpMethod.Get);
            return Task.FromResult(GetMockedUsers());
        }

        public Task<User> GetUserAsync()
        {
            //return _restClient.MakeApiCall<User>($"/user/1/", HttpMethod.Get);
            return Task.FromResult(GetMockedUser());
        }

        private PagedResult<User> GetMockedUsers()
        {
            return new PagedResult<User>()
            {
                Count = 3,
                Next = string.Empty,
                Previous = string.Empty,
                Results = new List<User>
                {
                    new User
                    {
                        Username = "Yoda",
                        Emailaddress = "Master@wwwhackcom.net",
                        Firstname = "Yoda"
                    },
                    new User
                    {
                        Username = "Kenobi",
                        Emailaddress = "Kenobi@wwwhackcom.net",
                        Firstname = "Kenobi"
                    },
                    new User
                    {
                        Username = "Windu",
                        Emailaddress = "Kenobi@wwwhackcom.net",
                        Firstname = "Windu"
                    }
                }
            };
        }

        private User GetMockedUser()
        {
            return new User 
            {
                Username = "Yoda",
                Emailaddress = "Master@wwwhackcom.net",
                Firstname = "Yoda"
            };
        }
    }
}
