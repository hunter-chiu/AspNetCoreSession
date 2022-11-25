using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreSession.Models;

namespace AspNetCoreSession.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // 向Session寫入資料
        HttpContext.Session.SetString("User", "hunter");
        return View();
    }

    public IActionResult Privacy()
    {
        // 讀取Session的資料
        var user = HttpContext.Session.GetString("User");
        if (user != null)
        {
            Console.WriteLine("Session: " + user);
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
