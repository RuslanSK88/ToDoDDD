using DAL.Datas;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories;

public class PriorityRepository : Repository<Priority>
{
    private readonly AppDbContext _db;
    public PriorityRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }
}
