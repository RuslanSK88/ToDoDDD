using DAL.Entities;

namespace DAL.Interfaces;

public interface IStatusRepository : IRepository<Status>, IDisposable
{
}
