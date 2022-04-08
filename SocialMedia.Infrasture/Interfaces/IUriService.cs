using SocialMedia.Core.QueryFilters;
using System;

namespace SocialMedia.Infrasture.Interfaces
{
    public interface IUriService
    {
        Uri getPostPaginationUri(POSTQueryFilter filter, string actionUrl);
    }
}