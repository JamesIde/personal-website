using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using portfolio;
using portfolio.Models;
using portfolio.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddScoped<IContentfulQuery, ContentfulQuery>();

//Base url points to our api for contentful queries
builder.Services.AddScoped<HttpClient>(s =>
{

	return new HttpClient
	{
		BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseURL"))
	};
});

await builder.Build().RunAsync();



