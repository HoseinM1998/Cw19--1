using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Enum
{
    public enum MembershipTypeEnum
    {
        [Display(Name = "طلایی")]
        Gold = 1,

        [Display(Name = "نقره‌ای")]
        Silver = 2,

        [Display(Name = "برنزی")]
        Bronze = 3
    }

}
