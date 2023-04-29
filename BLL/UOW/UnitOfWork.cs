
using BLL.Repositories;
using DAL.Datas;

namespace BLL.UOW;

public class UnitOfWork
{
    private AppDbContext context;

    public UnitOfWork(AppDbContext _context)
    {
        context = _context;
    }

    private GoalRepository goalRepository;
    private StatusRepository statusRepository;
    private PriorityRepository priorityRepository;

    public GoalRepository GoalRepository
    {
        get
        {
            if (goalRepository == null)
            {
                goalRepository = new GoalRepository(context);
            }
            return goalRepository;
        }
    }
    public StatusRepository StatusRepository
    {
        get
        {
            if (statusRepository == null)
            {
                statusRepository = new StatusRepository(context);
            }
            return statusRepository;
        }
    }
    public PriorityRepository PriorityRepository
    {
        get
        {
            if (statusRepository == null)
            {
                priorityRepository = new PriorityRepository(context);
            }
            return priorityRepository;
        }
    }
    public void Save()
    {
        context.SaveChanges();
    }
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
