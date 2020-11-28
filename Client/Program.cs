using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PersonalTechBlog.Client.Services.Article;
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

            return builder.Build().RunAsync();
        }
    }
}