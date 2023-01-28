using eTicket.Data.Base;
using eTicket.Data.ViewModel;
using eTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicket.Data.Service
{
    public class MovieService : EntityBaseRepositoty<Movie>, IMovieService
    {
        private readonly AppDbContext dbContext;
        public MovieService(AppDbContext context) : base(context)
        {
            dbContext = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var NewMovie = new Movie
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageUrl,
                CinemaId = data.CinemaId,
                Startdate = data.Startdate,
                Enddate = data.Enddate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId,

            };
            await dbContext.Movies.AddAsync(NewMovie);
            await  dbContext.SaveChangesAsync();
            //add new actor
            foreach (var actorid in data.ActorId)
            {
                var newActormovie = new Actor_Movie()
                {
                    MovieId = NewMovie.Id,
                    ActorId = actorid
                };
                await dbContext.Actors_Movies.AddAsync(newActormovie);
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await dbContext.Movies
                .Include(c => c.Cinema)
                .Include(p => p.producer)
                .Include(ac => ac.Actor_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(i => i.Id == id);

            return movie;

        }

        public async Task<NewMovieDropDownsVM> GetNedMovieDropDownsValues()
        {
           
            var reponse = new NewMovieDropDownsVM()
            {
                Producers = await dbContext.Producers.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await dbContext.Cinemas.OrderBy(n => n.CinemaName).ToListAsync(),
                Actors = await dbContext.Actors.OrderBy(n => n.FullName).ToListAsync(),
            };
            return reponse;

        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var db  = await dbContext.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);
            if(db != null)
            {

                db.Name = data.Name;
                db.Description = data.Description;
                db.Price = data.Price;
                db.ImageUrl = data.ImageUrl;
                db.CinemaId = data.CinemaId;
                db.Startdate = data.Startdate;
                db.Enddate = data.Enddate;
                db.MovieCategory = data.MovieCategory;
                db.ProducerId = data.ProducerId;
                await dbContext.SaveChangesAsync();
            } 

            // remove existing Actors
            var removeExistActor = dbContext.Actors_Movies.Where(n => n.MovieId== data.Id).ToList();
            dbContext.Actors_Movies.RemoveRange(removeExistActor);
            await dbContext.SaveChangesAsync();

            foreach (var actorid in data.ActorId)
            {
                var newActormovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorid
                };
                await dbContext.Actors_Movies.AddAsync(newActormovie);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
