using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AppCore.Entities;
using AppCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.ApiModels.TerraristicsWindows;

namespace Web.ApiControllers
{
    public class TerraristicsWindowController : BaseApiController
    {
        private readonly ITerraristicWindowRepository _terraristicWindowRepository;

        public TerraristicsWindowController(IMapper mapper, ITerraristicWindowRepository terraristicWindowRepository) :
            base(mapper)
        {
            _terraristicWindowRepository = terraristicWindowRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TerraristicsWindowApiModel terraristicsWindowApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Formularz został niepoprawnie wypełniony. Spróbuj ponownie");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newTerraristicsWindow = new TerraristicWindow
            {
                Name = terraristicsWindowApiModel.Name,
                Description = terraristicsWindowApiModel.Description,
                UserId = userId,
                ApiKey = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now
            };

            var result = await _terraristicWindowRepository.AddAsync(newTerraristicsWindow);
            if (result > 0)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}