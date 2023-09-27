using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultiesController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultiesController(IWalkDifficultyRepository walkDifficultyRepository,
            IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWalkRepositoriesAsync()
        {
            var walkDifficulties = await walkDifficultyRepository.GetAllAsyc();
            var walkDifficultiesDTO = mapper.Map<List<Models.DTO.WalkDifficulty>>(walkDifficulties);
            return Ok(walkDifficultiesDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDifficultyAsync")]
        public async Task<IActionResult> GetWalkDifficultyAsync(Guid id)
        {
            var walkDifficulty = await walkDifficultyRepository.GetAsyc(id);
            if (walkDifficulty == null)
            {
                return NotFound();
            }
            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);
            return Ok(walkDifficultyDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AddWalkDifficultyAsync(Models.DTO.AddWalkDifficultyRequest addWalkDifficultyRequest)
        {
            var walkDifficulty = mapper.Map<Models.Domain.WalkDifficulty>(addWalkDifficultyRequest);
            walkDifficulty = await walkDifficultyRepository.AddAsync(walkDifficulty);
            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);
            return CreatedAtAction(nameof(GetWalkDifficultyAsync),
                new { id = walkDifficultyDTO.Id }, walkDifficultyDTO);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateWalkDifficultyAsync(Guid id,
            Models.DTO.UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
        {
            var walkDifficulty = mapper.Map<Models.Domain.WalkDifficulty>(updateWalkDifficultyRequest);
            walkDifficulty = await walkDifficultyRepository.UpdateAsync(id, walkDifficulty);
            if (walkDifficulty == null) { return NotFound(); }
            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);
            return Ok(walkDifficultyDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkDifficultyAsync(Guid id)
        {
            var walkDifficulty = await walkDifficultyRepository.DeleteAsync(id);
            if (walkDifficulty == null)
            {
                return NotFound();
            }
            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);
            return Ok(walkDifficultyDTO);
        }
    }
}
