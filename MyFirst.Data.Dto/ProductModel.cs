using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirst.Data.Dto
{
    /// <summary>
    /// 产品
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        [DisplayName("产品名称")]
        public string Name { get; set; }
        /// <summary>
        /// 产品价格
        /// </summary>
        [DisplayName("产品价格")]
        public decimal Price { get; set; }
        /// <summary>
        /// 产品数量
        /// </summary>
        [DisplayName("产品数量")]
        public int Quantity { get; set; }

        /// <summary>
        /// 区别添加或编辑(add、edit)
        /// </summary>
        public string Node { get; set; }
    }
}
