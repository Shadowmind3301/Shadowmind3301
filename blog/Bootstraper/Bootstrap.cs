using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Blog.DataProviders;
using Blog.Services;

namespace Blog.Bootstrapper
{
    public class Bootstrapper : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PostDataProvider>().As<IPostDataProvider>().InstancePerRequest();
            builder.RegisterType<DataService>().As<IDataService>().InstancePerRequest();
            base.Load(builder);
        }
    }
}

