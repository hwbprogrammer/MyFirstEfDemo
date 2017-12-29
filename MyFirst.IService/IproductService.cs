using MyFirst.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWB.Framework.Models;
using MyFirst.Data.Dto;

namespace MyFirst.IService
{
    public interface IProductService:IDependency
    {
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <returns></returns>
        List<Product> GetProductInfo();
        /// <summary>
        /// 添加产品信息
        /// </summary>
        /// <returns></returns>
        ReturnJson SaveProductInfo(ProductModel model);
        /// <summary>
        /// 获取单个产品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ProductModel GetSingleProduct(ProductModel model);
        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ReturnJson DelProductInfo(List<string> idList);
    }
}
