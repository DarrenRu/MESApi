using QRCode.Models.Entities;
using QRCode.Models.Helper;
using QRCode.Services;
using QRCode.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QRCode.WebAPI.Controllers
{
    [Route("account/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly JWTSettings _jwtSettings;

        public AccountController(IOptions<Settings> settings)
        {
            _accountService = new AccountService(settings.Value.JWTSettings);
            _jwtSettings = settings.Value.JWTSettings;
        }

        public IActionResult GetById([FromBody] JObject param)
        {
            var result = _accountService.GetById(int.Parse(param["id"].ToString()));
            return Ok(result);
        }

        public IActionResult Login([FromBody]JObject param)
        {
            var result = _accountService.Login(param["username"].ToString(), param["password"].ToString());
            return Ok(result);
        }

      
    }
}
