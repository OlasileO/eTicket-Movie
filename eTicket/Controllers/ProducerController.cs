using eTicket.Data.Service;
using eTicket.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTicket.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService service;
        public ProducerController(IProducerService producerService)
        {
            service= producerService;   
        }

        public async Task <IActionResult> Index()
        {
            var allproducer = await service.GetAllAsync();

            return View(allproducer);
        }

        //Get Create Producer
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        //Get Producer Details
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await service.GetAllById(id);
            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }
        //Get Producer Edit
        public async Task<IActionResult> Edit(int id)
        {
            var producerEdit = await service.GetAllById(id);
            if (producerEdit == null) return View("NotFound");

            return View(producerEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            if (id == producer.Id)
            {
                await service.UpdateAync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View (producer);
        }
        //Get Producer Delete
        public async Task<IActionResult> Delete (int id)
        {
            var producerDelete = await service.GetAllById(id);
            if (producerDelete == null) return View("NotFound");

            return View(producerDelete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfrimed(int id)
        {
            var producerDelete = await service.GetAllById(id);
            if (producerDelete == null) return View("NotFound");
            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index)); 
        }
    }
}
