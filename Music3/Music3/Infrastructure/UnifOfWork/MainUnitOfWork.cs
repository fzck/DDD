using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Music3.Infrastructure.UnitOfWork
{
    public class MainUnitOfWork : DbContext, IUnitOfWork
    {
        public FirstGenUnitOfWork _firstGenUnitOfWork { get; set; }
        public SecondGenUnitOfWork _secondGenUnitOfWork { get; set; }
        public ThirdGenUnitOfWork _thirdGenUnitOfWork { get; set; }

        public MainUnitOfWork(FirstGenUnitOfWork firstGenUnitOfWork, SecondGenUnitOfWork secondGenUnitOfWork, ThirdGenUnitOfWork thirdGenUnitOfWork)
        {
            _firstGenUnitOfWork = firstGenUnitOfWork;
            _secondGenUnitOfWork = secondGenUnitOfWork;
            _thirdGenUnitOfWork = thirdGenUnitOfWork;
        }

        public void Commit()
        {
            SaveChanges();
        }

        public void Rollback()
        {
            Dispose();
        }

        public IDbContextTransaction BeginTransaction(int gen)
        {
            IDbContextTransaction transaction = null;
            switch (gen)
            {
                case 1: transaction = _firstGenUnitOfWork.Database.BeginTransaction();
                    break;
                case 2: transaction = _firstGenUnitOfWork.Database.BeginTransaction();
                    _secondGenUnitOfWork.Database.UseTransaction(transaction.GetDbTransaction());
                    break;
                case 3: transaction = _firstGenUnitOfWork.Database.BeginTransaction();
                    var currentTransaction = transaction.GetDbTransaction();
                    _secondGenUnitOfWork.Database.UseTransaction(currentTransaction);
                    _thirdGenUnitOfWork.Database.UseTransaction(currentTransaction);
                    break;

            }
            return transaction;
        }

    }
}
