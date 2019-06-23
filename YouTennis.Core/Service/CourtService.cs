using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouTennis.Base.Model;
using YouTennis.Base.Repository;
using YouTennis.Base.Service;

namespace YouTennis.Core.Service
{
    public class CourtService :ICourtService
    {
        private readonly ICourtRepository _courtRepository;
        public CourtService(ICourtRepository courtRepository)
        {
            _courtRepository = courtRepository;
        }

        public async Task<int> Add(Court model)
        {
            return await _courtRepository.AddAsync(model);
        }

        public async Task Delete(int id)
        {
            var model = await _courtRepository.GetAsync(id);
            if (model is null) throw new ArgumentNullException($"Could not find item with Id: {id}");

            await _courtRepository.DeleteAsync(model);
        }

        public async Task<Court> Get(int id)
        {
            return await _courtRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Court>> GetAll()
        {
            return await _courtRepository.GetAllAsync();
        }

        public async Task<Court> Update(Court model)
        {
            return await _courtRepository.UpdateAsync(model);
        }

        public async Task<IEnumerable<Court>> GetByClubId(int clubId)
        {
            return await _courtRepository.GetByClubId(clubId);
        }
    }
}
