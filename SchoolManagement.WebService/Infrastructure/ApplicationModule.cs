using Autofac;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Business;
using SchoolManagement.Business.Interfaces;
using SchoolManagement.Business.Interfaces.MasterData;
using SchoolManagement.Business.Master;
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

            // Master Services

            builder.RegisterType<AcademicLevelService>()
               .As<IAcademicLevelService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<AcademicYearService>()
              .As<IAcademicYearService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<ClassNameService>()
              .As<IClassNameService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<ClassService>()
              .As<IClassService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<ClassService>()
              .As<IClassService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<ClassSubjectTeacher>()
              .As<IClassSubjectTeacher>()
              .InstancePerLifetimeScope();

            builder.RegisterType<HeadOfDepartmentService>()
              .As<IHeadOfDepartmentService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<StudentClassService>()
              .As<IStudentClassService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<StudentClassSubjectService>()
              .As<IStudentClassSubjectService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<StudentService>()
              .As<IStudentService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<SubjectAcademicLevelService>()
              .As<ISubjectAcademicLevelService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<SubjectService>()
              .As<ISubjectService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<SubjectStreamService>()
              .As<ISubjectStreamService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<SubjectTeacherService>()
              .As<ISubjectTeacherService>()
              .InstancePerLifetimeScope();


        }
    }

   
}
