using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouTennis.Base.Model;
using YouTennis.Base.Service;

namespace YouTennis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourtController : ControllerBase
    {
        private readonly ICourtService _courtService;
        private readonly IOpeningHoursService _openingHoursService;
        public CourtController(ICourtService courtService, IOpeningHoursService openingHoursService)
        {
            _courtService = courtService;
            _openingHoursService = openingHoursService;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _courtService.GetAll();
            return Ok(result);
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add(Court model)
        {
            var newItemId = await _courtService.Add(model);

            var openingHours = new List<OpeningHours>()
            {
                new OpeningHours { CourtId = newItemId, DayId = 0, OpeningTime = 10, ClosingTime = 20 },
                new OpeningHours { CourtId = newItemId, DayId = 1, OpeningTime = 10, ClosingTime = 20 },
                new OpeningHours { CourtId = newItemId, DayId = 2, OpeningTime = 10, ClosingTime = 20 },
                new OpeningHours { CourtId = newItemId, DayId = 3, OpeningTime = 10, ClosingTime = 20 },
                new OpeningHours { CourtId = newItemId, DayId = 4, OpeningTime = 10, ClosingTime = 20 },
                new OpeningHours { CourtId = newItemId, DayId = 5, OpeningTime = 10, ClosingTime = 20 },
                new OpeningHours { CourtId = newItemId, DayId = 6, OpeningTime = 10, ClosingTime = 20 },
            };

             //openingHours.ForEach(async x => await _openingHoursService.Add(x));

            foreach(var item in openingHours)
            {
                await _openingHoursService.Add(item);
            }

            return Ok(newItemId);
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _courtService.Delete(id);
            return Ok();
        }

        [Route("Get/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _courtService.Get(id);
            return Ok(result);
        }

        [Route("Update")]
        [HttpPost]
        public async Task<IActionResult> Update(Court model)
        {
            var updatedItem = await _courtService.Update(model);
            return Ok(updatedItem);
        }
        [AllowAnonymous]
        [Route("GetByClubId/{clubId}")]
        public async Task<IActionResult> GetByClubId(int clubId)
        {
            var result = await _courtService.GetByClubId(clubId);
            return Ok(result);
        }
    }
}
