using System;
using System.Collections.Generic;
using System.IO;
using Microex.Common.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microex.Common.Mvc.Extensions
{
    public static class Mvc
    {
        /// <summary>
        /// Use a preffered json format setting(eg: format date at yyyy-MM-dd HH:mm:ss & ignore loop reference & so on)
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IMvcBuilder AddPrefferedJsonSettings(this IMvcBuilder builder)
        {
            builder.AddJsonOptions(jsonOptions =>
            {
                jsonOptions.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                jsonOptions.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto;
                jsonOptions.SerializerSettings.TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple;
                jsonOptions.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                jsonOptions.SerializerSettings.Error = (sender, args) =>
                {
                    args.ErrorContext.Handled = true;
                };
                jsonOptions.SerializerSettings.Converters = (IList<JsonConverter>)new List<JsonConverter>()
                {
                    (JsonConverter) new StringEnumConverter()
                };

            });
            return builder;
        }

        /// <summary>
        /// Config angular4 spa pipe line in one line of code, default serve path is \wwwroot\index.html
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configServeStatic">true for excute <code>builder.UseStaticFiles();</code></param>
        /// <param name="wwwrootPath"></param>
        /// <param name="angularIndexName"></param>
        /// <returns></returns>
        public static IApplicationBuilder AddAngularRoute(this IApplicationBuilder builder, bool configServeStatic = true, string wwwrootPath = @"\wwwroot", string angularIndexName = "index.html")
        {
            if (configServeStatic)
            {
                builder.UseStaticFiles();
            }

            builder.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";
                await context.Response.SendFileAsync(Path.Combine(wwwrootPath, angularIndexName));
            });
            return builder;
        }

        /// <summary>
        /// config dbcontext to be auto migrated
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseAutoMigrate<T>(this IApplicationBuilder builder)
            where T : DbContext,ISeedableDbContext
        {
            //自动迁移
            using (var serviceScope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var tempInstance = serviceScope.ServiceProvider.GetService<T>();
                tempInstance.Database.Migrate();
                tempInstance.Seed();
            }
            return builder;
        }
    }
}
