using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorio<T>
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);
        T FindById (int id);
        IEnumerable<T> FindAll();
    }
}
