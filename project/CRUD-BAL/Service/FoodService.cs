using CRUD_BAL.ViewModels;
using CRUD_DAL.Interface;
using CRUD_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_BAL.Service
{
   public class FoodService : IFood
    {
        private readonly IFoodRepository<tblColdDrinks> _food;        
        public FoodService(IFoodRepository<tblColdDrinks> food)
        {
            _food = food;            
        }
        //01 Insert Food
        public tblColdDrinks AddFood(tblColdDrinks model)
        {
            return _food.Create(model);
        }

        //02 Update Food
        public bool UpdateFood(tblColdDrinks model)
        {
            try
            {
                if (model != null)
                {
                    _food.Update(model);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        //03 Delete Food 
        public bool DeleteFood(int Id)
        {

            try
            {
                var delFood = _food.GetById(Id);
                if (delFood != null)
                {
                    _food.Delete(delFood);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //04 Get All Food Name
        public List<FoodName> GetAllFoodsName()
        {
            var foodList= _food.GetAll();
            List<FoodName> foodNames = new List<FoodName>();
            foreach (var item in foodList)
            {
                FoodName foodName = new FoodName()
                {
                    strColdDrinksName = item.strColdDrinksName
                };
                foodNames.Add(foodName);
            }
            return foodNames;

        }

        //05: Delete All products if it’s quantity is less than 500
        public bool DeleteByCondition()
        {
            try
            {
                var foodList = _food.GetAll();
                foreach (var item in foodList)
                {
                    if (item.numQuantity < 500)
                    {
                        var delFood = _food.GetById(item.intColdDrinksId);
                        _food.Delete(delFood);                        
                    }                    
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }
        // 06: Find total price of all products
        public double TotalQuantityPrice()
        {
            var foodList = _food.GetAll();
            double TotalQuantityPrice = 0;
            foreach (var item in foodList)
            {
                var unitTotalPrice = item.numQuantity * item.numUnitPrice;
                TotalQuantityPrice +=(double) unitTotalPrice;
            }
            return TotalQuantityPrice;
        }
    }
}
