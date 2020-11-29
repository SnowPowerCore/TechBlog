using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PersonalTechBlog.Client.Services.Article;
using PersonalTechBlog.Client.Utils.Extensions;
using System;
using System.Threading.Tasks;

namespace PersonalTechBlog.Client
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("localClient", client =>
                client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            builder.Services.AddSingleton<IArticlesService, ArticlesService>();
            builder.Services.AddLocalization();

            var host = builder.Build();

            var cultureTask = host.SetDefaultCulture();
            var hostTask = host.RunAsync();

            return Task.WhenAll(cultureTask, hostTask);
        }
    }
}