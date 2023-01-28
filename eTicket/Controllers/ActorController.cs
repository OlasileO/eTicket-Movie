using eTicket.Data.Service;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTicket.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorService service;
        public ActorController(IActorService actorService)
        {
            service = actorService;
        }

        public async Task <IActionResult> Index()
        {
            var allActor = await service.GetAllAsync();
            return View(allActor);
        }
        //get Create
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get Actor Details 1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetail = await service.GetAllById(id);
            if (actorDetail == null) return View("NotFound");
            return View(actorDetail);
        }
        //Get Actor Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorEdit = await service.GetAllById(id);
            if (actorEdit == null) return View("NotFound");
            return View(actorEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            if(id == actor.Id)
            {
                await  service.UpdateAync(id,actor);
                return RedirectToAction(nameof(Index));
            }
            return View(actor); 
        }

        //Get Actor Delete 1
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
