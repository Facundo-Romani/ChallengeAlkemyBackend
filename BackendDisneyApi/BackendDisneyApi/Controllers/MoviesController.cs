using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BackendDisneyApi.Services;
using BackendDisneyApi.ViewModels;

namespace BackendDisneyApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _Service;

        public MoviesController(IMovieService service)
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
                return BadRequest("Movie not found");
            }

            try
            {
                var model = await _Service.GetDetails(id);

                return Ok(model);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateMovie model)
        {
            if (_Service.Exists(model.Id))
            {
                return BadRequest("Movie already exists");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _Service.CreateMovie(model);

                    return Ok("Movie created with success");
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
                return BadRequest("Movie not found");
            }

            try
            {
                await _Service.DeleteAsync(id);

                return Ok("Movie deleted with success");
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Edit([FromQuery]
            UpdateMovie model)
        {
            if (!_Service.Exists(model.Id))
            {
                return BadRequest("Character not found");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _Service.UpdateMovie(model);

                    return Ok("Movie updated with success");
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
                return BadRequest("Movie not found");
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
        public async Task<IActionResult> Filter(string genre)
        {
            try
            {
                return Ok(_Service.MovieFilter(genre));
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
