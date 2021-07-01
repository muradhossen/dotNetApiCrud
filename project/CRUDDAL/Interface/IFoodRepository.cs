using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_DAL.Interface
{
   public interface IFoodRepository<T>
    {
        public T Create(T _object);

        public void Update(T _object);

        public List<T> GetAll();

        public T GetById(int Id);

        public void Delete(T _object);
    }
}
