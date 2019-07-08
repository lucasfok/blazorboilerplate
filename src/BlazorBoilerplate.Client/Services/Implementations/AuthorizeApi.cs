﻿using BlazorBoilerplate.Client.Services.Contracts;
using BlazorBoilerplate.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Services.Implementations
{
    public class AuthorizeApi : IAuthorizeApi
    {
        private readonly HttpClient _httpClient;

        public AuthorizeApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Login(LoginParameters loginParameters)
        {
            await _httpClient.PostJsonAsync<UserInfo>("api/Authorize/Login", loginParameters);
        }

        public async Task Logout()
        {
            var result = await _httpClient.PostAsync("api/Authorize/Logout", null);
            result.EnsureSuccessStatusCode();
        }

        public async Task Register(RegisterParameters registerParameters)
        {
           await _httpClient.PostJsonAsync<UserInfo>("api/Authorize/Register", registerParameters);          
        }

        public async Task<UserInfo> GetUserInfo()
        {
            var result = await _httpClient.GetJsonAsync<UserInfo>("api/Authorize/UserInfo");
            return result;
        }
    }
}
