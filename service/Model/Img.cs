using System;
using System.Collections.Generic;
using System.Text;

namespace service.Model
{
    public class Img
    {
        public Guid Id { get; set; }
        public Guid UserInfoId { get; set; }
        public  int Type { get; set; }
        public  string Url { get; set; }
        public  DateTime CreateTime { get; set; }
        public string Remark { get; set; }
    }
}
