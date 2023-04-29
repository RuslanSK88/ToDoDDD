using DAL.Datas;
using DAL.Entities;

namespace BLL.Repositories;

public class GoalRepository : Repository<Goal>
{
    private readonly AppDbContext _db;
    public GoalRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public Goal GetByName(string goalName)
    {
        Goal goal = _db.Goals.FirstOrDefault(x => x.Name == goalName);
        return goal;
    }
    public void ChangeStatus(Guid id)
    {
        Goal goal = _db.Goals.Find(id);
        Status stat = _db.Statuses.FirstOrDefault(x => x.Id == goal.StatusId);
        if (stat.Name == "Новая")
        {
            Status st = _db.Statuses.FirstOrDefault(x => x.Name == "Открыта");
            goal.StatusId = st.Id;
        }
        else if(stat.Name == "Открыта")
        {
            Status st = _db.Statuses.FirstOrDefault(x => x.Name == "Закрыта");
            goal.StatusId = st.Id;
        }
        _db.Goals.Update(goal);
        _db.SaveChanges();
    }
}
