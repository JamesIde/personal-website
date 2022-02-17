using Contentful.AspNetCore;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using portfolio;
using portfolio.Models;
using portfolio.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddContentful(builder.Configuration);

builder.Services.AddSingleton<IContentfulService, ContentfulService>();

await builder.Build().RunAsync();



