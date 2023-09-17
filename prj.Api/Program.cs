using Microsoft.EntityFrameworkCore;
using prj.Application;
using prj.Application.Services;
using prj.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddScoped<ITaskRepository, TaskRepository>();
    builder.Services.AddScoped<ITaskService, TaskService>();
    builder.Services.AddControllers();
    
    builder.Services.AddInfraestructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

