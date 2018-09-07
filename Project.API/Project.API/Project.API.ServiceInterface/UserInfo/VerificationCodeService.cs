using Project.API.Business.UserInfo;
using Project.API.Business.VerificationCode;
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
    public class VerificationCodeService : Service
    {
        private readonly IVerificationCodeBusiness _verificationCodeBusiness;

        [ImportingConstructor]
        public VerificationCodeService(IVerificationCodeBusiness business)
        {
            _verificationCodeBusiness = business;
        }
        public object Any(VerificationCodeRequest request)
        {
            return _verificationCodeBusiness.VerificationCode(request);
        }
    }
}
