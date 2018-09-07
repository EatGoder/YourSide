using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.EntityFramework.Models.Friends
{
    [Table("friendsinfo")]
    public class FriendDataEntity
    {
        /// <summary>
        /// 用户手机
        /// </summary>
        [Key]
        public string UserPhone { get; set; }
        /// <summary>
        /// 好友手机
        /// </summary>
        public string FriendPhone { get; set; }
        /// <summary>
        /// 好友请求内容
        /// </summary>
        public string AddRequest { get; set; }
        /// <summary>
        /// 添加类型0:待通过1:已通过
        /// </summary>
        public Nullable<int> AddResult { get; set; }
        /// <summary>
        /// 添加方式0:普通1:赠送
        /// </summary>
        public Nullable<int> AddType { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNickName { get; set; }
        /// <summary>
        /// 性别0:男1:女
        /// </summary>
        public Nullable<int> UserSex { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public byte[] UserHeadPic { get; set; }
        /// <summary>
        /// 最后在线时间
        /// </summary>
        public Nullable<System.DateTime> LastOnline { get; set; }
        /// <summary>
        /// 是否在线1:是
        /// </summary>
        public Nullable<int> IsOnline { get; set; }
    }
}
