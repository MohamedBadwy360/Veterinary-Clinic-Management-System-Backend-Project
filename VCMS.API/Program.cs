var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<VCMSDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<VCMSDbContext>();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JWT"));
var jwtOptions = builder.Configuration.GetSection("JWT").Get<JwtOptions>();

// Register dependencies
builder.Services.RegisterDependencies();

builder.Services.AddControllers(options =>
{
    options.CacheProfiles.Add("NoCache", new CacheProfile { NoStore = true });
    options.CacheProfiles.Add("Any-180", new CacheProfile 
    { 
        Duration = 180, 
        Location = ResponseCacheLocation.Any
    });
});

builder.Services.AddCustomJwtAuthentication(jwtOptions);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Custom swagger authentication
builder.Services.AddSwaggerGenJwtAuthentication();

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

// Custom Middleware
app.UseExceptionHandlerMiddleware();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
