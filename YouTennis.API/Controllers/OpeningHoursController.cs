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
    public class OpeningHoursController : ControllerBase
    {
        private readonly IOpeningHoursService _openingHoursService;
        public OpeningHoursController(IOpeningHoursService openingHoursService)
        {
            _openingHoursService = openingHoursService;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _openingHoursService.GetAll();
            return Ok(result);
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add(OpeningHours model)
        {
            var newItemId = await _openingHoursService.Add(model);
            return Ok(newItemId);
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _openingHoursService.Delete(id);
            return Ok();
        }

        [Route("Get/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _openingHoursService.Get(id);
            return Ok(result);
        }

        [Route("Update")]
        [HttpPost]
        public async Task<IActionResult> Update(OpeningHours model)
        {
            var updatedItem = await _openingHoursService.Update(model);
            return Ok(updatedItem);
        }
    }
}
