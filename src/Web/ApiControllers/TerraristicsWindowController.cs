using System;
using System.Collections.Generic;
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

        [HttpGet]
        public async Task<IActionResult> Get([FromBody] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id okna jest nie poprawne");
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            TerraristicWindow terraristicsWindow = await _terraristicWindowRepository.GetAsync(int.Parse(id), userId);
            if (terraristicsWindow == null)
            {
                return NotFound("Nie masz dostępu do tego okna.");
            }      

            TerraristicsWindowApiModel terraristicsWindowResponseApiModel = Mapper.Map<TerraristicsWindowApiModel>(terraristicsWindow);
            return Ok(new JsonResult(terraristicsWindowResponseApiModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<TerraristicWindow> terraristicWindows = await _terraristicWindowRepository.GetAsync(userId);
            List<TerraristicsWindowApiModel> terraristicsWindowResponse = Mapper.Map<List<TerraristicsWindowApiModel>>(terraristicWindows);

            return Ok(new JsonResult(terraristicsWindowResponse));
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTerraristicsWindowApiModel createTerraristicsWindowApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Formularz został niepoprawnie wypełniony. Spróbuj ponownie");
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newTerraristicsWindow = new TerraristicWindow
            {
                Name = createTerraristicsWindowApiModel.Name,
                Description = createTerraristicsWindowApiModel.Description,
                UserId = userId,
                ApiKey = Guid.NewGuid(),
                CreationDate = DateTime.Now.Date,
                ModificationDate = DateTime.Now.Date,
                IsPublic = createTerraristicsWindowApiModel.IsPublic
            };

            int result = await _terraristicWindowRepository.AddAsync(newTerraristicsWindow);
            if (result > 0)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateTerraristicsWindowApiModel updateTerraristicsWindowApiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Formularz został niepoprawnie wypełniony. Spróbuj ponownie");
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var terraristicWindow = new TerraristicWindow
            {
                Id = updateTerraristicsWindowApiModel.Id,
                Name = updateTerraristicsWindowApiModel.Name,
                Description = updateTerraristicsWindowApiModel.Description,
                IsPublic = updateTerraristicsWindowApiModel.IsPublic
            };

            int result = await _terraristicWindowRepository.Update(terraristicWindow, userId);
            if (result > 0)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            TerraristicWindow terraristicWindow = await _terraristicWindowRepository.GetAsync(id, userId);

            try
            {
                await _terraristicWindowRepository.DeleteAsync(terraristicWindow);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}