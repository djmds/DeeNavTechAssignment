using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NavTech.Configuration.API.Models;
using NavTech.Configuration.Models.ResponseModels;
using NavTech.Configuration.Service.IServiceContracts;
using System;
using System.Threading.Tasks;

namespace NavTech.Configuration.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }
         
        [HttpGet("{entityType}")]
        public async Task<IActionResult> GetConfiguration([FromRoute]ConfigurationInputModel configurationInputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            try 
            {
                var result = await _configurationService.GetConfiguration(configurationInputModel.EntityType);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async  Task<IActionResult> CreateConfiguration([FromBody]EntityModel entityModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            try
            {
                await _configurationService.CreateConfiguration(entityModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}