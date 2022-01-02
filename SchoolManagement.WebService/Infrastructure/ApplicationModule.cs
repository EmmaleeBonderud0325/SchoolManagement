using Autofac;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Business;
using SchoolManagement.Business.Interfaces;
using SchoolManagement.Business.Interfaces.AccountData;
using SchoolManagement.Business.Interfaces.LessonData;
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

            builder.RegisterType<CurrentUserService>()
               .As<ICurrentUserService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<AuthService>()
                .As<IAuthService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserService>()
               .As<IUserService>()
               .InstancePerLifetimeScope();

            //Drop Down Service
            builder.RegisterType<DropDownService>()
              .As<IDropDownService>()
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

            builder.RegisterType<ClassTeacherService>()
              .As<IClassTeacherService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<ClassSubjectTeacherService>()
              .As<IClassSubjectTeacherService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<HeadOfDepartmentService>()
              .As<IHeadOfDepartmentService>()
              .InstancePerLifetimeScope();

            builder.RegisterType<StudentService>()
              .As<IStudentService>()
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

            ////Lesson Services

            builder.RegisterType<EssayQuestionAnswerService>()
             .As<IEssayQuestionAnswerService>()
             .InstancePerLifetimeScope();

            builder.RegisterType<EssayStudentAnswerService>()
            .As<IEssayStudentAnswerService>()
             .InstancePerLifetimeScope();

            builder.RegisterType<LessonAssignmentService>()
             .As<ILessonAssignmentService>()
             .InstancePerLifetimeScope();

            builder.RegisterType<LessonAssignmentSubmissionService>()
             .As<ILessonAssignmentSubmissionService>()
             .InstancePerLifetimeScope();

            builder.RegisterType<LessonDesignService>()
            .As<ILessonDesignService>()
            .InstancePerLifetimeScope();

            builder.RegisterType<MCQQuestionAnswerService>()
            .As<IMCQQuestionAnswerService>()
            .InstancePerLifetimeScope();

            builder.RegisterType<MCQQuestionStudentAnswerService>()
             .As<IMCQQuestionStudentAnswerService>()
             .InstancePerLifetimeScope();

            builder.RegisterType<QuestionService>()
             .As<IQuestionService>()
             .InstancePerLifetimeScope();

            builder.RegisterType<StudentMCQQuestionService>()
             .As<IStudentMCQQuestionService>()
             .InstancePerLifetimeScope();

            builder.RegisterType<ExcelMasterDataService>()
            .As<IExcelMasterDataService>()
            .InstancePerLifetimeScope();

            builder.RegisterType<ReportService>()
           .As<IReportService>()
           .InstancePerLifetimeScope();

            builder.RegisterType<AzureBlobService>()
              .As<IAzureBlobService>()
              .InstancePerLifetimeScope();





    }
    }

   
}
