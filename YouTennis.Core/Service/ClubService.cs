using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouTennis.Base.Model;
using YouTennis.Base.Repository;
using YouTennis.Base.Service;

namespace YouTennis.Core.Service
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _clubRepository;
        public ClubService(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        public async Task<int> Add(Club model)
        {
            return await _clubRepository.AddAsync(model);
        }

        public async Task Delete(int id)
        {
            var model = await _clubRepository.GetAsync(id);
            if (model is null) throw new ArgumentNullException($"Could not find item with Id: {id}");

            await _clubRepository.DeleteAsync(model);
        }

        public async Task<Club> Get(int id)
        {
            return await _clubRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _clubRepository.GetAllAsync();
        }

        public async Task<Club> Update(Club model)
        {
            return await _clubRepository.UpdateAsync(model);
        }
    }
}
