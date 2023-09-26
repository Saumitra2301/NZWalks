using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var walks = await walkRepository.GetAllAsync();
            var regionsDTO = mapper.Map<List<Models.DTO.Walk>>(walks);
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id}")]
        [ActionName("GetAsync")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            //Get Domain Walk Object
            var walk = await walkRepository.GetAsync(id);
            //Convert Walk Domain to Walk DTO
            var walkDTO = mapper.Map<Models.DTO.Walk>(walk);
            //return WalkDTO of type OK IactionResult
            return Ok(walkDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Models.DTO.AddWalkRequest addWalkRequest)
        {
            var walk = mapper.Map<Models.Domain.Walk>(addWalkRequest);
            walk = await walkRepository.AddAsync(walk);
            var walkDTO = mapper.Map<Models.DTO.Walk>(walk);
            return CreatedAtAction(nameof(GetAsync), new { id = walkDTO.Id }, walkDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]Guid id,
                                  [FromBody] Models.DTO.AddWalkRequest UpdateWalkRequest)
        {
            var walk = mapper.Map<Models.Domain.Walk>(UpdateWalkRequest);
            walk = await walkRepository.updateAsync(id,walk);
            if(walk == null)
            {
                return NotFound();
            }
            var walkDTO = mapper.Map<Models.DTO.Walk>(walk);
            return Ok(walkDTO);
        }
        
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var walk = await walkRepository.DeleteAsync(id);
            if (walk == null) { 
             return NotFound();
            }
            var walkDTO = mapper.Map<Models.DTO.Walk>(walk);
            return Ok(walkDTO);
        }
    }
}
