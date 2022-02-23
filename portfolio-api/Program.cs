using Contentful.Core;
using Contentful.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Wiring up the contentful client. Keys stored in appsettings.json

//TODO: Implement Azure Key Vault to store these three keys
builder.Services.AddTransient((sp) =>
{
    var httpClient = new HttpClient();
    var options = new ContentfulOptions
    {
        DeliveryApiKey = builder.Configuration.GetSection("ContentfulOptions").GetSection("DeliveryApiKey").Value,
        PreviewApiKey = builder.Configuration.GetSection("ContentfulOptions").GetSection("PreviewApiKey").Value,
        SpaceId = builder.Configuration.GetSection("ContentfulOptions").GetSection("SpaceId").Value
    };
    var contentfulClient = new ContentfulClient(httpClient, options);
    return contentfulClient;
});

builder.Services.AddCors(o => o.AddPolicy("Portfolio", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("Portfolio");

app.MapControllers();

app.Run();
