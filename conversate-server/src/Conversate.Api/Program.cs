
using Conversate.Application.Hubs.MessageHub;
using Conversate.Infrastructure;
using Microsoft.EntityFrameworkCore;    

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MessageHub>("/message"); 
});

app.MapControllers();
app.UseCors();

app.Run();
