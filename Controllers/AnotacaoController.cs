using Microsoft.AspNetCore.Mvc;
using AgendaVeicular.Models;

namespace ManutencaoVeicular.Controllers;

public class AnotacaoController : Controller
{
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(PropertyAnotacaoModel property)
    {
        RepositoryAnotacaoModel repository = new RepositoryAnotacaoModel();

        repository.Inserir(property);
        return RedirectToAction("Read");
    }

    public IActionResult Read()
    {
        RepositoryAnotacaoModel repository = new RepositoryAnotacaoModel();
        return View(repository.Listar());
    }

    public IActionResult Update(int Id)
    {
        RepositoryAnotacaoModel repository = new RepositoryAnotacaoModel();
        return View(repository.BuscaPorId(Id));
    }
    [HttpPost]
    public IActionResult Update(PropertyAnotacaoModel property)
    {
        RepositoryAnotacaoModel repository = new RepositoryAnotacaoModel();
        repository.Editar(property);
        return RedirectToAction("Read");
    }
    public IActionResult Delete(int Id)
    {
        RepositoryAnotacaoModel repository = new RepositoryAnotacaoModel();
        repository.Deletar(Id);
        return RedirectToAction("Read");
    }
}