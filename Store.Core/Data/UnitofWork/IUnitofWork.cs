using Store.Core.Data.Repositories;
using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.Data.UnitofWork
{
   public interface IUnitofWork  : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : Entity<int>;

        int SaveChanges();
    }
}