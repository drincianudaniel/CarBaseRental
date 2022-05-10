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

        [HttpGet]
        public IActionResult Cars([FromServices] ILog log){
            log.Info("Executing /Home/Index");
            return View();
        }

        public IActionResult GetAllCars(){
            var vehicles = _locationService.GetVehicle();
            return Json(vehicles);
        }

        [HttpGet]
        [Route("Cars/searchCars/{search?}")]
        public IActionResult searchCars(String search){
            var vehicles = _locationService.searchVehicle(search);
            return Json(vehicles);
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

        public IActionResult CarsManage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CarsManage(vehicle vehicle)
        {
            _locationService.AddVehicle(vehicle);
            return RedirectToAction("Cars");
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

        public IActionResult DeleteCar(int id)
        {   
            var vehicle = new vehicle();
            vehicle = _locationService.FindID(id);
            _locationService.DeleteVehicle(vehicle);
            return RedirectToAction("Cars");
        }
    

    //     //get search
    // /*    public IActionResult Cars(string searchName)
    //     {
    //         var vehicles = _db.vehicles.Include("make").Where(v => v.Model.Contains(searchName)).ToList();
    //         return View(vehicles);
    //     }*/

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

        public IActionResult CarsDetails(int id)
        {
            // var vehicles = _db.vehicles.Include("make").Include("type").Include("engine").Where(s => s.vehicleID == id).FirstOrDefault();
            // return View(vehicles);
            var vehicle = new vehicle();
            vehicle = _locationService.FindID(id);
            return View(vehicle);
        }

        [HttpGet]
        public IActionResult CarEdit(int id)
        {
           var vehicle = new vehicle();
            vehicle = _locationService.FindID(id);
            return View(vehicle);
        }

        [HttpPost]
        public IActionResult CarEdit(vehicle vehicle)
        {

            _locationService.UpdateVehicle(vehicle);
            return RedirectToAction("Cars");

        }
    }
}
