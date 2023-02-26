using BusinessLogic.Data;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

var startUp = new Startup(builder.Configuration);

startUp.ConfigureServices(builder.Services);

var app = builder.Build();





// Configure the HTTP request pipeline.

startUp.Configure(app, app.Environment);

app.Run();
