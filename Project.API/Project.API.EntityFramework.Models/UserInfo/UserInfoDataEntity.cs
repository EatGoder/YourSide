using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.EntityFramework.Models
{
    [Table("userinfo")]
    public class UserInfoDataEntity
    {
        /// <summary>
        /// 用户手机
        /// </summary>
        [Key]
        public string UserPhone { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 共享位置1:共享0:不共享
        /// </summary>
        public Nullable<int> ShareLocation { get; set; }
        /// <summary>
        /// 性别0:男1:女
        /// </summary>
        public Nullable<int> UserSex { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNickName { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public byte[] UserHeadPic { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public Nullable<double> UserLat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public Nullable<double> UserLon { get; set; }
        /// <summary>
        /// 最后在线时间
        /// </summary>
        public Nullable<System.DateTime> LastOnline { get; set; }
        /// <summary>
        /// 是否在线1:是
        /// </summary>
        public Nullable<int> IsOnline { get; set; }
        /// <summary>
        /// 用户余额
        /// </summary>
        public Nullable<decimal> UserBalance { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<System.DateTime> CreateDateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public Nullable<System.DateTime> UpdateDateTime { get; set; }
        /// <summary>
        /// 第三方账户
        /// </summary>
        public string ThirdAccount { get; set; }
        /// <summary>
        /// 设备号
        /// </summary>
        public string DeviceID { get; set; }
        /// <summary>
        /// 省ID
        /// </summary>
        public Nullable<int> ProvinceID { get; set; }
        /// <summary>
        /// 省名称
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 城市ID
        /// </summary>
        public Nullable<int> CityID { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
    }
}
