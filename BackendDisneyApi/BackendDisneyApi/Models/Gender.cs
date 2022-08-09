using BackendDisneyApi.Base;
using System;
using System.Collections.Generic;

namespace BackendDisneyApi.Models
{
    public class Gender : BaseEntity
    {
        public List<MovieOrSerie> MoviesOrSeries { get; set; }
    }
}