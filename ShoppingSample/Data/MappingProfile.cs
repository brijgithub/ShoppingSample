using AutoMapper;
using ShoppingSample.Entities;
using ShoppingSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingSample.Data
{
    /// <summary>
    /// Class for mapping entitity and view model
    /// </summary>
    public class MappingProfile:Profile
    {

        #region Constructor
        /// <summary>
        /// MappingProfile
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(e => e.OrderId, ex => ex.MapFrom(s => s.Id))
                .ReverseMap();
            CreateMap<OrderItem,OrderItemViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>()
                 .ForMember(e => e.ProductId, ex => ex.MapFrom(s => s.Id))
                .ReverseMap();
            CreateMap<ContactViewModel, Contact>().ReverseMap();
        }
        #endregion 
    }
}
