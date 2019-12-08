using System;
using System.Collections.Generic;
using System.Text;
using QRCode.Models.Helper;
using QRCode.Services;
using QRCode.Services.Interface;
using QRCode.ViewModels;
using Jose;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QRCode.WebAPI
{
    public class TokenFilter : IActionFilter
    {
        private readonly JWTSettings _jwtSettings;
        private readonly string[] _isAnonymous = {
            "/account/login",
            "/member/login"
            //"/sign/accountlogin",
            //"/sign/memberlogin"
        };
        public TokenFilter(JWTSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (RequireTokenCheck(context))  //token需求確認
            {
                if (!UserTokenCheck(context)) //token確認
                {
                    context.HttpContext.Response.StatusCode = 401;
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    data.Add("description", "401 UnauthorizedConfiguration 笑你不能用");
                    context.Result = new JsonResult(data);
                }
            }
        }

        private bool RequireTokenCheck(ActionExecutingContext context)
        {
            string path = context.HttpContext.Request.Path;
            Console.WriteLine(path);
            int position = Array.IndexOf(_isAnonymous, path);
            //問卷填寫不需要驗證 token
            if (path.Contains("GetContentByTemplateId") || path.Contains("GetTemplateByCode") || path.Contains("CheckWritable") || path.Contains("UpdateSurveyResultContents") || path.Contains("GetSurveyContent"))
            {
                return false;
            }
            return position == -1;
        }

        private bool UserTokenCheck(ActionExecutingContext context)
        {
            string token = context.HttpContext.Request.Headers["Authorization"];
            if (token == null)
            {
                Console.WriteLine("token=null");
                return false;
            }
            else
            {
                var accountService = new AccountService(_jwtSettings);
                Console.WriteLine("token:" + token);
                Dictionary<string, string> payload = JWT.Decode<Dictionary<string, string>>(token, Encoding.UTF8.GetBytes(_jwtSettings.Secret), JwsAlgorithm.HS256);
                int id = int.Parse(payload["Id"]);
                string type = payload["Type"];
                var user = accountService.GetById(id);
                return user != null && user.Token == token;
               
            }
        }
    }
}
