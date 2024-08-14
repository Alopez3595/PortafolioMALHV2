using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortafolioMALH2.Datos;
using PortafolioMALH2.Models;

namespace PortafolioMALH2.Controllers
{
    public class ProyectoTecsController : Controller
    {
        ProyectoTecsDatos _proyectoTecsDatos = new ProyectoTecsDatos();
        //    public IActionResult Listar(string nombreProyecto)
        //    {
        //        var nombresProyectos = _proyectoTecsDatos.ListarProyectos(); // Obtén los nombres de los proyectos
        //        ViewBag.NombresProyectos = nombresProyectos; // Configura ViewBag.NombresProyectos

        //        List<ProyectoTecs> oLista;

        //        if (string.IsNullOrEmpty(nombreProyecto))
        //        {
        //            oLista = _proyectoTecsDatos.Listar(); // Obtén todos los proyectos si nombreProyecto es null o vacío
        //        }
        //        else
        //        {
        //            oLista = _proyectoTecsDatos.ListarPorProyecto(nombreProyecto); // Obtén los proyectos específicos si nombreProyecto tiene un valor
        //        }

        //        return View(oLista);
        //    }

        //}
        [HttpGet]
        [HttpPost]
        public IActionResult Listar(string NombresProyectos)
        {
            var nombresProyectos = _proyectoTecsDatos.ListarProyectos(); // Obtén los nombres de los proyectos
            ViewBag.NombresProyectos = nombresProyectos; // Configura ViewBag.NombresProyectos
            ViewBag.NombreProyectoSeleccionado = NombresProyectos; // Agrega el nombre del proyecto seleccionado a ViewBag

            List<ProyectoTecs> oLista;

            if (string.IsNullOrEmpty(NombresProyectos))
            {
                oLista = _proyectoTecsDatos.Listar(); // Obtén todos los proyectos si nombreProyecto es null o vacío
            }
            else
            {
                oLista = _proyectoTecsDatos.ListarPorProyecto(NombresProyectos); // Obtén los proyectos específicos si nombreProyecto tiene un valor
            }

            return View(oLista);
        }

        //public IActionResult ListarPorProyecto(string nombreProyecto)
        //{
        //    var nombresProyectos = _proyectoTecsDatos.ListarProyectos(); // Obtén los nombres de los proyectos
        //    ViewBag.NombresProyectos = nombresProyectos; // Configura ViewBag.NombresProyectos

        //    List<ProyectoTecs> oLista;

        //    if (string.IsNullOrEmpty(nombreProyecto))
        //    {
        //        oLista = _proyectoTecsDatos.Listar(); // Obtén todos los proyectos si nombreProyecto es null o vacío
        //    }
        //    else
        //    {
        //        oLista = _proyectoTecsDatos.ListarPorProyecto(nombreProyecto); // Obtén los proyectos específicos si nombreProyecto tiene un valor
        //    }

        //    return View(oLista);
        //}


    }
}
