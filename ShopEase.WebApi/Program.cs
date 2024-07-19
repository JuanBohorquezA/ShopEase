using ShopEase.Application;
using ShopEase.Infrastructure;
using ShopEase.Persistence;
using ShopEase.Presentation.Abstractions;


var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure()
    .AddPersistence();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseCorsDocumentation();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.AddMiddlewares();

app.MapControllers();

app.Run();
