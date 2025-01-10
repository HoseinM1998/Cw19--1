using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Enum;

namespace AppDomainCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime BirthDay { get; set; }
        public string NationalCode { get; set; }
        public string Phone { get; set; }
        public UserEnumGender Gender { get; set; }
        public MembershipTypeEnum MembershipType { get; set; }

    }
}
