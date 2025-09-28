using UdemyCarBook.WebApi.Extensions;
using UdemyCarBook.WebApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Extensions ile service registration
builder.Services.AddCustomCors()
                .AddJwtAuthentication()
                .AddApplicationDependencies(builder.Configuration)
                .AddFluentValidationServices();

builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapHub<CarHub>("/carHub");
app.MapControllers();

app.Run();
