using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirst.Data.Domain
{
    public class Product
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 产品价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 产品数量
        /// </summary>
        public int Quantity { get; set; }
    }
}
