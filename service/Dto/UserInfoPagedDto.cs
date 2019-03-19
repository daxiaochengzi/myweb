using service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace service.Dto
{
 public   class UserInfoPagedDto: PagerBase
    {
        public string UserName { get; set; }
        public string Apartment { get; set; }
        public string Address { get; set; }
    }
}
