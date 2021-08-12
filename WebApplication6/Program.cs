using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.ConfigAdapter;
using Com.Ctrip.Framework.Apollo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Ctrip.Framework.Apollo.Logging;
using Com.Ctrip.Framework.Apollo.Core;

namespace WebApplication6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

             .ConfigureAppConfiguration((hostingContext, builder) =>
             {
                  builder
                 .AddApollo(builder.Build().GetSection("apollo"))
                 .AddDefault();
                 //.AddNamespace("T1DB");//Apollo��NameSpace������
             })
                //.ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
                //{
                //    //ע������ �Ѱ����޵���־�������Ϊ���
                //    LogManager.UseConsoleLogging(Com.Ctrip.Framework.Apollo.Logging.LogLevel.Trace);
                //    configurationBuilder
                //        .AddApollo(configurationBuilder.Build().GetSection("apollo"))
                //        .AddDefault()
                //     .AddNamespace(ConfigConsts.NamespaceApplication);
                //})
                //.AddApollo(new ApolloOptions
                //{
                //    AppId = ConfigurationManager.AppSettings["Apollo:AppId"],
                //    MetaServer = ConfigurationManager.AppSettings["Apollo:MetaServer"],
                //    Secret = ConfigurationManager.AppSettings["Apollo:Secret"]
                //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
