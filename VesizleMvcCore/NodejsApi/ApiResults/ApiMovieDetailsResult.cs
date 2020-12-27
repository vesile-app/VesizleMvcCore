using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VesizleMvcCore.NodejsApi.Entities;

namespace VesizleMvcCore.NodejsApi.ApiResults
{
    public class ApiMovieDetailsResult
    {
        public bool Adult { get; set; }
        public string Backdrop_Path { get; set; }
        public List<BelongsToCollection> Belongs_To_Collection { get; set; }
        public int Budget { get; set; }
        public List<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public string Imdb_Id { get; set; }
        public string Original_Language { get; set; }//*
        public string Original_Title { get; set; }//*
        public string Overview { get; set; }
        public decimal Popularity { get; set; }
        public string Poster_Path { get; set; }
        public List<ProductionCountry> Production_Countries { get; set; }
        public List<ProductionCompany> Production_Companies { get; set; }
        public string Release_Date { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public Videos Videos { get; set; }
        public List<SpokenLanguage> Spoken_Languages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public decimal Vote_Average { get; set; }
        public decimal Vote_Count { get; set; }
    }
}
