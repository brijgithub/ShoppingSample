using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingSample.Data;
using ShoppingSample.DataAcessLayer;
using ShoppingSample.Entities;
using ShoppingSample.Models;

namespace ShoppingSample.Controllers
{
    /// <summary>
    /// Created Order Controller for creating API SERVICES FOR LEARNING 
    /// </summary>
    [Route("api/[Controller]")]
    public class OrderController : Controller
    {
        #region Constructor
        /// <summary>
        /// initialise
        /// </summary>
        /// <param name="rep"></param>
        /// <param name="log"></param>
        /// <param name="mapper"></param>
        public OrderController(IShoppingRepository rep, ILogger<OrderController> log,IMapper mapper)
        {
            Rep = rep;
            Log = log;
            Mapper = mapper;
        }
        #endregion

        #region Properties
        /// <summary>
        /// IShoppingRepository
        /// </summary>
        public IShoppingRepository Rep { get; }
        /// <summary>
        /// ILogger
        /// </summary>
        public ILogger Log { get; }
        /// <summary>
        /// IMapper
        /// </summary>
        public IMapper Mapper { get; }
        #endregion

        #region Get Methods

        #region Get
        /// <summary>
        /// get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(Mapper.Map<IEnumerable<Order>,IEnumerable<OrderViewModel>>(Rep.GetAllOrders()));

            }
            catch (Exception ex)
            {
                Log.LogError($"Failed to retrive order:{ex}");
                return BadRequest("Failed to retrieve order");
            }


        }
        #endregion

        #region GetOrderbyId
        /// <summary>
        /// GetOrderbyId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public ActionResult GetOrderById( int id)
        {
            try
            {
                var result = Rep.GetOrderById(id);
                if (result != null) return Ok(Mapper.Map<Order,OrderViewModel>(result));
                else return NotFound();
            }
            catch (Exception ex)
            {
                Log.LogError($"Failed to retrive order by id :{ex}");
                return BadRequest("Failed to retrieve order");
            }


        }
        #endregion

        #endregion

        #region Post
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost()]
        public ActionResult Post([FromBody]OrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = Mapper.Map<OrderViewModel, Order>(model);

                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }
                    Rep.SaveEntity(newOrder);
                    if (Rep.SaveAll()) return Created($"api/order/{newOrder.Id}", Mapper.Map<Order,OrderViewModel>(newOrder));
                }
                else { return BadRequest(ModelState); }
                
            }
            catch (Exception ex)
            {
                Log.LogError($"Failed to save order details :{ex}");
            }
            return BadRequest("Failed to save order details");


        }
        #endregion 
    }
}