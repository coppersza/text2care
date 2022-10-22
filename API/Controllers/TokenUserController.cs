using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Extensions;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class TokenUserController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public TokenUserController(ITokenService tokenService, IMapper mapper)
        {
            _tokenService = tokenService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<Token>> CreateUserToken(TokenDto tokenDto){
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            // var product = _mapper.Map<ProductDto, Product>(tokenDto.Product);
            var productId = tokenDto.ProductId;
            var tokenUID = tokenDto.TokenUID;
            var tokenName = tokenDto.TokenName;
            
            var token = await _tokenService.CreateOrUpdateTokenAsync(tokenUID, tokenName, productId, email);

            if (token == null) return BadRequest(new ApiResponse(400, "Problem creating order"));
            return Ok(token);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TokenDto>>> GetTokensForUser([FromQuery]TokenSpecParams specParams){
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var data = await _tokenService.GetTokensForUserAsync(email, specParams);
            var totalItems = await _tokenService.GetTokensForUserCountAsync(email, specParams);
            var dataMap = _mapper.Map<IReadOnlyList<Token>, IReadOnlyList<TokenDto>>(data);

            // return Ok(dataMap);

            return Ok(new Pagination<TokenDto>(specParams.PageIndex, specParams.PageSize, totalItems, dataMap));                
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TokenDto>> GetTokenByIdForUser(string id){
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var order = await _tokenService.GetTokenByIdAsync(id, email);
            if (order == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<Token, TokenDto>(order);
        }        
    }
}
