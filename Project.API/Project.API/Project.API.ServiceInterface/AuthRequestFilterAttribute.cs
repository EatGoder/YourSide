using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.API.ServiceInterface
{
    public class AuthRequestFilterAttribute : RequestFilterAttribute
    {
        public override void Execute(ServiceStack.Web.IRequest req, ServiceStack.Web.IResponse res, object requestDto)
        {
            if (requestDto != null)
            {
                var type = requestDto.GetType();
                var head = type.GetProperty("Head");//属性
                //var head = type.GetField("Head");//字段
                if (head != null)
                {
                    var requestHead = (RequestHead)head.GetValue(requestDto);
                    string queryString = requestHead.QueryString;
                    requestHead.QueryString = "";
                    string md5 = GetMd5(ServiceStack.Text.JsonSerializer.SerializeToString(requestDto));
                    if (string.Compare(md5, queryString) != 0)
                    {
                        throw new Exception("参数错误");
                    }
                }
            }
        }

        public static string GetMd5(string str)
        {
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            string md5Str = BitConverter.ToString(md5Provider.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str)));
            return md5Str.ToUpper();
        }
    }
}
