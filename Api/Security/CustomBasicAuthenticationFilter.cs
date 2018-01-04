using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http.Controllers;

namespace Api.Security
{
    public class CustomBasicAuthenticationFilter : BasicAuthenticationFilter
    {
        public CustomBasicAuthenticationFilter()
        { }

        public CustomBasicAuthenticationFilter(bool active) : base(active)
        { }


        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            var apiUserName = WebConfigurationManager.AppSettings["ApiUserName"];
            var apiPassword = WebConfigurationManager.AppSettings["ApiPassword"];
            //var helper = new DangNhapApiHelper();

            if (username != apiUserName || password != apiPassword)
            {
                return false;
            }


            return true;
        }
    }
}