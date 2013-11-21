using System;

namespace Plinkit.Domain.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Add(T entity);                
        T GetByDate(DateTime date);        
    }
}