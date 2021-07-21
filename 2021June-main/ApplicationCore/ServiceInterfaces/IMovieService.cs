﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
      Task< List<MovieCardResponseModel>> GetTopRevenueMovies();
        Task<List<MovieCardResponseModel>> GetTopRatedMovies();
        Task<MovieDetailsResponseModel> GetMovieDetails(int id);
        Task<IEnumerable<MovieDetailsResponseModel>> GetAllMovies();


    }
}
