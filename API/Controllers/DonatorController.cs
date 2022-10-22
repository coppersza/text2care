using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class DonatorController : BaseApiController
    {
        private readonly IGenericRepository<Donator> _donatorRepo;
        private readonly IMapper _mapper;

        public DonatorController(IGenericRepository<Donator> donatorRepo,
            IMapper mapper)
        {
            _donatorRepo = donatorRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DonatorDto>>> GetDonators()
        {
            var spec = new DonatorSpec();
            var data = await _donatorRepo.ListAsync(spec);
            var mapData = _mapper.Map<IReadOnlyList<Donator>, IReadOnlyList<DonatorDto>>(data);
            return Ok(mapData);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DonatorDto>> GetDonator(string id)        
        {
            var spec = new DonatorSpec(id);
            var data = await _donatorRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Donator, DonatorDto>(data);              
        }
        [HttpGet("{email}")]
        public async Task<ActionResult<DonatorDto>> GetDonatorByEmail(string email)        
        {
            var spec = new DonatorSpecEmail(email);
            var data = await _donatorRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Donator, DonatorDto>(data);              
        }                       
    }    
    
}
