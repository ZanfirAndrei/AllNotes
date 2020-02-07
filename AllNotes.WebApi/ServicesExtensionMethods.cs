using AllNotes.Domain.EF.AllNotesContext;
using AllNotes.Domain.EF.Wrapper;
using AllNotes.Domain.Models;
using AllNotes.Services.IServices;
using AllNotes.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllNotes.WebApi
{
    public static class ServicesExtensionMethods
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config["ConnectionStrings:DefaultString"];
            services.AddDbContext<AllNotesDbContext>(c => c.UseSqlServer(connectionString, b => b.MigrationsAssembly("AllNotes.WebApi")));
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWrapperRepository, WrapperRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {

            services.AddTransient<ICheckListServices, CheckListServices>();
            services.AddTransient<ICheckBoxServices, CheckBoxServices>();
            services.AddTransient<INoteServices, NoteServices>();
            services.AddTransient<ICategoryServices, CategoryServices>();
            services.AddTransient<ISeriesServices, SeriesServices>();
            services.AddTransient<IExerciseServices, ExerciseServices>();
            services.AddTransient<IScheduleServices, ScheduleServices>();
            //services.AddScoped<IUserStore<User>, UserOnlyStore<User, AllNotesDbContext>>();
        }
    }
}
