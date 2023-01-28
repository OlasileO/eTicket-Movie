using eTicket.Data.Base;
using eTicket.Data.ViewModel;
using eTicket.Models;

namespace eTicket.Data.Service
{
    public interface IMovieService:IEntityBaseRepositoty<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropDownsVM> GetNedMovieDropDownsValues();

        Task AddNewMovieAsync (NewMovieVM data);

        Task UpdateMovieAsync(NewMovieVM data);
    }
}
