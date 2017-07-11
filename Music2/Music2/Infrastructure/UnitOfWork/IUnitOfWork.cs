using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
