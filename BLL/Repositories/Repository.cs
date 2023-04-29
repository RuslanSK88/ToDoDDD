
using DAL.Datas;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BLL.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _db;
    private readonly DbSet<T> dbSet;

    public Repository(AppDbContext db)
    {
        _db = db;
        dbSet = _db.Set<T>();
    }


    public T GetById(Guid id)
    {
        return dbSet.Find(id);
    }

    public IEnumerable<T> Get()
    {
        return dbSet.ToList();
    }

    public void Insert(T entity)
    {
        dbSet.Add(entity);
    }
    public void Delete(Guid id)
    {
        T entityToDelete = dbSet.Find(id);
        Delete(entityToDelete);
    }

    public void Delete(T entity)
    {
        if (_db.Entry(entity).State == EntityState.Detached)
        {
            dbSet.Attach(entity);
        }
        dbSet.Remove(entity);
    }
    public void Update(T entity)
    {
        dbSet.Attach(entity);
        _db.Entry(entity).State = EntityState.Modified;
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}
