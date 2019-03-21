using System;
using System.Collections.Generic;
using System.Text;

namespace service.Model
{
  public  class UserInfoDto
    {
        public Guid Id { get; set; }
        public  string UserName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string CreateTime { get; set; }
        /// <summary>
        /// 交房时间
        /// </summary>
        public string MakeRoomTime { get; set; }
        /// <summary>
        /// 楼盘
        /// </summary>
        public string SellingPoint { get; set; }
        /// <summary>
        /// 房号
        /// </summary>
         public string RoomNumber { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public string AllPrice { get; set; }
       /// <summary>
       /// 面积
       /// </summary>
        public string Areas { get; set; }
        /// <summary>
        /// 户型
        /// </summary>
        public string Apartment { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        public string  Url { get; set; }
    }
}
