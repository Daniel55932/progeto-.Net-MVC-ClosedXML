using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AgendaVeicular.Models;

namespace AgendaVeicular.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        RepositoryRelatorioModel repository = new RepositoryRelatorioModel();
        repository.CriaDiretorio();
        repository.InseriKm();
        return View("Index");
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