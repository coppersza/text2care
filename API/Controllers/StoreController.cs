using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StoreController : BaseApiController
    {
        private readonly IGenericRepository<Store> _storeRepo;
        private readonly IMapper _mapper;
        private readonly IStoreService _storeService;

        public StoreController(IGenericRepository<Store> storeRepo,
            IMapper mapper, IStoreService storeService)
        {
            _storeRepo = storeRepo;
            _mapper = mapper;
            _storeService = storeService;
        }
        // [Cached(600)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<StoreDto>>> GetStores()        
        {
            var spec = new StoreSpec();
            var data = await _storeRepo.ListAsync(spec);
            var dataMap = _mapper.Map<IReadOnlyList<Store>, IReadOnlyList<StoreDto>>(data);
            return Ok(dataMap);
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<IReadOnlyList<StoreDto>>> GetStoresUser()
        {
            var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var store = await _storeService.GetStoreForUserAsync(email);
            var spec = new StoreSpec(store.StoreUID);
            var data = await _storeRepo.ListAsync(spec);
            var dataMap = _mapper.Map<IReadOnlyList<Store>, IReadOnlyList<StoreDto>>(data);
            return Ok(dataMap);
        }

        // [Cached(600)]
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreDto>> GetStore(string id)        
        {
            var spec = new StoreSpec(id);
            var data = await _storeRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Store, StoreDto>(data);              
        }                
    }
}
