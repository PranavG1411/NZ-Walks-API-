using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NZwalks.API.Data;
using NZwalks.API.Model.Domain;
using NZwalks.API.Model.DTO;
using NZwalks.API.NewFolder;
using NZwalks.API.Repositories;
using System.Text.Json;

namespace NZwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class RegionsController : ControllerBase
    {
        private readonly NZwalksDBContextcs dbContext;
        private readonly IRegionRepositories regionRepositories;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(NZwalksDBContextcs dbContext, IRegionRepositories regionRepositories, IMapper mapper ,
            ILogger<RegionsController> logger

            )
        {
            this.dbContext = dbContext;
            this.regionRepositories = regionRepositories;
            this.mapper = mapper;
            this.logger = logger;
        }

        // ✅ GET all regions
        // URL: GET https://localhost:{port}/api/regions
        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {

            //FOR LOGGING 
            //logger.LogInformation("GetAllREgions Action Method was Invoked");
            //logger.LogWarning("this is warning");
            //logger.LogError("this is a error log");

            // Get data from database (domain model)
            var regionsDomain = await regionRepositories.GetAllAsync();

            // Convert domain model to DTO
            //var regionsDto = new List<RegionsDTO>();
            //foreach (var region in regionsDomain)
            //{
            //    regionsDto.Add(new RegionsDTO
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        RegionImageurl = region.RegionImageurl
            //    });

           var regionsDto =  mapper.Map<List<RegionsDTO>>(regionsDomain);

            logger.LogInformation($"finished GetAllREgions request with data : {JsonSerializer.Serialize(regionsDto)}");

            // Send DTO to client
            return Ok(regionsDto);
        }

        // ✅ GET region by ID
        // URL: GET https://localhost:{port}/api/regions/{id}
        [HttpGet]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get region from database using id
            var regionDomain = await regionRepositories.GetByIDAsync(id);

            if (regionDomain == null)
            {
                return NotFound(); // If not found, return 404
            }

            // Convert domain model to DTO
            //var regionsDto = new RegionsDTO
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageurl = regionDomain.RegionImageurl
            //};

            var regionsDto = mapper.Map<RegionsDTO>(regionDomain);

            return Ok(regionsDto); // Return region to client
        }

        // ✅ POST to create new region
        // URL: POST https://localhost:{port}/api/regions
        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
           
                // Convert DTO to domain model
                //var regionDomainModel = new Region
                //{
                //    Code = addRegionRequestDto.Code,
                //    Name = addRegionRequestDto.Name,
                //    RegionImageurl = addRegionRequestDto.RegionImageurl
                //};

                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                // Add to database (auto-generates Id)
                regionDomainModel = await regionRepositories.CreateAsync(regionDomainModel);

                // Convert domain model back to DTO
                //var regionsDto = new RegionsDTO
                //{
                //    Id = regionDomainModel.Id,
                //    Code = regionDomainModel.Code,
                //    Name = regionDomainModel.Name,
                //    RegionImageurl = regionDomainModel.RegionImageurl
                //};

                var regionsDto = mapper.Map<RegionsDTO>(regionDomainModel);

                // Return 201 Created with location header
                return CreatedAtAction(nameof(GetById), new { id = regionsDto.Id }, regionsDto);

            
            
           
        }

        // ✅ PUT to update existing region
        // URL: PUT https://localhost:{port}/api/regions/{id}
        [HttpPut]
        [Route("{id:guid}")]
        //[ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AddRegionRequestDto addRegionRequestDto)
        {

           
                // Convert Dtos to model to pass to updateAsync method;

                //var regionDomainModel = new Region
                //{
                //    Code = addRegionRequestDto.Code,
                //    Name = addRegionRequestDto.Name,
                //    RegionImageurl = addRegionRequestDto.RegionImageurl


                //};
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);




                // Check if region exists
                regionDomainModel = await regionRepositories.UpdateAsync(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }



                // Convert updated region to DTO
                //var regionsDto = new RegionsDTO
                //{
                //    Id = regionDomainModel.Id,
                //    Code = regionDomainModel.Code,
                //    Name = regionDomainModel.Name,
                //    RegionImageurl = regionDomainModel.RegionImageurl
                //};

                var regionsDto = mapper.Map<RegionsDTO>(regionDomainModel);
                return Ok(regionsDto); // Return updated region

           
                
        }

        // ✅ DELETE a region by ID
        // URL: DELETE https://localhost:{port}/api/regions/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Writer , Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Find region by ID
            var regionDomainModel = await regionRepositories.DeleteAsync(id);

            // Convert deleted region to DTO
            //var regionDto = new RegionsDTO
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageurl = regionDomainModel.RegionImageurl
            //};
            var regionsDto = mapper.Map<RegionsDTO>(regionDomainModel);

            return Ok(regionsDto); // Return deleted region info
        }
    }
}
