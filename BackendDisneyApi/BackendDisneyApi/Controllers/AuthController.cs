//using BackendDisneyApi.Models.Auth;
//using BackendDisneyApi.Services;
//using BackendDisneyApi.ViewModels;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Security.Cryptography;

//namespace BackendDisneyApi.Controllers
//{
//    [ApiController]
//    [Route(template: "api/[controller]")]
//    public class AuthenticationController : ControllerBase
//    {
//        //Registro
//        private readonly UserManager<UserLogin> _userManager;
//        private readonly SignInManager<UserLogin> _signInManager;
//        private readonly IMailService _mailService;


//        public AuthenticationController(UserManager<UserLogin> userManager, SignInManager<UserLogin> signInManager, IMailService mailService)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//            _mailService = mailService;
//        }

//        [HttpPost]
//        [Route(template: "registro")]
//        public async Task<IActionResult> Register(RegistrationRequestViewModel model) //async para poder usar await
//        {
           
//            //Revisar si existe usuario
//            var userExists = await _userManager.FindByNameAsync(model.Username);

//            //Si existe, devolver error
//            if (userExists != null)
//            {
//                return StatusCode(StatusCodes.Status400BadRequest);
//            }

//            //Si no existe, registrar al usuario
//            var user = new UserLogin
//            {
//                UserName = model.Username,
//                Email = model.Email,
//                IsActive = true
//            };
//            var result = await _userManager.CreateAsync(user, model.Password);

//            if (!result.Succeeded)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, new
//                {
//                    status = "Error",
//                    Message = $"User Creation Failed! Errors:{string.Join(", ", result.Errors.Select(x => x.Description))}"
//                });

//            }

//            await _mailService.SendMail(user);

//            return Ok(new
//            {
//                status = "Success",
//                Message = $"User created Succesfully!"


//            }); ;
//        }
//    }
//}