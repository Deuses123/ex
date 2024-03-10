using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using ThinkThank.Portal.Models;

namespace ThinkThank.Portal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string culture)
    {
        GetCulture(culture);
        return View();
    }
    
    public IActionResult NotFound(int? statusCode)
    {
        if (statusCode.HasValue && statusCode.Value == 404)
        {
            return View("_NotFound"); 
        }
        return View("_Error");
    }
    
    public string GetCulture(string code = "")
    {
        if (!string.IsNullOrWhiteSpace(code))
        {
            CultureInfo.CurrentCulture = new CultureInfo(code);
            CultureInfo.CurrentUICulture = new CultureInfo(code);

            ViewBag.Culture = string.Format("CurrentCulture: {0}, CurrentUICulture: {1}", CultureInfo.CurrentCulture,
                CultureInfo.CurrentUICulture);
        }
        return "";
    }
}