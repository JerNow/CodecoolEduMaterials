using API;
using API.Middleware;
using API.Utils;

var builder = WebApplication.CreateBuilder(args);


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

app.UseMiddleware<LogHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
