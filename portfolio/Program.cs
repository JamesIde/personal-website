using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using portfolio;
using portfolio_models.Models;
using portfolio.Services;
using Blazor.Analytics;
using portfolio.Services.IServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddScoped<IContentfulQuery, ContentfulQuery>();
builder.Services.AddScoped<IGraphQLQuery, GraphQLQuery>();


//Base url points to our api for contentful queries
builder.Services.AddScoped<HttpClient>(s =>
{

	return new HttpClient
	{
		BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseURL"))
	};
});
builder.Services.AddGoogleAnalytics("G-GHS0468GG6");
await builder.Build().RunAsync();



