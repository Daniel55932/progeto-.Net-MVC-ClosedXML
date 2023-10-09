using Microsoft.AspNetCore.Mvc;
using AgendaVeicular.Models;

namespace ManutencaoVeicular.Controllers;

public class SugestoesController : Controller
{
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(PropertySugestaoModel property)
    {
        RepositorySugestaoModel repository = new RepositorySugestaoModel();

        repository.Inserir(property);
        return RedirectToAction("Read");
    }

    public IActionResult Read()
    {
        RepositorySugestaoModel repository = new RepositorySugestaoModel();
        return View(repository.Listar());
    }
    public IActionResult Delete(int Id)
    {
        RepositorySugestaoModel repository = new RepositorySugestaoModel();
        repository.Deletar(Id);
        return RedirectToAction("Read");
    }
}