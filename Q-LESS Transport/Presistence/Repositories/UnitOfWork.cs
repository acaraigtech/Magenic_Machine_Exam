using Q_LESS_Transport.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Presistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QLESSTransportAPIContextDb _context;

        public UnitOfWork(QLESSTransportAPIContextDb context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
