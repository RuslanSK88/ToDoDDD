using BLL.UOW;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class GoalsController : Controller
    {
        private readonly UnitOfWork _uow;
        public GoalsController(UnitOfWork uow)
        {
            _uow = uow;
        }
        public IActionResult Index()
        {
            GoalIndexViewModel model = new GoalIndexViewModel
            {
                Goals = _uow.GoalRepository.Get().ToList(),
                Statuses = _uow.StatusRepository.Get().ToList(),
                Priorities = _uow.PriorityRepository.Get().ToList(),
            };
            return View(model);
        }

        public IActionResult Create()
        {
            List<Priority> allPriorities = _uow.PriorityRepository.Get().ToList();
            ViewBag.allPriorities = new SelectList(allPriorities, "Id", "Name");

            List<Status> allStatuses = _uow.StatusRepository.Get().ToList();
            ViewBag.allStatuses = new SelectList(allStatuses, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Goal goal)
        {
            List<Priority> allPriorities = _uow.PriorityRepository.Get().ToList();
            ViewBag.allPriorities = new SelectList(allPriorities, "Id", "Name");

            List<Status> allStatuses = _uow.StatusRepository.Get().ToList();
            ViewBag.allStatuses = new SelectList(allStatuses, "Id", "Name");

            if (ModelState.IsValid)
            {

                _uow.GoalRepository.Insert(goal);
                _uow.Save();
                return RedirectToAction("Index");
            }
            return View(goal);
        }
        public IActionResult Details(Guid id)
        {
            if (id.ToString() is null)
            {
                return NotFound();
            }
            var goal = _uow.GoalRepository.GetById(id);
            if (goal is null)
            {
                return NotFound();
            }

            return View(goal);
        }
        public IActionResult ChangeStatus(Guid id) 
        { 
            _uow.GoalRepository.ChangeStatus(id);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(Guid id)
        {
            _uow.GoalRepository.Delete(id);
            _uow.Save();
            return RedirectToAction("Index");
        }
    }
}
