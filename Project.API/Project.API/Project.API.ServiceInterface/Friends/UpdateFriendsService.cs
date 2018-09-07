using Project.API.Business.UserInfo;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.ServiceInterface.Friends
{
    [AuthRequestFilter]
    public class UpdateFriendsService: Service
    {
        private readonly IUserInfoBusiness _userBusiness;

        [ImportingConstructor]
        public UpdateFriendsService(IUserInfoBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        public object Any(UpdateFriendsRequest request)
        {
            return _userBusiness.UpdateFriends(request);
        }
    }
}
