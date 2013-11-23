using System;
using System.Data.Entity;
using System.Linq;
using Plinkit.Domain.Context;
using Plinkit.Domain.Models;

namespace Plinkit.Domain.Repositories
{
    public class SqlDailyLinksRepository : IRepository<DailyLinksContainer>
    {
        private PlinkitContext _context;

        public void Add(DailyLinksContainer entity)
        {
            using (_context = new PlinkitContext())
            {
                _context.DailyLinksContainers.Add(entity);
                _context.SaveChanges();
            }
        }

        public DailyLinksContainer GetByDate(DateTime date)
        {
            using (_context = new PlinkitContext())
            {                
                return _context
                    .DailyLinksContainers
                    .Include(c => c.Links)
                    .FirstOrDefault(c => c.Date == date);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
