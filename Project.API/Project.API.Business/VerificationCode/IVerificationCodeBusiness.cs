using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.Business.VerificationCode
{
    public interface IVerificationCodeBusiness
    {
        VerificationCodeResponse VerificationCode(VerificationCodeRequest request);
    }
}
