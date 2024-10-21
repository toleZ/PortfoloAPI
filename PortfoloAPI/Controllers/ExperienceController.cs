using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Data.Repositories;
using PortfoloAPI.Data.Entitites;
using PortfoloAPI.Models;

namespace PortfoloAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly ExperienceRepository _experienceRepository;

        public ExperienceController(ExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] bool includeDeleted = false)
        {
            if (includeDeleted) return Ok(_experienceRepository.GetAllExperiences());
            else return Ok(_experienceRepository.Get());
        }

        [HttpGet("{titleForSearch}")]
        public IActionResult Get(string titleForSearch)
        {
            return Ok(_experienceRepository.GetExperienceByTitle(titleForSearch));
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddExperience([FromBody]ExperienceForCreationRequest requestDto)
        {
            Experience experience = new Experience()
            {
                Title = requestDto.Title,
                Description = requestDto.Description,
                ImagePath = requestDto.ImagePath,
                Summary = "In progress"
            };

            return Ok(_experienceRepository.AddExperience(experience));
        }

        //[HttpPut("{idExperience}")]
        //public IActionResult Update([FromRoute]int idExperience, [FromBody]ExperienceForUpdateRequest requestDto)
        //{
        //    int indexExperienceToUpdate = _experienceRepository.Experiences.FindIndex(e => e.Id == idExperience);

        //    if (indexExperienceToUpdate != -1)
        //    {
        //        Experience newExperience = new Experience()
        //        {
        //            Id = indexExperienceToUpdate,
        //            Title = requestDto.Title,
        //            Description = requestDto.Description,
        //            ImagePath = requestDto.ImagePath,
        //            Summary = _experienceRepository.Experiences[indexExperienceToUpdate].Summary
        //        };

        //        _experienceRepository.Experiences[indexExperienceToUpdate] = newExperience;
        //        return NoContent();
        //    }
        //    else return NotFound();
        //}

        [HttpDelete("{idExperience}")]
        public IActionResult Delete([FromRoute] int idExperience)
        {
            Experience? deletedExperience = _experienceRepository.DeleteExperience(idExperience);

            if (deletedExperience is not null) return Ok(deletedExperience);
            else return NotFound("Does´t found experience with ID: " + idExperience);
        }
    } 
}
