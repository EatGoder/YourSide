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
    public class UserRegisterService : Service
    {
        private readonly IUserInfoBusiness _userBusiness;

        [ImportingConstructor]
        public UserRegisterService(IUserInfoBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        public object Any(UserRegisterRequest request)
        {
            UserRegisterResponse response = new UserRegisterResponse();
            response = _userBusiness.UserRegister(request);
            return response;
        }
    }
}
