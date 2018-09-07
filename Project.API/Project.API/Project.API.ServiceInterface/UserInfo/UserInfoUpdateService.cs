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
    public class UserInfoUpdateService : Service
    {
        private readonly IUserInfoBusiness _userBusiness;

        [ImportingConstructor]
        public UserInfoUpdateService(IUserInfoBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        public object Any(UpdateUserInfoRequest request)
        {
            return _userBusiness.UserInfoUpdate(request);
        }
    }
}
