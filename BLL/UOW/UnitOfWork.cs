
namespace BLL.UOW;

public class UnitOfWork
{
    private AppDbContext context;

    public UnitOfWork(AppDbContext _context)
    {
        context = _context;
    }
}
