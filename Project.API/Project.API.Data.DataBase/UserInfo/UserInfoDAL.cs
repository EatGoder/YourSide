using Project.API.EntityFramework.DbContext;
using Project.API.EntityFramework.Models;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Project.API.EntityFramework.Models.Friends;
using Project.API.EntityFramework.Models.VerificationCode;

namespace Project.API.Data.DataBase.UserInfo
{
    [Export(typeof(IUserInfoDAL))]      
    public class UserInfoDAL : IUserInfoDAL
    {
        private readonly MySqlDbContext mysqldb;

        public UserInfoDAL()
        {
            mysqldb = new MySqlDbContext();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="dataEntity"></param>
        /// <returns></returns>
        public UserInfoDataEntity UserLogin(UserInfoDataEntity dataEntity)
        {
            UserInfoDataEntity userInfo = mysqldb.UserInfo.ToList().Find(i => i.UserPhone == dataEntity.UserPhone && i.Password == dataEntity.Password);
            UserInfoDataEntity response = new UserInfoDataEntity();
            if (userInfo != null)
            {
                response = AutoMappingUtils.ConvertTo<UserInfoDataEntity>(userInfo);
            }
            return response;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="dataEntity"></param>
        /// <returns></returns>
        public int UserRegister(UserInfoDataEntity dataEntity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@" INSERT INTO  userinfo 
                            ( UserPhone ,
                             Password ,
                             ShareLocation ,
                             UserSex ,
                             UserNickName ,
                             UserHeadPic ,
                             UserLat ,
                             UserLon ,
                             LastOnline ,
                             IsOnline ,
                             UserBalance ,
                             ThirdAccount ,
                             DeviceID ,
                             ProvinceID ,
                             ProvinceName ,
                             CityID ,
                             CityName ,
                             CreateDateTime ,
                             UpdateDateTime )
                        VALUES (
                             @UserPhone ,
                             @Password ,
                             @ShareLocation ,
                             @UserSex ,
                             @UserNickName ,
                             @UserHeadPic ,
                             @UserLat ,
                             @UserLon ,
                             @LastOnline ,
                             @IsOnline ,
                             @UserBalance ,
                             @ThirdAccount ,
                             @DeviceID ,
                             @ProvinceID ,
                             @ProvinceName ,
                             @CityID ,
                             @CityName ,
                             @CreateDateTime ,
                             @UpdateDateTime 
                            )");

            MySqlParameter p_UserPhone = new MySqlParameter("@UserPhone", dataEntity.UserPhone);
            MySqlParameter p_Password = new MySqlParameter("@Password", dataEntity.Password);
            MySqlParameter p_ShareLocation = new MySqlParameter("@ShareLocation", dataEntity.ShareLocation);
            MySqlParameter p_UserSex = new MySqlParameter("@UserSex", dataEntity.UserSex);
            MySqlParameter p_UserNickName = new MySqlParameter("@UserNickName", dataEntity.UserNickName);
            MySqlParameter p_UserHeadPic = new MySqlParameter("@UserHeadPic", dataEntity.UserHeadPic);
            MySqlParameter p_UserLat = new MySqlParameter("@UserLat", dataEntity.UserLat);
            MySqlParameter p_UserLon = new MySqlParameter("@UserLon", dataEntity.UserLon);
            MySqlParameter p_LastOnline = new MySqlParameter("@LastOnline", dataEntity.LastOnline);
            MySqlParameter p_IsOnline = new MySqlParameter("@IsOnline", dataEntity.IsOnline);
            MySqlParameter p_UserBalance = new MySqlParameter("@UserBalance", dataEntity.UserBalance);
            MySqlParameter p_ThirdAccount = new MySqlParameter("@ThirdAccount", dataEntity.ThirdAccount);
            MySqlParameter p_DeviceID = new MySqlParameter("@DeviceID", dataEntity.DeviceID);
            MySqlParameter p_ProvinceID = new MySqlParameter("@ProvinceID", dataEntity.ProvinceID);
            MySqlParameter p_ProvinceName = new MySqlParameter("@ProvinceName", dataEntity.ProvinceName);
            MySqlParameter p_CityID = new MySqlParameter("@CityID", dataEntity.CityID);
            MySqlParameter p_CityName = new MySqlParameter("@CityName", dataEntity.CityName);
            MySqlParameter p_CreateDateTime = new MySqlParameter("@CreateDateTime", dataEntity.CreateDateTime);
            MySqlParameter p_UpdateDateTime = new MySqlParameter("@UpdateDateTime", dataEntity.UpdateDateTime);

            int result = mysqldb.Database.ExecuteSqlCommand(sql.ToString(),
                             p_UserPhone,
                             p_Password,
                             p_ShareLocation,
                             p_UserSex,
                             p_UserNickName,
                             p_UserHeadPic,
                             p_UserLat,
                             p_UserLon,
                             p_LastOnline,
                             p_IsOnline,
                             p_UserBalance,
                             p_ThirdAccount,
                             p_DeviceID,
                             p_ProvinceID,
                             p_ProvinceName,
                             p_CityID,
                             p_CityName,
                             p_CreateDateTime,
                             p_UpdateDateTime);
            return result;
        }

        /// <summary>
        /// 用户更新
        /// </summary>
        /// <param name="dataEntity"></param>
        /// <returns></returns>
        public int UserInfoUpdate(UserInfoDataEntity dataEntity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@" UPDATE  userinfo SET
                             Password=@Password ,
                             ShareLocation=@ShareLocation ,
                             UserSex=@UserSex,
                             UserNickName=@UserNickName,
                             UserHeadPic=@UserHeadPic,
                             UserLat=@UserLat,
                             UserLon=@UserLon,
                             LastOnline=@LastOnline,
                             IsOnline=@IsOnline,
                             UserBalance=@UserBalance,
                             ThirdAccount=@ThirdAccount,
                             DeviceID=@DeviceID,
                             ProvinceID=@ProvinceID,
                             ProvinceName=@ProvinceName,
                             CityID=@CityID,
                             CityName=@CityName,
                             UpdateDateTime=@UpdateDateTime
                        WHERE UserPhone=@UserPhone");

            MySqlParameter p_UserPhone = new MySqlParameter("@UserPhone", dataEntity.UserPhone);
            MySqlParameter p_Password = new MySqlParameter("@Password", dataEntity.Password);
            MySqlParameter p_ShareLocation = new MySqlParameter("@ShareLocation", dataEntity.ShareLocation);
            MySqlParameter p_UserSex = new MySqlParameter("@UserSex", dataEntity.UserSex);
            MySqlParameter p_UserNickName = new MySqlParameter("@UserNickName", dataEntity.UserNickName);
            MySqlParameter p_UserHeadPic = new MySqlParameter("@UserHeadPic", dataEntity.UserHeadPic);
            MySqlParameter p_UserLat = new MySqlParameter("@UserLat", dataEntity.UserLat);
            MySqlParameter p_UserLon = new MySqlParameter("@UserLon", dataEntity.UserLon);
            MySqlParameter p_LastOnline = new MySqlParameter("@LastOnline", dataEntity.LastOnline);
            MySqlParameter p_IsOnline = new MySqlParameter("@IsOnline", dataEntity.IsOnline);
            MySqlParameter p_UserBalance = new MySqlParameter("@UserBalance", dataEntity.UserBalance);
            MySqlParameter p_ThirdAccount = new MySqlParameter("@ThirdAccount", dataEntity.ThirdAccount);
            MySqlParameter p_DeviceID = new MySqlParameter("@DeviceID", dataEntity.DeviceID);
            MySqlParameter p_ProvinceID = new MySqlParameter("@ProvinceID", dataEntity.ProvinceID);
            MySqlParameter p_ProvinceName = new MySqlParameter("@ProvinceName", dataEntity.ProvinceName);
            MySqlParameter p_CityID = new MySqlParameter("@CityID", dataEntity.CityID);
            MySqlParameter p_CityName = new MySqlParameter("@CityName", dataEntity.CityName);
            MySqlParameter p_CreateDateTime = new MySqlParameter("@CreateDateTime", dataEntity.CreateDateTime);
            MySqlParameter p_UpdateDateTime = new MySqlParameter("@UpdateDateTime", dataEntity.UpdateDateTime);

            int result = mysqldb.Database.ExecuteSqlCommand(sql.ToString(),
                             p_UserPhone,
                             p_Password,
                             p_ShareLocation,
                             p_UserSex,
                             p_UserNickName,
                             p_UserHeadPic,
                             p_UserLat,
                             p_UserLon,
                             p_LastOnline,
                             p_IsOnline,
                             p_UserBalance,
                             p_ThirdAccount,
                             p_DeviceID,
                             p_ProvinceID,
                             p_ProvinceName,
                             p_CityID,
                             p_CityName,
                             p_CreateDateTime,
                             p_UpdateDateTime);
            return result;
        }


        public List<FriendDataEntity> FriendsInfo(UserInfoDataEntity dataEntity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@" SELECT friend.UserPhone,friend.FriendPhone,friend.AddRequest,friend.AddResult,friend.AddType,
                            user.UserNickName,user.UserSex,user.IsOnline,user.LastOnline,user.UserHeadPic
                            FROM myproject.friendsinfo AS friend
                            INNER JOIN myproject.userinfo AS user On user.UserPhone=friend.UserPhone
                          WHERE friend.UserPhone=@UserPhone AND user.ShareLocation=1");
            MySqlParameter p_UserPhone = new MySqlParameter("@UserPhone", dataEntity.UserPhone);
            var result = mysqldb.FinendInfo.SqlQuery(sql.ToString(), p_UserPhone);
            return result.ToList();
        }

        /// <summary>
        /// 同意、删除好友申请
        /// </summary>
        /// <param name="dataEntity"></param>
        /// <returns></returns>
        public int UpdateFriends(FriendDataEntity dataEntity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@" UPDATE friendsinfo SET
                             AddResult=@AddResult ,
                             UpdateDateTime=@UpdateDateTime
                        WHERE UserPhone=@UserPhone AND FriendPhone=@FriendPhone");

            MySqlParameter p_UserPhone = new MySqlParameter("@UserPhone", dataEntity.UserPhone);
            MySqlParameter p_FriendPhone = new MySqlParameter("@FriendPhone", dataEntity.FriendPhone);
            MySqlParameter p_AddResult = new MySqlParameter("@AddResult", dataEntity.AddResult);
            MySqlParameter p_UpdateDateTime = new MySqlParameter("@UpdateDateTime", DateTime.Now);

            int result = mysqldb.Database.ExecuteSqlCommand(sql.ToString(),
                             p_UserPhone,
                             p_FriendPhone,
                             p_AddResult,
                             p_UpdateDateTime);
            return result;
        }

        /// <summary>
        /// 保存用户验证码
        /// </summary>
        /// <param name="dataEntity"></param>
        /// <returns></returns>
        public int InsertVerificationCode(VerificationCodeDataEntity dataEntity)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@" INSERT INTO VerificationCodeInfo (UserPhone,Code,CreateDateTime,UpdateDateTime)
                            VALUES (@UserPhone,@Code,@CreateDateTime,@UpdateDateTime)");

            MySqlParameter p_UserPhone = new MySqlParameter("@UserPhone", dataEntity.UserPhone);
            MySqlParameter p_Code = new MySqlParameter("@Code", dataEntity.Code);
            MySqlParameter p_CreateDateTime = new MySqlParameter("@CreateDateTime", dataEntity.CreateDateTime);
            MySqlParameter p_UpdateDateTime = new MySqlParameter("@UpdateDateTime", dataEntity.UpdateDateTime);

            int result = mysqldb.Database.ExecuteSqlCommand(sql.ToString(),
                             p_UserPhone,
                             p_Code,
                             p_CreateDateTime,
                             p_UpdateDateTime);
            return result;
        }

        /// <summary>
        /// 校验验证码
        /// </summary>
        /// <param name="dataEntity"></param>
        /// <returns></returns>
        public VerificationCodeDataEntity CheckVerificationCode(VerificationCodeDataEntity dataEntity)
        {
            VerificationCodeDataEntity userInfo = mysqldb.VerificationCode.ToList().Find(i => i.UserPhone == dataEntity.UserPhone && i.Code == dataEntity.Code);
            VerificationCodeDataEntity response = new VerificationCodeDataEntity();
            if (userInfo != null)
            {
                response = AutoMappingUtils.ConvertTo<VerificationCodeDataEntity>(userInfo);
            }
            return response;
        }
    }
}
