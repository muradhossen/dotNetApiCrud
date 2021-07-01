using CRUD_DAL.Data;
using CRUD_DAL.Interface;
using CRUD_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DAL.Repository
{
    public class RepositoryFood : IFoodRepository<tblColdDrinks>
    {
        ApplicationDbContext _dbContext;
        public RepositoryFood(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public tblColdDrinks Create(tblColdDrinks _object)
        {
            var obj =  _dbContext.tblColdDrinks.Add(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(tblColdDrinks _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public List<tblColdDrinks> GetAll()
        {
            try
            {
                var list = _dbContext.tblColdDrinks.ToList();
                return list;
            }
            catch (Exception ee)
            {
                throw;
            }
        }

        public tblColdDrinks GetById(int Id)
        {
            return _dbContext.tblColdDrinks.Find(Id);
        }

        public void Update(tblColdDrinks _object)
        {
            _dbContext.tblColdDrinks.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
