using eTicket.Data.Service;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eTicket.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService service;
        public MovieController(IMovieService movieService)
        {
            service = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var allmovies = await service.GetAllAsync(cn => cn.Cinema);
            return View(allmovies);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allmovies = await service.GetAllAsync(cn => cn.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filterstr = allmovies.Where( n => n.Name.Contains(searchString) ||
                n.Description.Contains(searchString)).ToList();
                return View("Index",filterstr);
            }
            return View("Index", allmovies);
        }

        // Get Details 
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }

        //Get Movies/Create
        public async Task<IActionResult> Create()
        {
            var moviesDropDownData = await service.GetNedMovieDropDownsValues();

            ViewBag.Cinemas = new SelectList(moviesDropDownData.Cinemas, "Id", "CinemaName");
            ViewBag.Producers = new SelectList(moviesDropDownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(moviesDropDownData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var moviesDropDownData = await service.GetNedMovieDropDownsValues();

                ViewBag.Cinemas = new SelectList(moviesDropDownData.Cinemas, "Id", "CinemaName");
                ViewBag.Producers = new SelectList(moviesDropDownData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(moviesDropDownData.Actors, "Id", "FullName");
                return View(movie);
            }
            await service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //Get Movie Edit 1
        public async Task<IActionResult> Edit(int id)
        {
            var movieEdit = await service.GetMovieByIdAsync(id);
            if (movieEdit == null) return View("NotFound");

            var reponse = new NewMovieVM()
            {
                Id = movieEdit.Id,
                Name = movieEdit.Name,
                Description = movieEdit.Description,
                Price = movieEdit.Price,
                ImageUrl = movieEdit.ImageUrl,
                MovieCategory = movieEdit.MovieCategory,
                Startdate = movieEdit.Startdate,
                Enddate = movieEdit.Enddate,
                CinemaId = movieEdit.CinemaId,
                ProducerId = movieEdit.ProducerId,
                ActorId = movieEdit.Actor_Movies.Select(n => n.ActorId).ToList(),
            };
            var moviesDropDownData = await service.GetNedMovieDropDownsValues();

            ViewBag.Cinemas = new SelectList(moviesDropDownData.Cinemas, "Id", "CinemaName");
            ViewBag.Producers = new SelectList(moviesDropDownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(moviesDropDownData.Actors, "Id", "FullName");

            return View(reponse);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {

                var moviesDropDownData = await service.GetNedMovieDropDownsValues();

                ViewBag.Cinemas = new SelectList(moviesDropDownData.Cinemas, "Id", "CinemaName");
                ViewBag.Producers = new SelectList(moviesDropDownData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(moviesDropDownData.Actors, "Id", "FullName");

                return View(movie);
            }

            await service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var deleteActor = await service.GetAllById(id);
            if (deleteActor == null) return View("NotFound");
            return View(deleteActor);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfrimed(int id)
        {
            var deleteActor = await service.GetAllById(id);
            if (deleteActor == null) return View("NotFound");
            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
