using CRUD_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_DAL.Interface
{
   public interface IFood
    {
        public tblColdDrinks AddFood(tblColdDrinks model);

        public bool UpdateFood(tblColdDrinks model);

        public bool DeleteFood(int Id);

        //public List<FoodName> GetAllFoodsName()
        public bool DeleteByCondition();
        public double TotalQuantityPrice();
    }
}
