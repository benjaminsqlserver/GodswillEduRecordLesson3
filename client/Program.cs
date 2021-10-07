using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Radzen;

namespace GodswillEduRecord
{
    public partial class Program
    {
        static partial void OnConfigureBuilder(WebAssemblyHostBuilder builder);

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<Client.App>("app");
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();
            builder.Services.AddScoped<GlobalsService>();

            builder.Services.AddScoped<SecurityService>();

            builder.Services.AddHttpClient("GodswillEduRecord.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<Microsoft.AspNetCore.Components.WebAssembly.Authentication.BaseAddressAuthorizationMessageHandler>();

            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("GodswillEduRecord.ServerAPI"));
            builder.Services.AddApiAuthorization();

            builder.Services.AddScoped<ConDataService>();

            OnConfigureBuilder(builder);

            await builder.Build().RunAsync();
        }
    }
}
