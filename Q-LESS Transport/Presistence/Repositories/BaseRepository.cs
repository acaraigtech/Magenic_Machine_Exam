using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Presistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly QLESSTransportAPIContextDb _context;

        public BaseRepository(QLESSTransportAPIContextDb context)
        {
            _context = context;
        }
    }
}
