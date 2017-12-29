using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirst.IService;
using MyFirst.Data;
using MyFirst.Data.Repositories;
using MyFirst.Data.Domain;
using System.ComponentModel.Composition;
using HWB.Framework.Models;
using MyFirst.Data.Dto;

namespace MyFirstEF.Service
{
    [Export(typeof(IProductService))]
    public class ProductService : IProductService
    {
         public EFDbContext _db;
         public IRepositiory<Product> _rpsProduct;
        public ProductService(EFDbContext db, IRepositiory<Product> rpsProduct)
        {
            this._db = db;
            this._rpsProduct = rpsProduct;
        }
       
        /// <summary>
        /// 获取产品数据信息
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProductInfo()
        {
            //List<Product> result = new List<Product>();
            var query = _rpsProduct.Query();
            return query;
        }
        /// <summary>
        /// 保存产品信息
        /// </summary>
        /// <returns></returns>
        public ReturnJson SaveProductInfo(ProductModel model)
        {
            ReturnJson result = new ReturnJson();
            using (var tran =_db.Database.BeginTransaction())
            {
               
                try {
                    Product Pmodel = new Product();
                    Pmodel.ID = Guid.NewGuid().ToString();
                    Pmodel.Name = model.Name;
                    Pmodel.Price = model.Price;
                    Pmodel.Quantity = model.Quantity;
                    if (model.Node == "add")
                    {
                       _rpsProduct.Add(Pmodel);
                    }
                    else
                    {
                        Pmodel.ID = model.ID;
                        string[] propertys = {
                            //query.ID=model.ID,
                            //query.Name=model.Name,
                            //query.Price =model.Price,
                            //query.Quantity=model.Quantity
                            "Name","Price","Quantity"
                        };
                        _rpsProduct.Edit(Pmodel, propertys);
                    }
                   
                    tran.Commit();
                    result.r = "ok";
                    result.s = "操作成功！";
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    result.r = "eeror";
                    result.s = "操作失败！";
                }
                return result;
            }
        }
        /// <summary>
        /// 获取单个产品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ProductModel GetSingleProduct(ProductModel model)
        {
            ProductModel result = new ProductModel();
            if(model.Node!="add")
            {
                var query = _rpsProduct.Find(p => p.ID == model.ID);
                result.ID = model.ID;
                result.Name = query.Name;
                result.Price = query.Price;
                result.Quantity = query.Quantity;
            }
            result.Node = model.Node;
            return result;
        }
        /// <summary>
        /// 删除产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReturnJson DelProductInfo(List<string> idList)
        {
            ReturnJson result = new ReturnJson();
            try
            {
                _rpsProduct.Delete(p => idList.Contains(p.ID));
                result.r = "ok";
                result.s = "操作成功!";
            }
            catch (Exception ex)
            {
                result.r = "eeror";
                result.s = "操作失败!";
            }
            return result;
        }

        public static int GetSun(int ivalue)
        {
            int sum = 0;
            for (int i = 1; i <= ivalue; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
}
