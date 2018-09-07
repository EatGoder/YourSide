using Project.API.EntityFramework.Models;
using Project.API.EntityFramework.Models.Friends;
using Project.API.EntityFramework.Models.VerificationCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Data.DataBase.UserInfo
{
    public interface IUserInfoDAL
    {
        UserInfoDataEntity UserLogin(UserInfoDataEntity dataEntity);
        int UserRegister(UserInfoDataEntity dataEntity);

        int UserInfoUpdate(UserInfoDataEntity dataEntity);

        List<FriendDataEntity> FriendsInfo(UserInfoDataEntity dataEntity);

        int UpdateFriends(FriendDataEntity dataEntity);

        int InsertVerificationCode(VerificationCodeDataEntity dataEntity);

        VerificationCodeDataEntity CheckVerificationCode(VerificationCodeDataEntity dataEntity);
    }
}
