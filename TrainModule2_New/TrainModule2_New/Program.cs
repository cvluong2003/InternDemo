using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using TrainModule2_New.Middleware;
using TrainModule2_New.Services;
using TrainModule2_New.Models;
using TrainModule2_New.Mapping;
using Data.EntityModels;
using TrainModule2_New.Validator;
using TrainModule2_New.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(new TokenService("cao_van_luong_soai_ca_tien_giang_huit_token_key", 2));
builder.Services.AddValidatorsFromAssemblyContaining<StudentDTOValidator>();
builder.Services.AddScoped<ISinhVienService, SinhVienService>();
builder.Services.AddScoped<IGiaoVienService, GiaoVienService>();
builder.Services.AddScoped<ISinhVienModel, SinhVienModel>();
builder.Services.AddScoped<IGiaoVienModel, GiaoVienModel>();
builder.Services.AddDbContext<DBQLSV>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("QLSV")));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services
    .AddControllersWithViews()
    .AddNewtonsoftJson();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Chỉ định authentication scheme mặc định
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Chỉ định challenge scheme mặc định
})
  .AddJwtBearer(options =>
  {
      options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer = false,
          ValidateAudience = false,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("cao_van_luong_soai_ca_tien_giang_huit_token_key")),
          ClockSkew = TimeSpan.Zero // Không có độ trễ cho thời gian hết hạn
      };
  });
var app = builder.Build();

//app.UseMiddleware<CheckSerectCodeMiddleware>();

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
