using System.Threading.Tasks;
using YouTennis.Base.Model;
using YouTennis.Base.Repository;
using YouTennis.Core.Context;

namespace YouTennis.Core.Respository
{
    public class ClubRepository : BaseAsync<Club>, IClubRepository
    {
        public ClubRepository(ApiContext context) : base(context)
        {
        }
    }
}
