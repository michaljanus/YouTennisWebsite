using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YouTennis.Base.Model;
using YouTennis.Base.Service;

namespace YouTennis.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;
        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [Route("GetAll")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await _clubService.GetAll();

            return Ok(result);
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add(Club model)
        {
            var newItemId = await _clubService.Add(model);

            return Ok(newItemId);
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _clubService.Delete(id);

            return Ok();
        }

        [Route("Get/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _clubService.Get(id);

            return Ok(result);
        }

        [Route("Update")]
        [HttpPost]
        public async Task<IActionResult> Update(Club model)
        {
            var updatedItem = await _clubService.Update(model);

            return Ok(updatedItem);
        }
    }
}