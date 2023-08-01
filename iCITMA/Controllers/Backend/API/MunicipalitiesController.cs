using Microsoft.AspNetCore.Mvc;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using System.Linq;

namespace MOROPO.CITMA.CMG.iCITMA.Controllers.Backend.API
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Route("api/[area]/[controller]")]
    [Area("location")]
    [ApiController]
    public class MunicipalitiesController : Controller
    {
        private readonly IEntityRepository<Municipality, System.Guid> municipalityRepository;

        public MunicipalitiesController(IEntityRepository<Municipality, System.Guid> municipalityRepository)
        {
            this.municipalityRepository = municipalityRepository;
        }

        [HttpGet("bystate/{key}")]
        public ActionResult<Municipality[]> GetByState(System.Guid key)
        {
            return Ok(municipalityRepository.FindBy(entity => entity.StateId == key).ToArray());
        }
    }
}
