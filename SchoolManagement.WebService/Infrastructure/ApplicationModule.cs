using Autofac;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Business;
using SchoolManagement.Business.Interfaces;
using SchoolManagement.Master.Data.Provider;
using SchoolManagement.Util.Tenant;
using SchoolManagement.WebService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.WebService.Infrastructure
{
    public class ApplicationModule : Autofac.Module
    {
        public ApplicationModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TenantProvider>()
                .As<ITenantProvider>()
                .InstancePerDependency();

            builder.RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>()
                .SingleInstance();

            builder.RegisterType<IdentityService>()
                .As<IIdentityService>()
                .SingleInstance();

            builder.RegisterType<AuthService>()
                .As<IAuthService>()
                .InstancePerLifetimeScope();

        }
    }
}
