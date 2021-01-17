using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vesizle.NodejsApi.Entities;
using VesizleMvcCore.Constants;
using VesizleMvcCore.Identity;
using VesizleMvcCore.Identity.Entities;
using VesizleMvcCore.Models;
using VesizleMvcCore.NodejsApi.ApiResults;
using VesizleMvcCore.NodejsApi.Entities;

namespace VesizleMvcCore.AutoMapperConfig
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RoleCreateViewModel, VesizleRole>();
            CreateMap<VesizleRole, RoleDetailViewModel>();
            CreateMap<VesizleRole, RoleEditViewModel>();
            CreateMap<VesizleRole, RoleDeleteViewModel>();
            CreateMap<RoleEditViewModel, VesizleRole>();
            CreateMap<RoleDeleteViewModel, VesizleRole>();
            CreateMap<RegisterViewModel, VesizleUser>();
            CreateMap<VesizleUser, UserDetailViewModel>();
            CreateMap<VesizleUser, UserDetailForAdminModel>();
            CreateMap<VesizleUser, UserUpdateViewModel>();
            CreateMap<VesizleRole, SelectListItem>().ForMember(model => model.Value, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.Text, expression => expression.MapFrom(result => result.Name));
            CreateMap<RoleDetailViewModel, SelectListItem>().ForMember(model => model.Value, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.Text, expression => expression.MapFrom(result => result.Name));
            CreateMap<LoginViewModel, VesizleUser>();
            CreateMap<PopularMovie, PopularCardModel>().ForMember(model => model.VoteAverage, expression => expression.MapFrom(result => result.Vote_Average)).ForMember(model => model.MovieId, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.PosterPath, expression => expression.MapFrom(result => AppConstants.BasePosterUrl + result.Poster_Path));

            CreateMap<DiscoveryMovie, DiscoverCardModel>().ForMember(model => model.VoteAverage, expression => expression.MapFrom(result => result.Vote_Average)).ForMember(model => model.MovieId, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.PosterPath, expression => expression.MapFrom(result => AppConstants.BasePosterUrl + result.Poster_Path));

            CreateMap<ApiMovieDetailsResult, FavoriteDetailViewModel>().ForMember(model => model.VoteAverage, expression => expression.MapFrom(result => result.Vote_Average)).ForMember(model => model.MovieId, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.PosterUrl, expression => expression.MapFrom(result => AppConstants.BasePosterUrl + result.Poster_Path));

            CreateMap<ApiMovieDetailsResult, WatchedListDetailViewModel>().ForMember(model => model.VoteAverage, expression => expression.MapFrom(result => result.Vote_Average)).ForMember(model => model.MovieId, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.PosterUrl, expression => expression.MapFrom(result => AppConstants.BasePosterUrl + result.Poster_Path));
            CreateMap<ApiMovieDetailsResult, WatchListDetailViewModel>().ForMember(model => model.VoteAverage, expression => expression.MapFrom(result => result.Vote_Average)).ForMember(model => model.MovieId, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.PosterUrl, expression => expression.MapFrom(result => AppConstants.BasePosterUrl + result.Poster_Path));

            CreateMap<ApiMovieDetailsResult, MovieDetailsViewModel>().ForMember(model => model.MovieId, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.PosterUrl, expression => expression.MapFrom(result => AppConstants.BasePosterUrl + result.Poster_Path)).ForMember(model => model.YoutubeUrl, expression => expression.MapFrom(result => AppConstants.BaseYoutubeUrl + result.Videos.Results[0].Key)).ForMember(model => model.CreditsViewModel, expression => expression.MapFrom(result => result.Credits)).ForMember(model => model.Recommendations, expression => expression.MapFrom(result => result.Recommendations));

            CreateMap<Recommendations, RecommendationsModel>()
                .ForMember(model => model.TotalPages, expression => expression.MapFrom(result => result.Total_Pages))
                .ForMember(model => model.TotalResults,
                    expression => expression.MapFrom(result => result.Total_Results));

            CreateMap<RecommendationDetail, RecommendationCardModel>().ForMember(model => model.VoteAverage, expression => expression.MapFrom(result => result.Vote_Average)).ForMember(model => model.MovieId, expression => expression.MapFrom(result => result.Id)).ForMember(model => model.PosterPath, expression => expression.MapFrom(result => AppConstants.BasePosterUrl + result.Poster_Path));

            CreateMap<Credits, CreditsViewModel>().ForMember(model => model.CastViewModels,
                expression => expression.MapFrom(result => result.Cast)).ForMember(model => model.CrewViewModels,
                expression => expression.MapFrom(result => result.Crew));

            CreateMap<Cast, CastViewModel>().ForMember(model => model.Department,
                expression => expression.MapFrom(result => result.Known_For_Department)).ForMember(model => model.ProfilePath,
                expression => expression.MapFrom(result => AppConstants.BaseProfilePath + result.Profile_Path));

            CreateMap<Crew, CrewViewModel>().ForMember(model => model.Department,
                expression => expression.MapFrom(result => result.Known_For_Department)).ForMember(model => model.ProfilePath,
                expression => expression.MapFrom(result => AppConstants.BaseProfilePath + result.Profile_Path));


            CreateMap<ApiSearchResult, SearchViewModel>()
                .ForMember(model => model.TotalPages, expression => expression.MapFrom(result => result.Total_Pages))
                .ForMember(model => model.TotalResults,
                    expression => expression.MapFrom(result => result.Total_Results));

            CreateMap<SearchMovie, SearchDetailViewModel>().ForMember(model => model.PosterPath, expression => expression.MapFrom(result => AppConstants.BasePosterUrl + result.Poster_Path)).ForMember(model => model.ReleaseDate, expression => expression.MapFrom(result => result.Release_Date)).ForMember(model => model.VoteAverage, expression => expression.MapFrom(result => result.Vote_Average));



        }
    }
}
