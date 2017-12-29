using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirst.Data.Domain
{
    public class Sys_Menu
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string M_Name { get; set; }

        /// <summary>
        /// 父节点编号
        /// </summary>
        public string M_ParentCode { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public string M_url { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreatTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public string UpdateTime { get; set; }
    }
}
