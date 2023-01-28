using eTicket.Data.Service;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTicket.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService service;
        public CinemaController(ICinemaService cinemaService)
        {
            service= cinemaService; 
        }

        public async Task<IActionResult> Index()
        {
            var allCinema = await service.GetAllAsync();

            return View(allCinema);
        }

        //Get Cinema Create 1
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return  View(cinema);
            }
            await service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get Cinema Details 
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetail = await service.GetAllById(id);
            if (cinemaDetail == null) return View("NotFound");
            return View(cinemaDetail);
        }

        //Get Cinema edit
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaEdit = await service.GetAllById(id);
            if (cinemaEdit == null) return View("NotFound");
            return View(cinemaEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Cinema cinema)
        {
          if(!ModelState.IsValid)
            {
                return View(cinema);
            }
          if(id == cinema.Id)
            {
                await  service.UpdateAync(id,cinema);
                return RedirectToAction(nameof(Index));
            }
          return View(cinema);
        }

        //Get Cinema Delete 1
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDelete = await service.GetAllById(id);
            if (cinemaDelete == null) return View("NotFound");
            return View(cinemaDelete);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinemaDelete = await service.GetAllById(id);
            if (cinemaDelete == null) return View("NotFound");
            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
