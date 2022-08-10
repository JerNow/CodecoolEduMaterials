using API.Middleware;
using AuthDb.Context;
using EduMaterialsDb.Context;
using EduMaterialsDb.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Services.Controllers;
using Services.Services.Interfaces;
using System.Text;

namespace API
{
   public static class ServicesConfiguration
   {
      public static void AddCustomDbContext(this IServiceCollection services, WebApplicationBuilder builder)
      {
         services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(builder.Configuration["AuthDb"]));
         services.AddDbContext<EduMaterialsDbContext>(options => options.UseSqlServer(builder.Configuration["EduMaterialsDb"]));
      }

      public static void AddCustomCors(this IServiceCollection services)
      {
         services.AddCors(o => o.AddDefaultPolicy(builder =>
         {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
         }));
      }

      public static void AddCustomAuthentication(this IServiceCollection services, WebApplicationBuilder builder)
      {
         services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
         {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidAudience = builder.Configuration["Jwt:Audience"],
               ValidIssuer = builder.Configuration["Jwt:Issuer"],
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"]))
            };
         });
      }

      public static void AddCustomServices(this IServiceCollection services)
      {
         services.AddScoped<IUnitOfWork, UnitOfWork>();
         services.AddScoped<IAuthorService, AuthorService>();
         services.AddScoped<IEduMaterialService, EduMaterialService>();
         services.AddScoped<IEduMaterialTypeService, EduMaterialTypeService>();
         services.AddScoped<IEduMaterialReviewService, EduMaterialReviewService>();
         services.AddScoped<IMyAuthorizationService, MyAuthorizationService>();
      }

      public static void AddCustomMiddleware(this IServiceCollection services)
      {
         services.AddScoped<LogHandlerMiddleware>();
         services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                           .AddRoles<IdentityRole>()
                           .AddEntityFrameworkStores<AuthDbContext>();
      }
      public static void AddCustomSwagger(this IServiceCollection services)
      {
         services.AddSwaggerGen(c =>
         {
            c.EnableAnnotations();

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
               Name = "Authorization",
               Type = SecuritySchemeType.ApiKey,
               Scheme = "Bearer",
               BearerFormat = "JWT",
               In = ParameterLocation.Header,
               Description = "Bearer Authorization",
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
         {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string [] {}
                }
         });

         });
      }
   }
}
