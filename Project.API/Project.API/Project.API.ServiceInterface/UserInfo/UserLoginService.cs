using Project.API.Business.UserInfo;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.ServiceInterface.UserInfo
{
    [AuthRequestFilter]
    public class UserLoginService : Service
    {
        private readonly IUserInfoBusiness _userBusiness;

        [ImportingConstructor]
        public UserLoginService(IUserInfoBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        public object Any(GetUserInfoRequest request)
        {
            GetUserInfoResponse response = new GetUserInfoResponse();
            response = _userBusiness.UserLogin(request);
            return response;
        }
    }
}
