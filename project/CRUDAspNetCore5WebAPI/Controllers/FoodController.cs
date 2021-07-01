using CRUD_BAL.Service;
using CRUD_BAL.ViewModels;
using CRUD_DAL.Interface;
using CRUD_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAspNetCore5WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
         private readonly FoodService _foodService;
        private readonly IFood _iService;
         
        public FoodController(FoodService foodService,IFood service)
        {
            this._foodService = foodService;
            this._iService = service;
        }

        //01 Add Food
        [HttpPost("AddFood")]
        public IActionResult AddFood(tblColdDrinks model)
        {
            try
            {                
                _iService.AddFood(model);
                return Ok("Save successfull");
            }
            catch (Exception ex)
            {

                return BadRequest("Save not successfull");
            }
        }
        //02  Update Food
        [HttpPut("UpdateFood")]
        public IActionResult UpdateFood(tblColdDrinks model)
        {
            try
            {
                var result = _iService.UpdateFood(model);
                if (result)
                {
                    return Ok("Update Successfull");
                }
                return BadRequest("Update not Successfull");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //03 Delete Food
        [HttpDelete("DeleteFood")]
        public IActionResult DeleteFood(int Id)
        {
            try
            {
                var result = _iService.DeleteFood(Id);

                if (result)
                {
                    return Ok("Success");
                }
                return BadRequest("Delete not successfull");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //04 Get All Food Name
        [HttpGet("GetNameList")]
        public IActionResult GetNameList()
        {
            try
            {
                //return _foodService.GetAllFoodsName();
                var dataList = _foodService.GetAllFoodsName().ToList();
                var json = JsonConvert.SerializeObject(dataList);
                return Ok(json);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //05: Delete All products if it’s quantity is less than 500
        [HttpDelete("DeleteByCondition")]
        public IActionResult DeleteByCondition()
        {
            try
            {
                var result= _iService.DeleteByCondition();
                if (result)
                    return Ok("Delete Successfull");
                else
                    return Ok("Delete not Successfull");

            }
            catch (Exception)
            {
                return Ok("Delete not Successfull");
            }
            
        }
        // 06: Find total price of all products
        [HttpGet("GetTotalPrice")]
        public IActionResult GetTotalPrice()
        {
            try
            {

                var result = _foodService.TotalQuantityPrice();
                if (result>=0)
                {
                    var json = JsonConvert.SerializeObject(result);
                    return Ok(json);
                }

                return Ok("Something is wrong");

            }
            catch (Exception ex)
            {
                return Ok("Something is wrong");
            }
        }       
    }
}
