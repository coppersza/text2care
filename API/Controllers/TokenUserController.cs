using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Extensions;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class TokenUserController : BaseApiController
    {
        private readonly ITokenService _tokenService;

        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDonatorService _donatorService;
        private readonly IStoreService _storeService;

        public TokenUserController(ITokenService tokenService, IMapper mapper, UserManager<AppUser> userManager,
            IDonatorService donatorService, IStoreService storeService)
        {
            _userManager = userManager;
            _donatorService = donatorService;
            _storeService = storeService;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Token>> CreateUserToken(TokenDto tokenDto)
        {
            var user = await _userManager.FindUserByClaimsPrincipleAsync(HttpContext.User);
            var email = user.Email;
            var userName = user.DisplayName;
            var mobileNumber = user.PhoneNumber;

            var productId = tokenDto.ProductId;
            var tokenUID = tokenDto.TokenUID;
            var tokenName = tokenDto.TokenName;

            var token = await _tokenService.CreateOrUpdateTokenAsync(tokenUID, tokenName, productId, email);

            if (token == null) return BadRequest(new ApiResponse(400, "Problem creating order"));
            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TokenDto>>> GetTokens([FromQuery] TokenSpecParams specParams)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var donator = await _donatorService.GetDonatorForUserAsync(email);
            specParams.DonatorUID = donator.DonatorUID;

            var data = await _tokenService.GetTokensForUserAsync(specParams);
            var totalItems = await _tokenService.GetTokensForUserCountAsync(specParams);
            var dataMap = _mapper.Map<IReadOnlyList<Token>, IReadOnlyList<TokenDto>>(data);

            return Ok(new Pagination<TokenDto>(specParams.PageIndex, specParams.PageSize, totalItems, dataMap));
        }

        [Authorize]
        [HttpGet("store")]
        public async Task<ActionResult<IReadOnlyList<TokenDto>>> GetTokensStore([FromQuery] TokenSpecParams specParams)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var store = await _storeService.GetStoreForUserAsync(email);
            specParams.StoreUID = store.StoreUID;

            var data = await _tokenService.GetTokensForUserAsync(specParams);
            var totalItems = await _tokenService.GetTokensForUserCountAsync(specParams);
            var dataMap = _mapper.Map<IReadOnlyList<Token>, IReadOnlyList<TokenDto>>(data);

            return Ok(new Pagination<TokenDto>(specParams.PageIndex, specParams.PageSize, totalItems, dataMap));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<TokenDto>> GetToken(string id)
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            //var token = await _tokenService.GetTokenByIdAsync(id, email);
            var token = await _tokenService.GetTokenByIdAsync(id);
            if (token == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<Token, TokenDto>(token);
        }
    }
}
