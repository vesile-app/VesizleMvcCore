using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using VesizleMvcCore.Models;
using VesizleMvcCore.NodejsApi.Dtos;

namespace VesizleMvcCore.NodejsApi.Dtos.AutoMapperConfig
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<LoginViewModel, UserForLoginDto>();
            //    CreateMap<UserForRegisterDto, VesizleUser>();
            //    CreateMap<UserForPutDto, VesizleUser>();
            //    CreateMap<RoleForCreateDto, IdentityRole>();
            //    CreateMap<RoleForPutDto, IdentityRole>();
            //    CreateMap<VesizleUser, CurrentUser>();
        }
    }
}
