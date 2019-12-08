using QRCode.Models.Entities;
using QRCode.Models.Helper;
using QRCode.Services;
using QRCode.Services.Interface;
using QRCode.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;

namespace QRCode.WebAPI.Controllers
{
    [Route("sm/[action]")]
    [ApiController]
    public class StudentManageCT : ControllerBase
    {
        private readonly IStudentManageS _studentManageService;
        private readonly JWTSettings _jwtSettings;

        public StudentManageCT(IOptions<Settings> settings)
        {
            _studentManageService = new StudentManageS(settings.Value.JWTSettings);
            _jwtSettings = settings.Value.JWTSettings;
        }

        [HttpPost]
        public IActionResult GetAll([FromBody]JObject param)
        {

            var iStart = int.Parse(param["start"].ToString());
            var iLength = int.Parse(param["length"].ToString());

            var result = _studentManageService.GetAll(iStart, iLength);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult TeacherGetAll([FromBody]JObject param)
        {
            var Id = int.Parse(param["Id"].ToString());

            var iStart = int.Parse(param["start"].ToString());
            var iLength = int.Parse(param["length"].ToString());

            var result = _studentManageService.TeacherGetAll(iStart, iLength, Id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult GetAllStudent([FromBody]JObject param)
        {
            var AccountId = int.Parse(param["AccountId"].ToString());

            var result = _studentManageService.GetAllStudent(AccountId);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult GetStudentData([FromBody]JObject param)
        {
            try
            {
                var Id = int.Parse(param["Id"].ToString());
                var result = _studentManageService.GetStudentData(Id);
                return Ok(result);
            }
            catch
            {
                var result = "NOStudentId";
                return Ok(result);
            }
        }
        [HttpPost]
        public IActionResult Create([FromBody]Student param)
        {

            _studentManageService.Create(param);
            return Ok(param);
        }


        [HttpPost]
        public IActionResult Delete([FromBody]JObject param)
        {

            _studentManageService.Delete(int.Parse(param["id"].ToString()));
            return Ok("success");
        }

        [HttpPost]
        public IActionResult GetStudentDetail([FromBody]JObject param)
        {

            var Id = int.Parse(param["Id"].ToString());
            var result = _studentManageService.GetStudentDetail(Id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult GetById([FromBody]JObject param)
        {
            var result = _studentManageService.GetById(int.Parse(param["id"].ToString()));
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Update([FromBody]Student param)
        {
            _studentManageService.Update(param);
            return Ok("success");
        }
        [HttpPost]
        public IActionResult UpdateStudent([FromBody]Student param)
        {
            _studentManageService.UpdateStudent(param);
            return Ok("success");
        }
        [HttpPost]
        public IActionResult TurnGoOutWeekends([FromBody]JObject param)
        {

            var result = _studentManageService.TurnGoOutWeekends(int.Parse(param["Id"].ToString()));
            return Ok(result);
        }
        [HttpPost]
        public IActionResult TurnOvernightWeekends([FromBody]JObject param)
        {

            var result = _studentManageService.TurnOvernightWeekends(int.Parse(param["Id"].ToString()));
            return Ok(result);
        }
        [HttpPost]
        public IActionResult TurnGoOutWeekdays([FromBody]JObject param)
        {
            var result = _studentManageService.TurnGoOutWeekdays(int.Parse(param["Id"].ToString()));
            return Ok(result);
        }
    }
}