using CarBase.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarBase.Repositories.Interfaces;
using CarBase.Services.Interfaces;
using CarBase.Services;
using System.Linq.Expressions;

namespace CarBase.Controllers
{
    public class CarsController : Controller
    {
        // private readonly VehicleContext _db;
        private ICarService _locationService;
        private IEngineService _engineService;
        private IMakeService _makeService;
        private ITypeService _typeService;

        public CarsController(ICarService locationService, IEngineService engineService, IMakeService makeService, ITypeService typeService)
        {
            _locationService = locationService;
            _engineService = engineService;
            _makeService = makeService;
            _typeService = typeService;
        }

        public IActionResult Cars([FromServices] ILog log){
            log.Info("Executing /Home/Index");
            return View();
        }

        [HttpGet]
        public IActionResult GetAllCars(){
            var vehicles = _locationService.GetVehicle();
            return Json(vehicles);
        }

        public IActionResult CarsManage()
        {
            return View();
        }

        public IActionResult PopulateEngines()
        {
            var engines = _engineService.PopulateEngine();
            return Json(engines);
        }

        public IActionResult PopulateMakes()
        {
            var makes = _makeService.PopulateMake();
            return Json(makes);
        }

        public IActionResult PopulateTypes()
        {
            var types = _typeService.PopulateType();
            return Json(types);
        }

        [HttpPost]
        public IActionResult AddCar(vehicle vehicle)
        {
            // _locationService.AddVehicle(vehicle);
            // return Json(vehicle);

            try
            {
                if (vehicle is null)
                {
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }
                _locationService.AddVehicle(vehicle);
                return Json(vehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        //get
        // public IActionResult Cars(string searchName, int? page)
        // {

        //     /*   var join = from m in _db.makes
        //                   join v in _db.vehicles
        //                   on m.makeID equals v.makeID
        //                   select new VehicleMake
        //                   {
        //                       makename = makes.name
        //                   };

        //       join.ToList();*/

        //     /*IEnumerable<vehicle> vehicleList = _db.vehicles.ToList();*/

        //     /*var vehicles = _db.vehicles.OrderBy(x => x.vehicleID).ToList();*/

        //     var pageNumber = page ?? 1;
        //     var pageSize = 8;
        //     var vehiclesList = _db.vehicles.Include("make").Include("type").Include("engine").Where(v => v.Model.Contains(searchName) || searchName == null || v.make.name.Contains(searchName) ).OrderBy(x => x.vehicleID)/*Where(x => x.Model == "ilx")*/.ToList().ToPagedList(pageNumber, pageSize);
        //     return View(vehiclesList);
        // }


    //     public IActionResult DeleteCar(int id)
    //     {
    //         // if(id > 0)
    //         // {
    //         //     var carid = _db.vehicles.Where(x => x.makeID == id).FirstOrDefault();
    //         //      if (carid != null)  
    //         //         {  
    //         //             _db.Entry(carid).State = EntityState.Deleted;  
    //         //             _db.SaveChanges();  
    //         //         }  
    //         //  }  
    //         //     return RedirectToAction("Cars");  

    //         vehicle car = _db.vehicles.Find(id);
    //         _db.vehicles.Remove(car);
    //         _db.SaveChanges();

    
    //         return Redirect(Request.Headers["Referer"]);   
    //     }
    

    //     //get search
    // /*    public IActionResult Cars(string searchName)
    //     {
    //         var vehicles = _db.vehicles.Include("make").Where(v => v.Model.Contains(searchName)).ToList();
    //         return View(vehicles);
    //     }*/

    //     private void PopulateLookups(vehicle vehicle)
    //     {
    //         var make = _db.makes.OrderBy(p => p.name).ToList();
    //         ViewBag.makeID = make.Select(p => new SelectListItem
    //         {
    //             Value = p.makeID.ToString(),
    //             Text = p.name,
    //             Selected = p.makeID == vehicle.makeID,
    //         });

    //         var type = _db.types.OrderBy(p => p.name).ToList();
    //         ViewBag.typeID = type.Select(p => new SelectListItem
    //         {
    //             Value = p.typeID.ToString(),
    //             Text = p.name,
    //             Selected = p.typeID == vehicle.typeID,
    //         });

    //         var engine = _db.engines.OrderBy(p => p.size).ToList();
    //         ViewBag.engineID = engine.Select(p => new SelectListItem
    //         {
    //             Value = p.engineID.ToString(),
    //             Text = p.size + " " + p.type,
    //             Selected = p.engineID == vehicle.engineID,
    //         });
    //     }

    //     [HttpGet]
    //     public IActionResult CarsManage()
    //     {
    //         vehicle vehicle = new vehicle();
    //         PopulateLookups(vehicle);
    //         return View(vehicle);

    //     }

    //     [HttpPost]
    //     [ValidateAntiForgeryToken]
    //     public IActionResult CarsManage(vehicle vehicle)
    //     {
    //         if (ModelState.IsValid)
    //         {
    //             _db.vehicles.Add(vehicle);
    //             _db.SaveChanges();
    //             return RedirectToAction("Cars");
    //         }
    //         PopulateLookups(vehicle);
    //         return View(vehicle);
    //     }

    //     public IActionResult CarsDetails(int id)
    //     {
    //         var vehicles = _db.vehicles.Include("make").Include("type").Include("engine").Where(s => s.vehicleID == id).FirstOrDefault();
    //         return View(vehicles);
    //     }

    //     [HttpGet]
    //     public IActionResult CarEdit(int id)
    //     {
    //         var vehicle = _db.vehicles.Where(s => s.vehicleID == id).FirstOrDefault();
    //         PopulateLookups(vehicle);
    //         return View(vehicle);
    //     }

    //     [HttpPost]
    //     public IActionResult CarEdit(vehicle vehicle)
    //     {
    //         if(ModelState.IsValid)
    //         {
    //             var vehicleaux = _db.vehicles.Where(s => s.vehicleID == vehicle.vehicleID).FirstOrDefault();
    //             _db.vehicles.Remove(vehicleaux);
    //             _db.vehicles.Add(vehicle);
    //             _db.SaveChanges();
    //         }

    //         return RedirectToAction("Cars");

    //     }
    }
}
