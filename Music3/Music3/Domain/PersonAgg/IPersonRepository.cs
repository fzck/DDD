using Music3.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Domain.PersonAgg
{
    public interface IPersonRepository : IRepository<Person, long>
    {
    }
}
