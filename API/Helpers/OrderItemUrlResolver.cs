using System;
using AutoMapper;
using Core.Entities.OrderAggregate;
using API.Dtos.Orders;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _config;

        public OrderItemUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ItemOrdered.ImageURL))
            {
                return _config["ApiUrl"] + source.ItemOrdered.ImageURL;
            }
            return null;
        }
    }
}
