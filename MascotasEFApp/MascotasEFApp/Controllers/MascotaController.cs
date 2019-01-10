using MascotasEFApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MascotasEFApp.Controllers
{
    public class MascotaController : Controller
    {
        private MascotasConnection cnxMascota;
        public MascotaController()
        {
            cnxMascota = new MascotasConnection();
        }
        [HttpGet]
        public ActionResult Index()
        {
            var listado = cnxMascota.MASCOTA.ToList();
            return View(listado);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(MASCOTA oMascota)
        {
            cnxMascota.MASCOTA.Add(oMascota);
            cnxMascota.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Actualizar(int Id)
        {            
             var oMascota = cnxMascota.MASCOTA.FirstOrDefault(x => x.ID == Id);
             return View(oMascota);
        }

        [HttpPost]
        public ActionResult Actualizar(MASCOTA oMascota)
        {
            var eMascota = cnxMascota.MASCOTA.FirstOrDefault(x => x.ID == oMascota.ID);
            eMascota.ID = oMascota.ID;
            eMascota.NOMBRE = oMascota.NOMBRE;
            eMascota.RAZA = oMascota.RAZA;
            eMascota.EDAD = oMascota.EDAD;
            eMascota.NOMBREDUENO = oMascota.NOMBREDUENO;

            cnxMascota.SaveChanges(); 
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int Id)
        {
            var oMascota = cnxMascota.MASCOTA.FirstOrDefault(x => x.ID == Id);
            cnxMascota.MASCOTA.Remove(oMascota);
            cnxMascota.SaveChanges();            
            return RedirectToAction("Index");
        }


    }
}