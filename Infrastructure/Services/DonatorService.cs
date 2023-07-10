using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastructure.Services
{
    public class DonatorService : IDonatorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DonatorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Donator> CreateOrUpdateDonatorAsync(string email, string mobileNumber, string fullName)
        {
            var spec = new DonatorSpecEmail(email);
            var donator = await _unitOfWork.Repository<Donator>().GetEntityWithSpec(spec);
            if (donator == null)
            {
                int pos = mobileNumber.IndexOf('+');
                if (pos >= 0)
                    mobileNumber = mobileNumber.Remove(pos, 1);
                var specMobile = new DonatorSpecMobileNumber(mobileNumber);
                donator = await _unitOfWork.Repository<Donator>().GetEntityWithSpec(specMobile); 

                if (donator != null && donator.EmailAddress != email)
                {
                    donator.EmailAddress = email;
                    _unitOfWork.Repository<Donator>().Update(donator);
                    var result = await _unitOfWork.Complete();
                }
            }

            if (donator == null)
            {
                //Need to add a donator if it doesnt already exist.
                var donatorUID = Guid.NewGuid().ToString().ToUpper();
                var countryId = 1;
                donator = new Donator(donatorUID, email, fullName, mobileNumber, countryId);
                _unitOfWork.Repository<Donator>().Add(donator);
                var result = await _unitOfWork.Complete();
                if (result <= 0) return null;                   
            }               
            return donator;
        }

        public async Task<Donator> GetDonatorForUserAsync(string email)
        {
            var spec = new DonatorSpecEmail(email);
            var donator = await _unitOfWork.Repository<Donator>().GetEntityWithSpec(spec);
            return donator;
        }
    }
}