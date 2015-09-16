using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YcJVectorMap.Model.Map
{
    /// <summary>
    /// 地图分布数据
    /// </summary>
    public class data
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 数值
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 跳转链接
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 显示透明度
        /// </summary>
        public string opacity { get; set; }
    }
}
