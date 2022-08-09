using API;
using API.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCustomDbContext(builder);
builder.Services.AddCustomServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddJsonOptions(j =>
                                             {
                                                j.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
                                             })
                                 .AddNewtonsoftJson();
builder.Services.AddCustomMiddleware();
builder.Services.AddCustomAuthentication(builder);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();
builder.Services.AddCustomCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
