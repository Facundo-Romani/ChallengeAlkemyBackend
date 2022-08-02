using BackendDisneyApi.Base;
using BackendDisneyApi.Models;
using System;
using System.Collections.Generic;

namespace BackendDisneyAp.Models
{
    public class Gender : BaseEntity   
    {
        public List<MovieOrSerie> MoviesOrSeries { get; set; }
    }
}