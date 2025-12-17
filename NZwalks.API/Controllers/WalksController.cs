using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZwalks.API.Model.Domain;
using NZwalks.API.Model.DTO;
using NZwalks.API.NewFolder;
using NZwalks.API.Repositories;

namespace NZwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IWalkREpositorycs walkREpository;

        public WalksController(IMapper mapper, IWalkREpositorycs walkREpository)
        {
            _mapper = mapper;
            this.walkREpository = walkREpository;
        }

        // Get All walks 
        // Get : /api/walks?filterON=Name&filterQuery=Beach&sortBy=Name&isAscending=true&apgeNumber=1&pageSize=10
        [HttpGet]
        
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn , [FromQuery]string? filterQuery, [FromQuery] string? sortBy , [FromQuery] bool? isAscending, [FromQuery] int Page = 1 , [FromQuery] int PageSize = 1000 )
        {
            var walkDomainModel = await walkREpository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, Page , PageSize );


            // Create an exception if any 
            //throw new Exception("THis is new Exception");


            // Converting Model into dto and send it to api user 
            var WalksDTo = _mapper.Map<List<WalkDTOcs>>(walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(walkDomainModel);
        }




        // Create Walks 
        // POST: /api/walks

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDto addWalksRequestDto)
        {
            
                // Map DTO to Domain Model
                var walkDomainModel = _mapper.Map<Walk>(addWalksRequestDto);

                // saving it to database 
                await walkREpository.CreateAsync(walkDomainModel);


                // return ok 
                return Ok(_mapper.Map<WalkDTOcs>(walkDomainModel));
            
           

        }



        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> GetwalkbyID( Guid id)
        {
            var domainmodel = await walkREpository.GetWalkByIDAsync(id);

            if (domainmodel == null) 
            { 
                return NotFound("Domain is null");
            }

            var walksDTo = _mapper.Map<WalkDTOcs>(domainmodel);

            return Ok(walksDTo);


        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id ,[FromBody] UpdateWalksDTO updateWalksRequestDto)
        {

            
                // convert dto to model

                var walksDomainmodel = _mapper.Map<Walk>(updateWalksRequestDto);



                // check it model exist and then save data to the database

                walksDomainmodel = await walkREpository.PutAsync(id, walksDomainmodel);
                if (walksDomainmodel == null)
                {
                    return NotFound();
                }

                // convert response to dto 

                var walkDto = _mapper.Map<WalkDTOcs>(walksDomainmodel);

                return Ok(walkDto);
            
            

        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleteWalkDomainResult = await walkREpository.DeleteAsync(id);

            if(deleteWalkDomainResult == null)
                {
                return NotFound();
            }

            // Map Domain Model To DTo

            var walkDto = _mapper.Map<WalkDTOcs>(deleteWalkDomainResult);

            return Ok(walkDto);


        }


    }
}
