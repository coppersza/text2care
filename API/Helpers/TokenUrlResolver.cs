using System;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class TokenUrlResolver : IValueResolver<Token, TokenDto, string>
    {
        private readonly IConfiguration _config;

        public TokenUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Token source, TokenDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageURL) && source.ImageURL.StartsWith("images") )
            {
                return _config["ApiUrl"] + source.ImageURL;
            }
            if (string.IsNullOrEmpty(source.ImageURL))
                return _config["ApiUrl"] + "images/tokens/hourglass.png";
            return source.ImageURL;
        }
    }
}
