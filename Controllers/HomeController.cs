using Microsoft.AspNetCore.Mvc;
using MyModule.Models;
using System.Diagnostics;
using DAL;
using BOL;
namespace MyModule.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Employees()
        {
            List<Employee> employees = DBmanager.getAllEmployees();

            ViewBag.Employees = employees;

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public ActionResult deleteBYId()
        {
            return View();
        }



        [HttpPost]
        public ActionResult deleteBYId(int id)
        {
            DBmanager.deleteEmployee(id);

            return RedirectToAction("Employees");
        }


        [HttpPost]
        public IActionResult Register(string id, string firstname, string lastname, string department , string joindate) 
        {
            Employee newEmp = new Employee(int.Parse(id), firstname, lastname, Enum.Parse<Department>(department.ToUpper()),DateOnly.Parse(joindate));

            DBmanager.insertEmployee(newEmp);

            return RedirectToAction("Employees");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}