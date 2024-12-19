using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BarberWebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Entities;
using DataAccess.Abstract;
using System.Runtime.CompilerServices;

namespace BarberWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager, IUserRepository userRepository, IDepartmentRepository departmentRepository)
        {
            _logger = logger;
            _userManager = userManager;
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
