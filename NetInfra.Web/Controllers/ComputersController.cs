using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetInfra.ViewModels;
using NetInfra.Data;
using Microsoft.EntityFrameworkCore;
using NetInfra.Domain;
using NetInfra.Web.ViewModels;

namespace NetInfra.Controllers
{
  public class ComputersController : Controller
  {
    private readonly ApplicationDbContext _context;

    public ComputersController(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<IActionResult> Index(string sortBy, int pageIndex = 1)
    {
      if (String.IsNullOrWhiteSpace(sortBy))
      {
        sortBy = "stn";
      }

      var person = await _context.Persons.SingleOrDefaultAsync(p => p.Id == 1);

      var computers = _context.Computers.Include(c => c.AgTip).ToListAsync();

      var model = new AssetsViewModel
      {
        Person = person,
        Computers = await computers
      };

      return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> ComputerDetails(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var model = await _context.Computers
        .AsNoTracking()
        .SingleOrDefaultAsync(c => c.Id == id);

      if (model == null)
        return NotFound();

      return View(model);
    }

    [HttpGet]
    public IActionResult New()
    {
      var vm = new ComputerFormViewModel()
      {
        Computer = new Computer(),
        AgTips = _context.AgTips.ToList()
      };
      vm.AgTips.Insert(0, new AgTip { Id = 0, Ad = "Seçiniz..." });

      return View("ComputerForm", vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Save(ComputerFormViewModel model)
    {
      if (!ModelState.IsValid)
      {
        var vm = new ComputerFormViewModel()
        {
          Computer = new Computer(),
          AgTips = _context.AgTips.ToList()
        };
        vm.AgTips.Insert(0, new AgTip { Id = 0, Ad = "Seçiniz..." });

        return View("ComputerForm", vm);
      }

      try
      {
        if (model.Computer.Id == 0)
          _context.Add(model.Computer);
        else
        {
          var computerInDb = _context.Computers.Single(c => c.Id == model.Computer.Id);
          computerInDb.Stn = model.Computer.Stn;
          computerInDb.Serino = model.Computer.Serino;
          computerInDb.AgTipId = model.Computer.AgTipId;
        }

        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
      }
      catch (DbUpdateException /* ex */)
      {
        //Log the error (uncomment ex variable name and write a log.
        ModelState.AddModelError("", "Unable to save changes. " +
            "Try again, and if the problem persists " +
            "see your system administrator.");
      }

      return View("ComputerForm", model);
    }

    public async Task<IActionResult> Edit(int id)
    {
      var computer = await _context.Computers.SingleOrDefaultAsync(c => c.Id == id);

      if (computer == null)
        return NotFound();

      var vm = new ComputerFormViewModel
      {
        Computer = computer,
        AgTips = _context.AgTips.ToList()
      };
      vm.AgTips.Insert(0, new AgTip { Id = 0, Ad = "Seçiniz..." });

      return View("ComputerForm", vm);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var computer = await _context.Computers
          .AsNoTracking()
          .SingleOrDefaultAsync(c => c.Id == id);
      if (computer == null)
      {
        return RedirectToAction("Index");
      }

      try
      {
        _context.Computers.Remove(computer);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      catch (DbUpdateException /* ex */)
      {
        //Log the error (uncomment ex variable name and write a log.)
        return RedirectToAction("Delete", new { id = id, saveChangesError = true });
      }
    }

    public IActionResult Map()
    {
      //List<ComputerMapViewModel> vm = new List<ComputerMapViewModel>()
      //{
      //  new ComputerMapViewModel { Id = 1, Name = "Computer 1", Lat = 30, Lon = 35},
      //  new ComputerMapViewModel { Id = 1, Name = "Computer 2", Lat = 32, Lon = 37},
      //  new ComputerMapViewModel { Id = 1, Name = "Computer 3", Lat = 34, Lon = 39}
      //};

      //if (Request.IsAjaxRequest())
      //{
      //  return Json(vm, JsonRequestBehavior.AllowGet);
      //}

      //return Json(vm);

      return View();
    }

    public IActionResult Map2()
    {
      List<ComputerMapViewModel> vm = new List<ComputerMapViewModel>()
      {
        new ComputerMapViewModel { Id = 1, Name = "Computer 1", Lat = 30, Lon = 35},
        new ComputerMapViewModel { Id = 1, Name = "Computer 2", Lat = 32, Lon = 37},
        new ComputerMapViewModel { Id = 1, Name = "Computer 3", Lat = 34, Lon = 39}
      };

      //if (Request.IsAjaxRequest())
      //{
      //  return Json(vm, JsonRequestBehavior.AllowGet);
      //}

      return Json(vm);
    }
  }
}