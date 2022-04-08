using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrasture.Interfaces;
using System;

namespace SocialMedia.Infrasture.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;

        }

        public Uri getPostPaginationUri(POSTQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }

    }
}
