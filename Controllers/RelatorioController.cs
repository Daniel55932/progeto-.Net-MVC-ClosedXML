using Microsoft.AspNetCore.Mvc;
using AgendaVeicular.Models;

namespace AgendaVeicular.Controllers;

public class RelatorioController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(PropertyRelatorioModel property)
    {
        RepositoryRelatorioModel repository = new RepositoryRelatorioModel();

        repository.InserirKm(property);
        
        return RedirectToAction("Privacy");
    }

    public IActionResult Privacy()
    {
        RepositoryRelatorioModel repository = new RepositoryRelatorioModel();
        return View(repository.Listar());
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(PropertyRelatorioModel property)
    {
        RepositoryRelatorioModel repository = new RepositoryRelatorioModel();

        repository.Inserir(property);
        return RedirectToAction("Read");
    }

    public IActionResult Read()
    {
        RepositoryRelatorioModel repository = new RepositoryRelatorioModel();
        return View(repository.Listar());
    }

    public IActionResult Update(int Id)
    {
        RepositoryRelatorioModel repository = new RepositoryRelatorioModel();
        return View(repository.BuscaPorId(Id));
    }
    [HttpPost]
    public IActionResult Update(PropertyRelatorioModel property)
    {
        RepositoryRelatorioModel repository = new RepositoryRelatorioModel();
        repository.Editar(property);
        return RedirectToAction("Read");
    }

    public IActionResult Delete(int Id)
    {
        RepositoryRelatorioModel repository = new RepositoryRelatorioModel();
        repository.Deletar(Id);
        return RedirectToAction("Read");
    }

}