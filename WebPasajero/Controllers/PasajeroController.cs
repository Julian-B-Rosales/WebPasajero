using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using WebPasajero.Data;
using WebPasajero.Models;

namespace WebPasajero.Controllers
{
    public class PasajeroController : Controller
    {
        private readonly DBWebPasajeroContext _context;

        public PasajeroController(DBWebPasajeroContext context)
        {
            _context = context;
        }

        // GET: /Pasajero
        public IActionResult Index()
        {
            return View(_context.Pasajeros.ToList());
        }

        [HttpGet("/Pasajero/ListaPorCiudad/{city}")]
        // GET: /Pasajero/ListaPorCiudad/baas
        public IActionResult ListaPorCiudad(string ciudad)
        {
            List<Pasajero> lista = (from p in _context.Pasajeros
                                  where p.Ciudad == ciudad
                                  select p).ToList();
            return View("Index", lista);
        }

        [HttpGet("/Pasajero/ListaPorNacimiento/{fecha}")]
        // GET: /Pasajero/ListaPorNacimiento/14-03-1994
        public IActionResult ListaPorNacimiento(DateTime fecha)
        {
            List<Pasajero> lista = (from p in _context.Pasajeros
                                    where p.FechaNacimiento == fecha
                                    select p).ToList();
            return View("Index", lista);
        }

        // GET: /Pasajero/Create
        public IActionResult Create()
        {
            Pasajero pasajero = new Pasajero();
            return View("Create", pasajero);
        }

        // POST: /Pasajero/Create
        [HttpPost]
        public IActionResult Create(Pasajero pasajero)
        {
            _context.Add(pasajero);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
