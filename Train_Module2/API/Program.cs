using API.Configuration;
using API.EntityModel;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Drawing.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        var Configuration = builder.Configuration;
        // Add services to the container.

        builder.Services.AddControllers();
        //builder.Services.AddAutoMapper(typeof(AutomapperConfig).Assembly);
        builder.Services.AddMvc();
        builder.Services.AddDbContext<DBSVContext>(options =>
           options.UseSqlServer(
               Configuration.GetConnectionString("BloggingDatabase")));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
        ///mapping
      
    }
}