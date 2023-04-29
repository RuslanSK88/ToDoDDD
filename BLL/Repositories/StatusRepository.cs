
using DAL.Datas;
using DAL.Entities;

namespace BLL.Repositories;

public class StatusRepository : Repository<Status>
{
    private readonly AppDbContext _db;
    public StatusRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }
}
