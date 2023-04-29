using BLL.UOW;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers;

public class StatusesController : Controller
{
    private readonly UnitOfWork _uow;
    public StatusesController(UnitOfWork uow)
    {
        _uow = uow;
    }
    public IActionResult Index()
    {
        IEnumerable<Status> statuses = _uow.StatusRepository.Get();
        return View(statuses);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Status status)
    {
        if (ModelState.IsValid)
        {

            _uow.StatusRepository.Insert(status);
            _uow.Save();
            return RedirectToAction("Index");
        }
        return View(status);
    }
}

