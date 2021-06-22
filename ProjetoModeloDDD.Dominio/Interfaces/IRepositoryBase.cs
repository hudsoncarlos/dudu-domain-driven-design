using System.Collections.Generic;

namespace ProjetoModeloDDD.Dominio.Interfaces
{
    public interface IRepositoryBase<T> where T : class //Trate ele como uma classe
    {
        void Add(T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(T obj);
        void Dispose();
    }
}
