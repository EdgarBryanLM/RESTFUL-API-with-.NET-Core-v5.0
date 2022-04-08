using AutoMapper;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrasture.Mappings
{
  public  class AutomapperProfile:Profile
    {


        public AutomapperProfile()
        {
            CreateMap<Post, PostDto>();

            CreateMap<PostDto, Post>();
        }
    }
}
