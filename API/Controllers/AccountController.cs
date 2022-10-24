using System;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Dtos.Users;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserTokenService _userTokenService;
        private readonly IDonatorService _donatorService;
        private readonly IMapper _mapper;

        public AccountController(
            UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager, 

            IUserTokenService userTokenService, 
            IDonatorService donatorService,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userTokenService = userTokenService;
            _donatorService = donatorService;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindUserByClaimsPrincipleAsync(HttpContext.User);
            return new UserDto{
                Id = user.Id,
                Email = user.Email,
                Token = _userTokenService.CreateUserToken(user),
                DisplayName = user.DisplayName
            };
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<UserAddressDto>> GetUserAddress()
        {
            var user = await _userManager.FindUserByClaimsPrincipleWithAddressAsync(HttpContext.User);
            return _mapper.Map<UserAddress, UserAddressDto>(user.Address);            
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<UserAddressDto>> UpdateUserAddress(UserAddressDto address)
        {
            var user = await _userManager.FindUserByClaimsPrincipleWithAddressAsync(HttpContext.User);

            user.Address = _mapper.Map<UserAddressDto, UserAddress>(address);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) return Ok(_mapper.Map<UserAddress, UserAddressDto>(user.Address));
            return BadRequest("Problem updating the user address");
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized(new ApiResponse(401));
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            return new UserDto{
                Id = user.Id,
                Email = user.Email,
                MobileNumber = user.PhoneNumber,
                DisplayName = user.DisplayName,
                Token = _userTokenService.CreateUserToken(user)                
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (CheckEmailExistsAsync(registerDto.Email).Result.Value)
            {
                return new BadRequestObjectResult(new ApiValidationErrorResponse{Errors = new []{"Email address is in use"}});
            }
            var user = new AppUser{                
                Email = registerDto.Email,
                PhoneNumber = registerDto.MobileNumber,
                DisplayName = registerDto.DisplayName,
                UserName = registerDto.Email
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            var donator = await _donatorService.CreateOrUpdateDonatorAsync(user.Email, user.PhoneNumber, user.DisplayName);
            if (donator == null) return BadRequest(new ApiResponse(400));

            return new UserDto{
                Id = user.Id,
                Email = user.Email,
                MobileNumber = user.PhoneNumber,
                DisplayName = user.DisplayName,                
                Token = _userTokenService.CreateUserToken(user)                
            };

        }
        
    }
}
