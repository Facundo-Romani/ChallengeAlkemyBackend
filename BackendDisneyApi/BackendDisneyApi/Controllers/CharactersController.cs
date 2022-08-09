using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendDisneyApi.DataAccess;
using BackendDisneyApi.Models;
using Microsoft.AspNetCore.Authorization;
using BackendDisneyApi.Services;
using BackendDisneyApi.ViewModels;

namespace BackendDisneyApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _Service;

        public CharactersController(ICharacterService service)
        {
            _Service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetList")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _Service.GetAll());
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetDetails")]
        public async Task<IActionResult> GetDetails(int id)
        {
            if (!_Service.Exists(id))
            {
                return BadRequest("Character not found");
            }

            try
            {
                var charVM = await _Service.GetDetails(id);

                return Ok(charVM);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateChar model)
        {
            if (_Service.Exists(model.Id))
            {
                return BadRequest("Character already exists");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _Service.CreateChar(model);

                    return Ok("Character created with success");
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return BadRequest("Invalid input");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_Service.Exists(id))
            {
                return BadRequest("Character not found");
            }

            try
            {
                await _Service.DeleteAsync(id);

                return Ok("Character deleted with success");
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Edit([FromQuery]
            UpdateChar model)
        {
            if (!_Service.Exists(model.Id))
            {
                return BadRequest("Character not found");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _Service.UpdateChar(model);

                    return Ok("Character updated with success");
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return BadRequest("Invalid input");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery]
            string name)
        {
            if (!_Service.Exists(name))
            {
                return BadRequest("Character not found");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    return Ok(_Service.GetByName(name));
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return BadRequest("Invalid input");
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Filter")]
        public async Task<IActionResult> Filter(int age, float weight, int movieId)
        {
            try
            {
                return Ok(_Service.CharFilter(age, weight, movieId));
            }

            catch (Exception)
            {
                throw;
            }
        }

    }
}