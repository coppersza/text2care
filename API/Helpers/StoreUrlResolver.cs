using System;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class StoreUrlResolver : IValueResolver<Store, StoreDto, string>
    {
        private readonly IConfiguration _config;

        public StoreUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Store source, StoreDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _config["ApiUrl"] + source.ImageUrl;
            }
            return null;
        }
    }
}
