using Demo_ASPNET_Core_Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Demo_ASPNET_Core_Identity.Data;
using Demo_ASPNET_Core_Identity.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Demo_ASPNET_Core_Identity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<IdentityUser> _SignInManager;
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public HomeController(ILogger<HomeController> logger
            , SignInManager<IdentityUser> SignInManager
            , UserManager<IdentityUser> UserManager
            , ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _SignInManager = SignInManager;
            _UserManager = UserManager;
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {

            var user = new UserInSession(User, _applicationDbContext);
             return View();
        }

        public IActionResult Privacy()
        {
            var user = new UserInSession(User, _applicationDbContext);
            if (user.IsAdmin())
            {
                return View();
            }
            else
            {
                return Unauthorized(); //TODO: Aca en vez de retonar esta vista ,retornar un personalizada
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
