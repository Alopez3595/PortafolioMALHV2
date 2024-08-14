using Microsoft.AspNetCore.Mvc;
using PortafolioMALH2.Datos;
using PortafolioMALH2.Models;

namespace PortafolioMALH2.Controllers

{
    public class DesarrolladorController : Controller
    {
        desarrolladorDatos _desarrolladorDatos = new desarrolladorDatos();

        public IActionResult Listar()
        {
            //Monstrará una lista de todos los datos del desarrollador
            var oLista = _desarrolladorDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar() 
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(DesarrolladorModel oDesarrolladorModel)
        {
            if(!ModelState.IsValid)
                return View();

            var respuesta = _desarrolladorDatos.Guardar(oDesarrolladorModel);
            if(respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
