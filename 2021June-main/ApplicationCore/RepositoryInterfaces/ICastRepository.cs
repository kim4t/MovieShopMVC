using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
   public interface ICastRepository: IAsyncRepository<Cast>
    {
        //Task<List<Movie>> GetAllMovies(int id);
    }
}
