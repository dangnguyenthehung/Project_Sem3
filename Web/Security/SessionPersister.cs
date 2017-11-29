using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpers_Constants.Constants;
using Model.Models;

namespace Web.Security
{
    public class SessionPersister
    {
        public static Account LoginAccount
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return null;
                }

                var session = HttpContext.Current.Session[SessionConstants.LoginAccount] as Account;
                return session;
            }
            set
            {
                HttpContext.Current.Session[SessionConstants.LoginAccount] = value;
            }
        }
    }
}