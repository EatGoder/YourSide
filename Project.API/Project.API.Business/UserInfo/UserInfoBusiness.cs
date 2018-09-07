using Project.API.Data.DataBase.UserInfo;
using Project.API.EntityFramework.Models;
using Project.API.EntityFramework.Models.Friends;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Business.UserInfo
{
    [Export(typeof(IUserInfoBusiness))]       
    public class UserInfoBusiness : IUserInfoBusiness
    {
        private readonly IUserInfoDAL _userInfoDal;

        [ImportingConstructor]
        public UserInfoBusiness(IUserInfoDAL userInfoDal)
        {
            _userInfoDal = userInfoDal;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetUserInfoResponse UserLogin(GetUserInfoRequest request)
        {
            GetUserInfoResponse response = new GetUserInfoResponse();
            try
            {
                UserInfoDataEntity userInfoModel = AutoMappingUtils.ConvertTo<UserInfoDataEntity>(request);
                response = AutoMappingUtils.ConvertTo<GetUserInfoResponse>(_userInfoDal.UserLogin(userInfoModel));
            }
            catch (Exception ex)
            {
                return new GetUserInfoResponse();
            }
            return response;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UserRegisterResponse UserRegister(UserRegisterRequest request)
        {
            UserRegisterResponse response = new UserRegisterResponse();
            try
            {
                UserInfoDataEntity userInfoModel = AutoMappingUtils.ConvertTo<UserInfoDataEntity>(request.UserRegister);
                int result = _userInfoDal.UserRegister(userInfoModel);
                response.Result = result;
            }
            catch (Exception ex)
            {
                return new UserRegisterResponse();
            }
            return response;
        }

        /// <summary>
        /// 用户更新
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int UserInfoUpdate(UpdateUserInfoRequest request)
        {
            try
            {
                UserInfoDataEntity userInfoModel = AutoMappingUtils.ConvertTo<UserInfoDataEntity>(request.UpdateUserInfo);
                if (userInfoModel != null)
                {
                    return _userInfoDal.UserInfoUpdate(userInfoModel);
                }
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        /// <summary>
        /// 好友列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public FriendsResponse FriendsInfo(FriendsRequest request)
        {
            FriendsResponse response = new FriendsResponse();
            try
            {
                UserInfoDataEntity userInfoModel = AutoMappingUtils.ConvertTo<UserInfoDataEntity>(request);
                List<FriendDataEntity> friendRS = AutoMappingUtils.ConvertTo<List<FriendDataEntity>>(_userInfoDal.FriendsInfo(userInfoModel));
                response.FriendList = new List<FriendsEntity>();
                if (friendRS != null && friendRS.Count > 0)
                {
                    foreach (var friendData in friendRS)
                    {
                        FriendsEntity friendEntity = new FriendsEntity();
                        friendEntity.AddRequest = friendData.AddRequest;
                        friendEntity.AddResult = friendData.AddResult.GetValueOrDefault();
                        friendEntity.AddType = friendData.AddType.GetValueOrDefault();
                        friendEntity.UserInfo = new UserInfoEntity();
                        friendEntity.UserInfo.UserPhone = friendData.UserPhone;
                        friendEntity.UserInfo.UserHeadPic = friendData.UserHeadPic;
                        friendEntity.UserInfo.UserNickName = friendData.UserNickName;
                        friendEntity.UserInfo.UserSex = friendData.UserSex.GetValueOrDefault();
                        friendEntity.UserInfo.IsOnline = friendData.IsOnline.GetValueOrDefault();
                        friendEntity.UserInfo.LastOnline = friendData.LastOnline.GetValueOrDefault();
                        response.FriendList.Add(friendEntity);
                    }
                }
            }
            catch (Exception ex)
            {
                return new FriendsResponse();
            }
            return response;
        }

        /// <summary>
        /// 同意、删除好友申请
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int UpdateFriends(UpdateFriendsRequest request)
        {
            try
            {
                FriendDataEntity friendModel = AutoMappingUtils.ConvertTo<FriendDataEntity>(request);
                if (friendModel != null)
                {
                    return _userInfoDal.UpdateFriends(friendModel);
                }
            }
            catch (Exception ex)
            { 
            
            }
            return 0;
        }
    }
}
