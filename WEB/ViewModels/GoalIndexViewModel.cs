
using DAL.Entities;

namespace WEB.ViewModels;

public class GoalIndexViewModel
{
    public List<Goal>? Goals { get; set; }
    public List<Status>? Statuses {  get; set; }
    public List<Priority>? Priorities { get; set; }

}
