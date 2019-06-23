using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouTennis.Base.Model;
using YouTennis.Base.Repository;
using YouTennis.Base.Service;
using YouTennis.Core.Exception;

namespace YouTennis.Core.Service
{
    public class OpeningHoursService : IOpeningHoursService
    {
        private readonly IOpeningHoursRepository _openingHoursRepository;
        public OpeningHoursService(IOpeningHoursRepository openingHoursRepository)
        {
            _openingHoursRepository = openingHoursRepository;
        }

        public async Task<int> Add(OpeningHours model)
        {
            return await _openingHoursRepository.AddAsync(model);
        }

        public async Task Delete(int id)
        {
            var model = await _openingHoursRepository.GetAsync(id);
            if (model is null) throw new NotFoundException($"Could not find item with Id: {id}");

            await _openingHoursRepository.DeleteAsync(model);
        }

        public async Task<OpeningHours> Get(int id)
        {
            return await _openingHoursRepository.GetAsync(id);
        }

        public async Task<IEnumerable<OpeningHours>> GetAll()
        {
            return await _openingHoursRepository.GetAllAsync();
        }

        public async Task<OpeningHours> Update(OpeningHours model)
        {
            return await _openingHoursRepository.UpdateAsync(model);
        }
    }
}
