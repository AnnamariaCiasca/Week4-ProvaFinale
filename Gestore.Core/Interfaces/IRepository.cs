using System;
using System.Collections.Generic;
using System.Text;

namespace Gestore.Core.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Fetch();
        T GetById(int id);
        bool Create(T item);
        bool Update(T item);
        bool Delete(int id);
    }
}