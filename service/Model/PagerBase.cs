using System;
using System.Collections.Generic;
using System.Text;

namespace service.Model
{
  public  class PagerBase
    {/// <summary>
    /// 页码
    /// </summary>
        public int offset { get; set; } = 1;
        /// <summary>
        /// 每页数据多少
        /// </summary>
        public int limit { get; set; } = 5;
        public string Keywords { get; set; } = "";
    }
}
