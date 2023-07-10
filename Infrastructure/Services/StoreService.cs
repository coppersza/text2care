using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastructure.Services
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StoreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Store> GetStoreForUserAsync(string email)
        {
            var spec = new StoreSpecEmail(email);
            var store = await _unitOfWork.Repository<Store>().GetEntityWithSpec(spec);
            return store;
        }
    }
}