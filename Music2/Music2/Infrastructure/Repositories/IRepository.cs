using Music2.Domain;
using Music2.Infrastructure.UnitOfWork;
using Music2.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music2.Infrastructure.Repositories
{
   
    public interface IRepository<TEntity, in TKey> where TEntity : Entity
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Modify(TEntity entity);
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Specification<TEntity> spec);
        MainUnitOfWork unitOfWork { get; }
    }
}
