using CarBase.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarBase.Controllers
{
    public class CarsController : Controller
    {
        private readonly VehicleContext _db;
        public CarsController(VehicleContext db)
        {
            _db = db;
        }

        //get
        public IActionResult Cars(string searchName, int? page)
        {

            /*   var join = from m in _db.makes
                          join v in _db.vehicles
                          on m.makeID equals v.makeID
                          select new VehicleMake
                          {
                              makename = makes.name
                          };

              join.ToList();*/

            /*IEnumerable<vehicle> vehicleList = _db.vehicles.ToList();*/

            /*var vehicles = _db.vehicles.OrderBy(x => x.vehicleID).ToList();*/

            var pageNumber = page ?? 1;
            var pageSize = 8;
            var vehiclesList = _db.vehicles.Include("make").Include("type").Include("engine").Where(v => v.Model.Contains(searchName) || searchName == null || v.make.name.Contains(searchName) ).OrderBy(x => x.vehicleID)/*Where(x => x.Model == "ilx")*/.ToList().ToPagedList(pageNumber, pageSize);
            //var vehiclesList = _db.vehicles.OrderBy(x => x.vehicleID).ToPagedList(pageNumber, pageSize);
            return View(vehiclesList);
        }

        //get search
    /*    public IActionResult Cars(string searchName)
        {
            var vehicles = _db.vehicles.Include("make").Where(v => v.Model.Contains(searchName)).ToList();
            return View(vehicles);
        }*/

        private void PopulateLookups(vehicle vehicle)
        {
            var make = _db.makes.OrderBy(p => p.name).ToList();
            ViewBag.makeID = make.Select(p => new SelectListItem
            {
                Value = p.makeID.ToString(),
                Text = p.name,
                Selected = p.makeID == vehicle.makeID,
            });

            var type = _db.types.OrderBy(p => p.name).ToList();
            ViewBag.typeID = type.Select(p => new SelectListItem
            {
                Value = p.typeID.ToString(),
                Text = p.name,
                Selected = p.typeID == vehicle.typeID,
            });

            var engine = _db.engines.OrderBy(p => p.size).ToList();
            ViewBag.engineID = engine.Select(p => new SelectListItem
            {
                Value = p.engineID.ToString(),
                Text = p.size,
                Selected = p.engineID == vehicle.engineID,
            });
        }

        [HttpGet]
        public IActionResult CarsManage()
        {

            vehicle vehicle = new vehicle();
            PopulateLookups(vehicle);
            return View(vehicle);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarsManage(vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _db.vehicles.Add(vehicle);
                _db.SaveChanges();
                return RedirectToAction("Cars");
            }
            PopulateLookups(vehicle);
            return View(vehicle);
        }

        public IActionResult CarsDetails(int id)
        {
            var vehicles = _db.vehicles.Where(s => s.vehicleID == id).FirstOrDefault();
            return View(vehicles);
        }
    }
}
