using Project.API.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Business.UserInfo
{
    public interface IUserInfoBusiness
    {
        GetUserInfoResponse UserLogin(GetUserInfoRequest request);

        UserRegisterResponse UserRegister(UserRegisterRequest request);

        int UserInfoUpdate(UpdateUserInfoRequest request);

        FriendsResponse FriendsInfo(FriendsRequest request);

        int UpdateFriends(UpdateFriendsRequest request);
    }
}
