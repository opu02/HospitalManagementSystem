using System;
using System.Collections.Generic;
using System.Text;
using static DAL.Interfaces.IGenericRepository;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;

        void Save();
    }
}
