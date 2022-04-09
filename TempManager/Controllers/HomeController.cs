﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TempManager.Models;

namespace Ch11Ex1TempManager.Controllers
{
   
    public class HomeController : Controller
    {
        
        private TempManagerContext data { get; set; }
        public HomeController(TempManagerContext ctx) => data = ctx;

        public ViewResult Index()
        {
            var temps = data.Temps.OrderBy(t => t.Date).ToList();
            return View(temps);
        }

        [HttpGet]
        public ViewResult Add() => View(new Temp());

        [HttpPost]
        public IActionResult Add(Temp temp)
        {
            if (ModelState.IsValid) {
                var tempRecords = data.Temps;

                var dateExists = false;

                foreach (var existingTemp in tempRecords)
                {
                    if (temp.Date == temp.Date)
                    {
                        dateExists = true;
                    }
                }
                if (dateExists)
                {
                    ModelState.AddModelError("Date", "Dates already been used.");
                    return View(temp);
                }
                data.Temps.Add(temp);
                data.SaveChanges();

                return RedirectToAction("Index");
            } 
            else {
                ModelState.AddModelError(string.Empty,"Please correct all errors");
                return View(temp);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var temp = data.Temps.Find(id);
            return View(temp);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Temp temp)
        {
            data.Remove(temp);
            data.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
