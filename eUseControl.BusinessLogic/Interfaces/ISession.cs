using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ULoginResp UserLogin(ULoginData data);
        ULoginResp UserSignup(USignupData data);
        ULoginResp UserChangeData(USettingsData data);
        string GenUserCookie(ULoginData data);
        HttpCookie GenCookie(string loginCredential);
        UProfileData GetUserByCookie(string apiCookieValue);
    }
}
