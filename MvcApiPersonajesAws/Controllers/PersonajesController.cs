using Microsoft.AspNetCore.Mvc;
using MvcApiPersonajesAws.Models;
using MvcApiPersonajesAws.Services;

namespace MvcApiPersonajesAws.Controllers
{
    public class PersonajesController : Controller
    {
        private ServiceApiPersonajes service; 

        public PersonajesController(ServiceApiPersonajes service)
        {
            this.service = service;
        }

        public async Task <IActionResult> Index()
        {
            List<Personaje>personajes = await this.service.GetPersonajesAsync();
            return View(personajes);
        }
        public IActionResult CreatePersonajes()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonajes(Personaje personaje)
        {
            await this.service.CreatePersonajesAsync(personaje.Nombre, personaje.Imagen);
            return RedirectToAction("Index");
        }
       
        public async Task<IActionResult>Edit()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Edit(Personaje per)
        {
            await this.service.UpdatePersonajesAsync(per.IdPersonaje, per.Nombre, per.Imagen);
            return RedirectToAction("Index");
        }
    }
}
