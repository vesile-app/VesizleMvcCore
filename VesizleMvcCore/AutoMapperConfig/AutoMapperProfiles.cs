using AutoMapper;
using VesizleMvcCore.Constants;
using VesizleMvcCore.Identity;
using VesizleMvcCore.Identity.Entities;
using VesizleMvcCore.Models;
using VesizleMvcCore.Models.Dto;
using VesizleMvcCore.NodejsApi.ApiResults;
using VesizleMvcCore.NodejsApi.Entities;

namespace VesizleMvcCore.AutoMapperConfig
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterViewModel, VesizleUser>();
            CreateMap<VesizleUser, UserDetailViewModel>();
            CreateMap<LoginViewModel, VesizleUser>();
            CreateMap<ReminderDto, Reminder>();
            CreateMap<BaseListMovie, PopularCardModel>().ForMember(model => model.VoteAverage, expression => expression.MapFrom(result => result.Vote_Average)).ForMember(model => model.MovieId, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.PosterUrl, expression => expression.MapFrom(result => AppConstants.BasePosterUrl + result.Poster_Path));

            CreateMap<BaseListMovie, DiscoverCardModel>().ForMember(model => model.VoteAverage, expression => expression.MapFrom(result => result.Vote_Average)).ForMember(model => model.MovieId, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.PosterUrl, expression => expression.MapFrom(result => AppConstants.BasePosterUrl + result.Poster_Path));

            CreateMap<ApiMovieDetailsResult, FavoriteDetailViewModel>().ForMember(model => model.VoteAverage, expression => expression.MapFrom(result => result.Vote_Average)).ForMember(model => model.MovieId, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.PosterUrl, expression => expression.MapFrom(result => AppConstants.BasePosterUrl + result.Poster_Path));

            CreateMap<ApiMovieDetailsResult,MovieDetailsViewModel>().ForMember(model => model.MovieId, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.PosterUrl, expression => expression.MapFrom(result => AppConstants.BasePosterUrl + result.Poster_Path)).ForMember(model => model.YoutubeUrl, expression => expression.MapFrom(result => AppConstants.BaseYoutubeUrl + result.Videos.Results[0].Key)); 
        }
    }
}
