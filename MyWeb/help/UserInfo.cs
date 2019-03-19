using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.help
{
    public class UserInfo
    {
        public Guid? Id { get; set; }= Guid.NewGuid();
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 交房时间
        /// </summary>
        public string MakeRoomTime { get; set; }
        /// <summary>
        /// 卖点
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

    }
}
