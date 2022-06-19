using System;
using Week2Homework.DataModel;
using Week2Homework.Repository;

namespace Week2Homework.Uow

{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Customer> CustomerRepository { get; }

        void Save();
    }
}
