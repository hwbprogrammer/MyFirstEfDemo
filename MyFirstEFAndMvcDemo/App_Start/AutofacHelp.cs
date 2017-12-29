using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using MyFirstEF.Service;
using MyFirst.IService;
using MyFirstEFAndMvcDemo.Controllers;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;
using MyFirst.Data.Repositories;
using MyFirst.Data.Domain;
using MyFirst.Data;
using MyFirst.Utilities;

namespace MyFirstEFAndMvcDemo.App_Start
{
    public class AutofacHelp
    {
        public static void initEntrance()
        {
            //创建autofac管理注册类的容器实例
            var builder = new ContainerBuilder();
            builder.RegisterType<EFDbContext>();
            builder.RegisterType<Product>();
            builder.RegisterGeneric(typeof(BaseRepostitory<>)).As(typeof(IRepositiory<>));
            builder.RegisterType<ProductService>().As<IProductService>();
            Type baseType = typeof(IDependency);
            //加载程序集
            var Repository = Assembly.Load(ConfigHelper.GetAppSetting("RepositoryReg"));
            var Service = Assembly.Load(ConfigHelper.GetAppSetting("ServiceReg"));
            var IService = Assembly.Load(ConfigHelper.GetAppSetting("IServiceReg"));
            var DataDomain = Assembly.Load(ConfigHelper.GetAppSetting("DomainReg"));
            //
            builder.RegisterAssemblyTypes(Repository)
                 .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
    .AsImplementedInterfaces().InstancePerHttpRequest();//InstancePerLifetimeScope 保证对象生命周期基于请求;
            builder.RegisterAssemblyTypes(Service)
                 .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
    .AsImplementedInterfaces().InstancePerHttpRequest();
            //注册类型，并指定一个类型的扫描组件注册为提供它的接口实现。
            //builder.RegisterAssemblyTypes(DataDto).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(IService,Service)
            //    .Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(Repository).AsImplementedInterfaces();
            //builder的RegisterType方法注册类型。
            //builder.RegisterType<BaseRepostitory<EFDbContext,Product>>().As<IRepositiory<Product>>();
            //builder.RegisterGeneric(typeof(BaseRepostitory<,>)).As(typeof(IRepositiory<>)).InstancePerDependency();
            //container.Resolve<IRepositiory<Product>>();
            //builder.RegisterType<ProductService>().As<IProductService>();
            //使用Autofac提供的RegisterControllers扩展方法来对程序集中所有的Controller一次性的完成注册
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //下面就是使用MVC的扩展 更改了MVC中的注入方式.
            //container.Resolve<IRepositiory<Product>>();
            //builder.Register(c=>new );
            //var aa= container.ResolveOptional<IRepositiory<Product>>();
            //生成具体的实例
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

          
        }
    }
}