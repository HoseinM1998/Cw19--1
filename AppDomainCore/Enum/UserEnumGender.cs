using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Enum
{
    public enum UserEnumGender
    {
        [Display(Name = "مرد")]
        Man = 1,
        [Display(Name = "زن")]
        Female = 2
    }
}
