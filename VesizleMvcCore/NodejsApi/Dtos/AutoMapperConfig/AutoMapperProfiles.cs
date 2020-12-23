using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using VesizleMvcCore.Constants;
using VesizleMvcCore.Models;
using VesizleMvcCore.NodejsApi.ApiResults;
using VesizleMvcCore.NodejsApi.Dtos;
using VesizleMvcCore.NodejsApi.Entities;

namespace VesizleMvcCore.NodejsApi.Dtos.AutoMapperConfig
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<LoginViewModel, UserForLoginDto>();
            CreateMap<BaseListMovie, PopularCardModel>().ForMember(model => model.VoteAverage, expression => expression.MapFrom(result => result.Vote_Average)).ForMember(model => model.MovieId, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.PosterUrl, expression => expression.MapFrom(result => AppConstants.BasePosterUrl + result.Poster_Path));

            CreateMap<BaseListMovie, DiscoverCardModel>().ForMember(model => model.VoteAverage, expression => expression.MapFrom(result => result.Vote_Average)).ForMember(model => model.MovieId, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.PosterUrl, expression => expression.MapFrom(result => AppConstants.BasePosterUrl + result.Poster_Path));

            CreateMap<ApiMovieDetailsResult,MovieDetailsViewModel>().ForMember(model => model.MovieId, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.PosterUrl, expression => expression.MapFrom(result => AppConstants.BasePosterUrl + result.Poster_Path));
        }
    }
}
