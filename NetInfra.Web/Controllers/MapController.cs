﻿using Microsoft.AspNetCore.Mvc;
using NetInfra.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetInfra.Web.Controllers
{
  public class MapController : Controller
  {
    public IActionResult GeoMap()
    {
      return View();
    }

    public IActionResult GeoData(string compName = null)
    {
      List<ComputerMapViewModel> vm = new List<ComputerMapViewModel>()
      {
        new ComputerMapViewModel { Id = 1, Name = "Computer 1", Status = "on", Lat = 38.6M, Lon = 29.4M },
        new ComputerMapViewModel { Id = 2, Name = "Computer 2", Status = "off", Lat = 39, Lon = 35 },
        new ComputerMapViewModel { Id = 3, Name = "Computer 3", Status = "on", Lat = 37, Lon = 36 },
        new ComputerMapViewModel { Id = 4, Name = "Computer 4", Status = "off", Lat = 37, Lon = 36 },

        new ComputerMapViewModel { Id = 5, Name = "B410-0001", Status = "on", Lat = 39.946M, Lon = 32.904M },
        new ComputerMapViewModel { Id = 6, Name = "B410-0002", Status = "on", Lat = 39.952M, Lon = 32.906M },
        new ComputerMapViewModel { Id = 7, Name = "S410-NET01", Status = "on", Lat = 39.946M, Lon = 32.914M },
        new ComputerMapViewModel { Id = 8, Name = "S410-NET02", Status = "off", Lat = 39.941M, Lon = 32.917M }
      };

      if (!String.IsNullOrWhiteSpace(compName))
      {
        vm = vm.Where(c => c.Name.Contains(compName)).ToList();
      }

      return Json(vm);
    }

    public IActionResult ImageMap()
    {
      var vm = new ImageMapViewModel
      {
        //ImagePath = "/images/Bina-A_Kat-2.png"
        ImagePath = "/images/Kisla.jpg",
        x_points = { 1549, 1498, 1456, 1508, 1549 },
        y_points = { 2399, 2263, 2281, 2417, 2399 }
      };

      return View(vm);
    }

    public IActionResult ImageData()
    {
      return View();
    }
  }
}
