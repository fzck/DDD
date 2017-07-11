using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
