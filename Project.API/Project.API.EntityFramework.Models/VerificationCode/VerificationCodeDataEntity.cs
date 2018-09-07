using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.API.EntityFramework.Models.VerificationCode
{
    [Table("VerificationCodeInfo")]
    public class VerificationCodeDataEntity
    {
        [Key]
        public string UserPhone { get; set; }
        public string Code { get; set; }
        public Nullable<System.DateTime> CreateDateTime { get; set; }
        public Nullable<System.DateTime> UpdateDateTime { get; set; }
    }
}
