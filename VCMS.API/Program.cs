using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<VCMSDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"));
});

builder.Services.RegisterServices();

builder.Services.AddControllers(options =>
{
    options.CacheProfiles.Add("NoCache", new CacheProfile { NoStore = true });
    options.CacheProfiles.Add("Any-180", new CacheProfile 
    { 
        Duration = 180, 
        Location = ResponseCacheLocation.Any
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    //options.SwaggerDoc("V1", new OpenApiInfo 
    //{
    //    Title = "Veterinary Clinic Management System API",
    //    Version = "v1" 
    //});
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(p =>
    {
        p.AllowAnyOrigin();
        p.AllowAnyHeader();
        p.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
