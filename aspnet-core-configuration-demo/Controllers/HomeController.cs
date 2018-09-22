using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApplication.Settings.Json;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly MySettings _mySettings;

        public HomeController(IConfiguration configuration, MySettings mySettings)
        {
            _configuration = configuration;
            _mySettings = mySettings;
        }

        public IActionResult Index()
        {
            var mySettingsGet = _configuration.Get(typeof(MySettings));

            ViewData["Setting1"] = _mySettings.Setting1;
            ViewData["Setting2"] = _mySettings.Setting2;

            return View();
        }
    }
}
