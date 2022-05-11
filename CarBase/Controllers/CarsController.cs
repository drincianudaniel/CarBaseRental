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
        
        public IActionResult DeleteCar(int id)
        {   
            var vehicle = new vehicle();
            vehicle = _locationService.FindID(id);
            _locationService.DeleteVehicle(vehicle);
            return RedirectToAction("Cars");
        }

        public IActionResult CarsDetails(int id)
        {
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

        [HttpGet]
        public IActionResult EngineInsert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EngineInsert(engine engine)
        {
            _engineService.AddEngine(engine);
            return RedirectToAction("EngineInsert");
        }

        [HttpGet]
        public IActionResult MakeInsert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MakeInsert(make make)
        {
            _makeService.AddMake(make);
            return RedirectToAction("MakeInsert");
        }

        
        [HttpGet]
        public IActionResult TypeInsert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TypeInsert(type type)
        {
            _typeService.AddType(type);
            return RedirectToAction("TypeInsert");
        }
    }
}
