using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using Project.API.Data.DataBase.UserInfo;
using Project.API.EntityFramework.Models.VerificationCode;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.API.Business.VerificationCode
{
    [Export(typeof(IVerificationCodeBusiness))]       
    public class VerificationCodeBusiness : IVerificationCodeBusiness
    {
        private readonly IUserInfoDAL _userInfoDal;
        [ImportingConstructor]
        public VerificationCodeBusiness(IUserInfoDAL userInfoDal)
        {
            _userInfoDal = userInfoDal;
        }

        public VerificationCodeResponse VerificationCode(VerificationCodeRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.VerificationCode))
            {
                return CheckVerificationCode(request);
            }
            else
            {
                return SendVerificationCode(request);
            }
        }

        /// <summary>
        /// 校验验证码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private VerificationCodeResponse CheckVerificationCode(VerificationCodeRequest request)
        {
            VerificationCodeResponse response = new VerificationCodeResponse();
            try
            {
                VerificationCodeDataEntity dataEntity = new VerificationCodeDataEntity();
                dataEntity.UserPhone = request.UserPhone;
                dataEntity.Code = request.VerificationCode;
                VerificationCodeDataEntity result = _userInfoDal.CheckVerificationCode(dataEntity);
                if (result != null && !string.IsNullOrWhiteSpace(result.Code))
                {
                    response.Result = 1;
                    response.VerificationCode = result.Code;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private VerificationCodeResponse SendVerificationCode(VerificationCodeRequest request)
        {
            #region 文档
            //参考文档https://help.aliyun.com/document_detail/59836.html?spm=a2c4g.11186623.6.579.41ef5777QsXJ2w#h2--sendsms-1
            #endregion
            VerificationCodeResponse response = new VerificationCodeResponse();
            try
            {
                String product = "Dysmsapi";
                String domain = "dysmsapi.aliyuncs.com";
                String accessKeyId = "LTAIKC9qqmSWqFY2";
                String accessKeySecret = "wLO5tWtBYBy7Rh89tRdbWOXPFnDGvO";

                IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
                DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
                IAcsClient acsClient = new DefaultAcsClient(profile);
                SendSmsRequest sendRequest = new SendSmsRequest();

                sendRequest.PhoneNumbers = request.UserPhone;
                sendRequest.SignName = "生活圈";
                sendRequest.TemplateCode = "SMS_143714807";
                StringBuilder randNum = new StringBuilder();
                for (int i = 0; i < 6; i++)
                {
                    Random random = new Random();
                    randNum.Append(random.Next(0, 10).ToString());
                    Thread.Sleep(10);
                }
                sendRequest.TemplateParam = "{\"code\":\"" + randNum.ToString() + "\"}";

                VerificationCodeDataEntity dataEntity = new VerificationCodeDataEntity();
                dataEntity.UserPhone = request.UserPhone;
                dataEntity.Code = randNum.ToString();
                dataEntity.CreateDateTime = DateTime.Now;
                dataEntity.UpdateDateTime = DateTime.Now;
                int result = _userInfoDal.InsertVerificationCode(dataEntity);

                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(sendRequest);
                if (sendSmsResponse != null && sendSmsResponse.Code == "OK" && result == 1)
                {
                    response.Result = 1;
                    response.VerificationCode = randNum.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
