using ITRI.Models.Entities;
using ITRI.Models.Helper;
using ITRI.Services;
using ITRI.Services.Interface;
using ITRI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace QRCode.WebAPI.Controllers
{
    [Route("am/[action]")]
    [ApiController]
    public class AccountManageCT : ControllerBase
    {
        private readonly IAccountManageS _accountManageService;
        private readonly JWTSettings _jwtSettings;

        public AccountManageCT(IOptions<Settings> settings)
        {
            _accountManageService = new AccountManageS(settings.Value.JWTSettings);
            _jwtSettings = settings.Value.JWTSettings;
        }

        [HttpPost]
        public IActionResult GetAll([FromBody]JObject param)
        {
            var Start = int.Parse(param["start"].ToString());
            var Length = int.Parse(param["length"].ToString());

            var result = _accountManageService.GetAll(Start, Length);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult GetById([FromBody]JObject param)
        {
            var Id = int.Parse(param["Id"].ToString());

            var result = _accountManageService.GetById(Id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Update([FromBody]Account param)
        {
            _accountManageService.Update(param);
            return Ok("success");

        }



        [HttpPost]
        public IActionResult Create([FromBody]Account param)
        {

            _accountManageService.Create(param);
            return Ok(param);
        }


        [HttpPost]
        public IActionResult Delete([FromBody]JObject param)
        {

            _accountManageService.Delete(int.Parse(param["id"].ToString()));
            return Ok("success");
        }


        [HttpPost]
        public IActionResult TurnStatus([FromBody]JObject param)
        {

            _accountManageService.TurnStatus(int.Parse(param["id"].ToString()));
            return Ok("success");
        }
        [HttpPost]
        public IActionResult ChangePassword([FromBody]JObject param)
        {
            var userName = param["userName"].ToString();
            var nickName = param["nickName"].ToString();
            var password = param["password"].ToString();

            var id = int.Parse(param["id"].ToString());

            _accountManageService.ChangePassword(id, password, userName, nickName);
            return Ok("success");
        }
    }
}