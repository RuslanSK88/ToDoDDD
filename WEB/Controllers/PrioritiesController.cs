
using BLL.UOW;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers;

public class PrioritiesController : Controller
{
    private readonly UnitOfWork _uow;
    public PrioritiesController(UnitOfWork uow)
    {
        _uow = uow;
    }
    public IActionResult Index()
    {
        IEnumerable<Priority> priority = _uow.PriorityRepository.Get();
        return View(priority);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Priority priority)
    {
        if (ModelState.IsValid)
        {

            _uow.PriorityRepository.Insert(priority);
            _uow.Save();
            return RedirectToAction("Index");
        }
        return View(priority);
    }
}
