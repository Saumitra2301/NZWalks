using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper )
        {
            this.regionRepository = regionRepository;
            this.mapper=mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
           var regions= await regionRepository.GetAllAsync();
           var regionsDTO=mapper.Map<List<Models.DTO.Region>>(regions);
           return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid Id)
        {
            var region = await regionRepository.GetAsync(Id);
            if(region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest addRegionRequest)
        {
           var region=mapper.Map<Models.Domain.Region>(addRegionRequest);
           region = await regionRepository.AddAsync(region);

           var regionDTO = mapper.Map<Models.DTO.Region>(region);
           return CreatedAtAction(nameof(GetRegionAsync),new {id= regionDTO.Id}, regionDTO);

        }
        [HttpDelete]
        [Route("{Id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid Id)
        {
            var region = await regionRepository.DeleteAsync(Id);
            if (region == null)
            {
                return NotFound();
            }
            

            var regionDTO = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);

        }

        [HttpPut]
        [Route("{Id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute]Guid Id,[FromBody] Models.DTO.UpdateRegionRequest updateRegionRequest )
        {
            var region=mapper.Map<Models.Domain.Region>(updateRegionRequest);
            region = await regionRepository.UpdateAsync(Id, region);
            if (region == null)
            {
                return NotFound();
            }          
            region=await regionRepository.UpdateAsync(Id,region);
            var regionDTO = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);
        }
    }
}
